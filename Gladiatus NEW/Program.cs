using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Gladiatus_NEW
{
    class Program
    {
        static public ChromeDriver driver;
        static public Actions ac;
        static void Main()
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
            User.Default.free_backpack = "514";
            User.Default.Save();

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var driverOptions = new ChromeOptions();
            driverOptions.AddArgument("--window-position=1750,50");
            driverOptions.AddExtension("settings/GladiatusTools.crx");
            driver = new ChromeDriver(driverService, driverOptions);
            driver.Manage().Window.Maximize();
            ac = new Actions(driver);

            Task.Login();
            //Task.expedition();
            //Task.dungeon(test);
            //Pack.save_packages();
            //Pack.pack_search();
            Pack.Pack_gold();
        }
    }
}
