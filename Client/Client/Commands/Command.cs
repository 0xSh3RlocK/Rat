using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class Command
    {

        public string name;

        public Command(string name)
        {
            this.name = name;
        }

        public virtual string execute(string[] args)
        {
            return "";
        }

    }
}
