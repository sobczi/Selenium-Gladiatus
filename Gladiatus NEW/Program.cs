using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace GladiatusScript
{
    class Program
    {
        public static ChromeDriver driver;
        public static bool sleep_mode = true;
        public static bool work = true;
        static public Actions ac;
        static public int wait = 250;
        static readonly List<Thread> threads = new List<Thread>();

        static bool Bot()
        {
            try
            {
                Sys.Kill_chromes();
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                var driverOptions = new ChromeOptions();
                if (Screen.AllScreens.Length > 1)
                    driverOptions.AddArgument("--window-position=2000,0");
                if (User.Default.headless)
                    driverOptions.AddArgument("--headless");
                Directory.SetCurrentDirectory(@"../settings");
                driverOptions.AddExtension("GladiatusAddon.crx");
                driver = new ChromeDriver(driverService, driverOptions);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(wait);
                ac = new Actions(driver);

                Task.Login();
                Task.Disable_notifications();
                if (true)
                {
                    //Extract.Extract_items();
                    bool exp = true;
                    bool dung = true;
                    while (exp || dung || Task.Hades_costume())
                    {
                        exp = Task.Expedition();
                        dung = Task.Dungeon();
                        Pack.Buy();
                    }
                    Shop.Sell();
                    Extract.Extract_items();
                    Pack.Buy();
                    Pack.Search();
                    driver.Close();
                }
            }
            catch(Exception ex)
            {
                Sys.Handle_exception(ex);
                return false;
            }
            return true;
        }

        static void Settings()
        {
            User.Default.username = "sobczi";
            User.Default.password = "p9su9w64";
            User.Default.server = "35";
            User.Default.expedition = true;
            User.Default.expedition_option = "4";
            User.Default.dungeon = true;
            User.Default.dungeon_advenced = true;
            User.Default.pack = true;
            User.Default.pack_level = 50000;
            User.Default.heal_backpack = "512";
            User.Default.heal_level = 30;
            User.Default.free_backpack = "514";
            User.Default.extract_backpack = "515";
            User.Default.extract_orange = true;
            User.Default.extract_red = true;

            User.Default.sell_items = true;
            User.Default.sell_purple = true;
            User.Default.sell_rubles = true;
            User.Default.headless = false;
            User.Default.Save();
        }

        static void Main()
        {
            Settings();
            Thread catch_mouse = new Thread(Sys.Catch_mouse);
            catch_mouse.Start();

            while (!Bot()) { }
            work = false;
            Sys.Sleep();

            //notify.Visible = true;
            //notify.Text = "Gladiatus BOT";
            //notify.Icon = new Icon("resources/icon.ico");
            //notify.DoubleClick += new System.EventHandler(Notify_doubleClick);
            //notify.Click += new System.EventHandler(Notify_click);
            //Application.Run();
        }
    }
}
