using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace GladiatusBOT
{
    public static class Bot
    {
        public static Main form;
        public static ChromeDriver driver;
        public static bool logged = false;
        public static bool sleep_mode = RegistryValues.Read_b("c_sleep");
        public static bool work = true;
        static bool bool_sell_items = false;
        static bool bool_take_gold = false;
        public static bool Sell_items
        {
            get { return bool_sell_items; }
            set
            {
                bool_sell_items = value;
                work = false;
                form.Invoke((MethodInvoker)delegate { form.btnBotting.Font = new Font(form.btnBotting.Font.Name, form.btnBotting.Font.Size, FontStyle.Regular); });
            }
        }

        public static bool Take_gold
        {
            get { return bool_take_gold; }
            set
            {
                bool_take_gold = value;
                work = false;
                form.Invoke((MethodInvoker)delegate { form.btnBotting.Font = new Font(form.btnBotting.Font.Name, form.btnBotting.Font.Size, FontStyle.Regular); });
            }
        }
        static public Actions ac;
        static public int wait = 250;

        public static void Run()
        {
            Directory.SetCurrentDirectory(@"../../../settings");
            work = true;
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
                    Update_ui();
                    Task.Disable_notifications();
                    if (true)
                    {
                        while (true)
                        {
                            if (work)
                            {
                                bool exp = true;
                                bool dung = true;
                                while (work && exp || dung || Task.Hades_costume())
                                {
                                    Update_ui();
                                    exp = Task.Expedition();
                                    dung = Task.Dungeon();
                                    Pack.Buy();
                                }
                                if (!work)
                                    continue;
                                Shop.Sell();
                                Extract.Extract_items();
                                Pack.Buy();
                                Pack.Search();
                                Task.Take_food();
                                driver.Close();
                                break;
                            }

                            if(Take_gold)
                            {
                                Task.Take_Gold();
                                Take_gold = false;
                                form.Invoke((MethodInvoker)delegate { form.gold_btn.Font = new Font(form.gold_btn.Font.Name, form.gold_btn.Font.Size, FontStyle.Regular); });
                            }

                            if(Sell_items)
                            {
                                Shop.Sell();
                                Sell_items = false;
                                form.Invoke((MethodInvoker)delegate { form.sell_btn.Font = new Font(form.sell_btn.Font.Name, form.sell_btn.Font.Size, FontStyle.Regular); });
                            }

                            while (!work && !Sell_items && !Take_gold)
                                Thread.Sleep(Bot.wait);
                        }
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
