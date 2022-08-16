using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
namespace Client.Commands
{
    public class File : Command
    {
        public File (string name) : base(name) { }


        public string download (string url, string Fn)
        {
            using (WebClient webClient = new WebClient ())  // we are using "using" to avoid memory leak
                webClient.DownloadFile (url, Fn);

            return "Downloaded File " + Fn;
        }
        public string create(string Fn)
        {
            System.IO.File.Create(Fn).Close();

            return "Created File " + Fn;
        }
        public string DeleteFile(string Fn)
        {
            System.IO.File.Delete(Fn);  

            return "Created File " + Fn;
        }
        public string write(string Fn, string date)
        {
            System.IO.File.AppendAllText(Fn, date);
            return "Appended text File " + Fn;
        }
        public string view(string Fn)
        {
            return System.IO.File.ReadAllText(Fn);
            
        }

        public string runFile(string Fn)
        {
          return " Started process with id" + Process.Start(Fn).Id;

        }
        public override string execute(string[] args)
        {

            if (args.Length == 0) return "Expected arguments for File run";

            switch (args.First())
            {
                case "run":
                    if (args.Length != 2) return "expected 2 arguments For file run";
                   return this.runFile(args[1]);
                    break;


                case "download":
                    if (args.Length != 2) return "expected 3 arguments For file download";
                   return this.download(args[1], args[2]);
                    break;


                case "create":
                    if (args.Length != 2) return "expected 2 arguments For file create";
                    return this.create(args[1]);
                    break;

                case "write":
                    if (args.Length != 2) return "expected 3 arguments For file write";
                     return this.write(args[1], args[2]);
                    break;

                case "view":
                     if (args.Length != 2) return "expected 2 arguments For file view";
                    return this.view(args[1]);
                    break;


                default:
                    return "Unexpected arguments " + args[0];
                    break;
            }

            
        }


    }
}
