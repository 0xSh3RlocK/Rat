using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
namespace Client.Commands
{
    public static class Obfuscation
    {
        public static string obfuscate (this string s)
        {

            StringBuilder sb = new StringBuilder ();

            foreach(char c in s)
            {
                switch (c)
                {
                    case 'a':
                        sb.Append("\u03B1");
                        break;

                    case 'e':
                        sb.Append("\u03B2");
                        break;

                    case 'i':
                        sb.Append("\u03B3");
                        break;

                    case 'o':
                        sb.Append("\u03B4");
                        break;

                    case 'u':
                        sb.Append("\u03B6");
                        break;
                    case 'l':
                        sb.Append("\u03B8");
                        break;
                    default: 
                        sb.Append(c);
                        break;
                }
                 
            }


            return String.Concat( sb.ToString().Reverse());
        }

        public static string deobfuscate(this string s)
        {

            string s0 = s;

            s0 = String.Concat(s0.Reverse());

            StringBuilder sb = new StringBuilder();

            foreach (char c in s0)
            {
                switch (c)
                {
                    case '\u03B1':
                        sb.Append('a');
                        break;

                    case '\u03B2':
                        sb.Append('e');
                        break;

                    case '\u03B3':
                        sb.Append('i');
                        break;

                    case '\u03B4':
                        sb.Append('o');
                        break;

                    case '\u03B6':
                        sb.Append('u');
                        break;
                    case '\u03B8':
                        sb.Append('l');
                        break;
                    default:
                        sb.Append(c);
                        break;
                }

            }

            return sb.ToString();
        }

    }
}
