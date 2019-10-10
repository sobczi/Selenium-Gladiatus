using System;
using System.IO;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Drawing;

namespace GladiatusBOT
{
    public static class Bot
    {
        public static Main form;
        public static ChromeDriver driver;
        public static bool sleep_mode = RegistryValues.Read_b("c_sleep");
        public static bool work = true;
        static bool bool_sell_items = false;
        static bool bool_take_gold = false;
        static bool bool_download_packages = false;

        public static bool Download_packages
        {
            get { return bool_download_packages; }
            set { bool_download_packages = value; work = false; Set_regular_text(form.btnBotting); }
        }

        public static bool Sell_items
        {
            get { return bool_sell_items; }
            set { bool_sell_items = value; work = false; Set_regular_text(form.btnBotting); }
        }

        public static bool Take_gold
        {
            get { return bool_take_gold; }
            set { bool_take_gold = value; work = false; Set_regular_text(form.btnBotting); }
        }

        static public Actions ac;
        static public int wait = 250;

        private static bool Create_Chrome()
        {
            Thread.Sleep(2000);
            while (!Bot.work && !Bot.Take_gold && !Bot.Sell_items) { Thread.Sleep(500); continue; }
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                var driverOptions = new ChromeOptions();
                if (Screen.AllScreens.Length > 1)
                    driverOptions.AddArgument("--window-position=2000,0");
                if (RegistryValues.Read_b("c_headless"))
                    driverOptions.AddArgument("--headless");
                driver = new ChromeDriver(driverService, driverOptions);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(wait);
                ac = new Actions(driver);
            }
            catch (Exception ex)
            {
                Basic.Kill_Chrome_Drivers();
                Sys.Handle_exception(ex);
                return false;
            }
            return true;
        }

        public static void Run()
        {
            Directory.SetCurrentDirectory(@"../../../");
            work = true;
            while (true)
            {
                if (Create_Chrome())
                    try
                    {
                        Task.Login();
                        Update_name();
                        if (true)
                        {
                            while (true)
                            {
                                if (work)
                                {
                                    bool exp = true;
                                    bool dung = true;
                                    bool event_exists = true;
                                    while (work && exp || dung || Task.Hades_costume())
                                    {
                                        exp = Task.Expedition();
                                        dung = Task.Dungeon();
                                        if (event_exists)
                                            event_exists = Task.Event();
                                        Task.Arena();
                                        Task.Circus_Turma();
                                        Pack.Buy();
                                    }
                                    if (!work) continue;
                                    Pack.Search();
                                    Extract.Extract_items();
                                    Shop.Sell();
                                    Pack.Buy();
                                    Shop.Buy();
                                    Task.Take_food();
                                    Basic.Kill_Chrome_Drivers();
                                    break;
                                }

                                if (Take_gold) { Task.Take_Gold(); Take_gold = false; Set_regular_text(form.gold_btn); }

                                if (Sell_items) { Shop.Sell(); Sell_items = false; Set_regular_text(form.sell_btn); }

                                if (Download_packages) { Pack.Save(); Download_packages = false; }

                                while (!work && !Sell_items && !Take_gold)
                                    Thread.Sleep(Bot.wait);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Basic.Kill_Chrome_Drivers();
                        Sys.Handle_exception(ex); continue;
                    }
                form.Invoke((MethodInvoker)delegate { form.Close(); });
                Sys.Sleep();
                return;
            }
        }
            
        static void Update_name()
        {
            Navigation.Main_menu("Podgląd");
            string nickname = Get.Element("//div[contains(@class,'ellipsis')]").Text;
            form.Invoke((MethodInvoker)delegate { form.labelName.Text = nickname; });
        }

        public static void Update_ui()
        {
            while (true)
            {
                try
                {
                    form.Invoke((MethodInvoker)delegate { form.labelGold.Text = Convert.ToString(Get.Gold_s()); });
                    form.Invoke((MethodInvoker)delegate { form.labelRubles.Text = Convert.ToString(Get.Rubles()); });
                    form.Invoke((MethodInvoker)delegate { form.labelExpedition.Text = Convert.ToString(Get.Points_expedition()); });
                    form.Invoke((MethodInvoker)delegate { form.labelDungeon.Text = Convert.ToString(Get.Points_dungeon()); });
                    form.Invoke((MethodInvoker)delegate { form.labelLevel.Text = Convert.ToString(Get.Level()); });
                    form.Invoke((MethodInvoker)delegate { form.labelProgress.Text = Convert.ToString(Get.Progress()); });
                } catch { }
            }
        }

        static void Set_regular_text(Button b)
        {
            form.Invoke((MethodInvoker)delegate { b.Font = new Font(b.Font.Name, b.Font.Size, FontStyle.Regular); });
        }
    }
}
