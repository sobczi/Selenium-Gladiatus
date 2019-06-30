using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace GladiatusBOT
{
    public static class Bot
    {
        public static Main form;
        public static ChromeDriver driver;
        public static bool logged = false;
        public static bool sleep_mode = RegistryValues.Read_b("c_sleep");
        public static bool work = true;
        static public Actions ac;
        static public int wait = 250;

        public static void Run()
        {
            Directory.SetCurrentDirectory(@"../../../settings");
            while (true)
            {
                try
                {
                    Sys.Kill_chromes();
                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                    var driverOptions = new ChromeOptions();
                    if (Screen.AllScreens.Length > 1)
                        driverOptions.AddArgument("--window-position=2000,0");
                    if (RegistryValues.Read_b("c_headless"))
                        driverOptions.AddArgument("--headless");
                    driverOptions.AddExtension("GladiatusAddon.crx");
                    driver = new ChromeDriver(driverService, driverOptions);
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(wait);
                    ac = new Actions(driver);

                    Task.Login();
                    logged = true;
                    Task.Disable_notifications();
                    if (true)
                    {
                        bool exp = true;
                        bool dung = true;
                        while (exp || dung || Task.Hades_costume())
                        {
                            Update_ui();
                            exp = Task.Expedition();
                            dung = Task.Dungeon();
                            Pack.Buy();
                        }
                        Shop.Sell();
                        Extract.Extract_items();
                        Pack.Buy();
                        Pack.Search();
                        Task.Take_food();
                        driver.Close();
                    }
                }
                catch (Exception ex) { Sys.Handle_exception(ex); continue; }
                form.Invoke((MethodInvoker) delegate { form.Close(); });
                Sys.Sleep();
                return;
            }
        }

        static void Update_ui()
        {
            form.Invoke((MethodInvoker)delegate { form.labelGold.Text = Convert.ToString(Get.Gold_s()); });
            form.Invoke((MethodInvoker)delegate { form.labelRubles.Text = Convert.ToString(Get.Rubles()); });
            form.Invoke((MethodInvoker)delegate { form.labelExpedition.Text = Convert.ToString(Get.Points_expedition()); });
            form.Invoke((MethodInvoker)delegate { form.labelDungeon.Text = Convert.ToString(Get.Points_dungeon()); });
            form.Invoke((MethodInvoker)delegate { form.labelLevel.Text = Convert.ToString(Get.Level()); });
            form.Invoke((MethodInvoker)delegate { form.labelProgress.Text = Convert.ToString(Get.Progress()); });
        }
    }
}
