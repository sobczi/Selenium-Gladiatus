using System.Threading;
using System;

namespace GladiatusScript
{
    class Navigation
    {
        public static void Filter_packages(string category, string quality)
        {
            if (category == "")
                category = "Wszystko";
            if (quality == "")
                quality = "Normalny";

            try { Convert.ToInt32(category); category = Get.Category_packages(category); }
            catch { }

            try { Convert.ToInt32(quality); quality = Get.Quality_pack(quality); }
            catch { }

            Basic.Click_element("//select[@name='f']//option[text() = '" + category + "']");
            Basic.Click_element("//select[@name='fq']//option[text() = '" + quality + "']");
            Basic.Click_element("//input[@value='Filtr']");
        }

        public static void Guild_market()
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

        public static void Packages()
        {
            Basic.Click_element("//a[@id='menue_packages']");
            if (Basic.Search_element("//section[@style='display: none;']"))
                Basic.Click_element("//h2[@class='section-header'][contains(text(),'Opcje')]");
        }

        public static void Backpack(string v)
        {
            Basic.Click_element("//a[@data-bag-number='"+v+"']");
            Thread.Sleep(1000);
            Basic.Wait_for_element("//a[@data-bag-number='" + v + "'][@class='awesome-tabs current']");
            Thread.Sleep(1000);
        }

        public static void Main_menu(string path)
        {
            path = "//a[contains(@class,'menuitem')][text() = '"+path+"']";
            if (!Get.Element(path).Displayed)
            {
                Basic.Click_element("//a[contains(@href,'mod=arena')]");
                Basic.Click_element("//a[contains(text(),'Arena')]");
            }
            Basic.Click_element(path);
        }
    }
}
