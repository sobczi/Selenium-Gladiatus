using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Gladiatus_NEW
{
    class Navigation
    {
        private static ChromeDriver driver = Program.driver;
        public static void guild_market()
        {
            while(!Basic.Search_element("//a[contains(@href,'guildMarket')][@class='map_label']"))
            {
                Basic.Click_element("//a[text() = 'Gildia']");
                Thread.Sleep(100);
            }
            Basic.Click_element("//a[contains(@href,'guildMarket')][@class='map_label']");
            while (Basic.Search_element("//div[@id='market_sell_box']//section[@style='display: none']"))
                Basic.Click_element("//h2[@class='section-header'][text() = 'sprzedaj']");
        }

        public static void packages()
        {
            Basic.Click_element("//a[@id='menue_packages']");
            if (Basic.Search_element("//section[@style='display: none;']"))
                Basic.Click_element("//h2[@class='section-header'][contains(text(),'Opcje')]");
        }

        public static void backpack(string v)
        {
            Basic.Click_element("//a[@data-bag-number='"+v+"']");
            Thread.Sleep(1000);
            Basic.Wait_for_element("//a[@data-bag-number='" + v + "'][@class='awesome-tabs current']");
            Thread.Sleep(1000);
        }

        public static void review()
        {
            Basic.Click_element("//a[@title='Podgląd']");
        }

        public static void main_menu(string path)
        {
            if (!Get.Element(path).Displayed)
                arena();
            Basic.Click_element(path);
        }

        public static void arena()
        {
            while(true)
            {
                Basic.Click_element("//div[@id='cooldown_bar_arena']/a");
                IWebElement element = Get.Element("//*[@id='mainnav']/li/table/tbody/tr/td[1]/a");
            }
        }
    }
}
