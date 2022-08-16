using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class Beep : Command
    {   
        
        public Beep(string name) : base(name)
        { 
            
        
        
        }

        public override string execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Beep();
                return "";
            }
            else if(args.Length == 1)
            {
                int i = 0;
                while (i != Int32.Parse(args.First()))
                {
                    Console.Beep();
                    ++i;

                       
                }
                return "";
            }
            else
            {
                return "Invalid argumnets For beep Requeries one or 2. ";
            }
        }



    }
}
