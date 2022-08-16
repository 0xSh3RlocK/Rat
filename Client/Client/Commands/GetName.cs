using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class GetName : Command
    {
        public GetName(string name) : base(name)
        {}

        public override string execute(string[] args)
        {
            if (args.Length != 0)
            {
                return "Invaled Argument For GetName Command ";
            }

            return Environment.UserName;

            
        }
    }
}
