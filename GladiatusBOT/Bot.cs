using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace GladiatusBOT
{
    class Bot
    {
        public static ChromeDriver driver;
        public static bool sleep_mode = true;
        public static bool work = true;
        static public Actions ac;
        static public int wait = 250;
        static readonly List<Thread> threads = new List<Thread>();
        static readonly RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Gladiatus", true);

        public static void Run()
        {
            try
            {
                Sys.Kill_chromes();
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                var driverOptions = new ChromeOptions();
                if (Screen.AllScreens.Length > 1)
                    driverOptions.AddArgument("--window-position=2000,0");
                //if (User.Default.headless)
                //    driverOptions.AddArgument("--headless");
                Directory.SetCurrentDirectory(@"../../../settings");
                driverOptions.AddExtension("GladiatusAddon.crx");
                driver = new ChromeDriver(driverService, driverOptions);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(wait);
                ac = new Actions(driver);

                Task.Login();
                Task.Disable_notifications();
                Task.Take_Gold();
                if (true)
                {
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
            catch (Exception ex)
            {
                Sys.Handle_exception(ex);
                //return false;
            }
            //return true;
        }
    }
}
