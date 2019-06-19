using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Gladiatus_NEW
{
    class Items
    {
        private static readonly ChromeDriver driver = Program.driver;
        public static void Sell()
        {
            if (!User.Default.sell_items)
                return;

            List<IWebElement> elements = new List<IWebElement>();
            List<string> hashes = new List<string>();

            int category = 1;
            int shop = 1;
            while(category <= 10)
            {
                elements.Clear();
                hashes.Clear();
                Navigation.Packages();
                bool space = true;
                string free = "//div[@id='inv']//div[contains(@class,'active')]";
                while (space && category <= 10)
                {
                    Navigation.Filter_packages(Get.Category_packages(category++), "");
                    Navigation.Backpack(User.Default.free_backpack);
                    Basic.Click_if("//a[@clas='paging_button paging_right_full']");
                    elements = Get_items(driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'draggable')]"));
                    foreach (IWebElement element in elements)
                    {
                        Basic.Move_move(element, "//div[@id='inv']");
                        if (Basic.Search_element(free))
                        {
                            hashes.Add(element.GetAttribute("data-hash"));
                            Basic.Release(free);
                            while (Basic.Search_element("//div[@id='packages']//div[@data-hash='" + hashes[hashes.Count - 1] + "']")){ }
                        }
                        else
                        {
                            space = false;
                            break;
                        }
                    }
                }

                free = "//div[@id='shop']//div[contains(@class,'active')]";
                while (hashes.Count > 0)
                {
                    if (!Choose_shop(shop++))
                        return;
                    //foreach(string hash in hashes)
                    for(int i=0; i<hashes.Count; i++)
                    {
                        string path = "//div[@id='inv']//div[@data-hash='"+hashes[i]+"']";
                        if (!Basic.Search_element(path))
                            continue;
                        Basic.Move_move(path, "//div[@id='inv']");
                        if (Basic.Search_element(free))
                        {
                            Basic.Release(free);
                            Basic.Wait_for_element("//div[@id='shop']//div[@data-hash='" + hashes[i] + "']");
                            hashes[i] = "sold";
                        }
                        else
                            break;
                    }
                    hashes.RemoveAll(Remove_sold);
                }
            }
        }

        private static bool Remove_sold(string hash)
        {
            if (hash == "sold")
                return true;
            return false;
        }

        public static void Buy()
        {

        }

        private static bool Choose_shop(int shop)
        {
            switch(shop)
            {
                case 1:
                    Navigation.Main_menu("Broń");
                    break;
                case 2:
                    Navigation.Main_menu("Pancerz");
                    break;
                case 3:
                    Navigation.Main_menu("Handlarz");
                    break;
                case 4:
                    Navigation.Main_menu("Alchemik");
                    break;
                case 5:
                    Navigation.Main_menu("Żołnierz");
                    break;
                case 6:
                    Navigation.Main_menu("Malefica");
                    break;
                default:
                    Navigation.Main_menu("Broń");
                    if (!User.Default.sell_rubles)
                        return false;
                    Basic.Click_element("//input[@value='Nowe towary']");
                    break;
            }
            Basic.Click_element("//div[contains(@class,'shopTab')][contains(text(),'sprzedaj')]");
            Navigation.Backpack(User.Default.free_backpack);
            return true;
        }

        private static List<IWebElement> Get_items(IReadOnlyCollection<IWebElement> all)
        {
            List<IWebElement> elements = new List<IWebElement>();
            foreach(IWebElement element in all)
            {
                string quality = element.GetAttribute("data-quality");
                if (!User.Default.sell_purple && quality == "2" || quality == "3" || quality == "4")
                    continue;
                elements.Add(element);
            }
            return elements;
        }

    }
}
