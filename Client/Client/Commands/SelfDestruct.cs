using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class SelfDestruct : Command
    {
        public SelfDestruct(string name) : base(name) { }

        public override string execute(string[] args)
        {
            string execName = System.AppDomain.CurrentDomain.FriendlyName;
            string execPath = Assembly.GetEntryAssembly().Location;
            int sectosleep = 5000;
            //string exename = "Self-Destruct.exe";
            string location = execPath;
            Process.Start("cmd.exe", "/C taskkill /f /im " + execName + " & ping 1.1.1.1 -n 1 -w " + sectosleep + " > Nul & Del /F /Q \"" + location + "\"");
            return "";

        }


    }
}
