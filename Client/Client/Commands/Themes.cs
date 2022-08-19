using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Commands
{
    internal class Themes : Command
    {
        public Themes(string name) : base(name) { }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        private static void DisplayPicture(string file_name)
        {
            string execPath = Assembly.GetEntryAssembly().Location;
            uint flags = 0;
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
            {
                Console.WriteLine("Error");
            }
        }
        public static void PlaySoundss()
        {

            string execPath = Assembly.GetEntryAssembly().Location;

            SoundPlayer player = new SoundPlayer(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\vlc-record-2022-04-23-05h31m06s-Hoist-the-Colours-_Pirates-of-the-Caribbean_-Cover.mp3-.wav");

            player.Load();
            player.Play();
            Thread.Sleep(29000);
        }
        public override string execute(string[] args)
        {


            DisplayPicture(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\34912.jpg");
            PlaySoundss();
            return "";
        }
    }
}
