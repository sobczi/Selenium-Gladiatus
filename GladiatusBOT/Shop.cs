using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GladiatusBOT
{
    class Shop
    {
        public static void Sell()
        {
            if (!Settings.c_sell)
                return;

            int category = 1;
            int shop = 1;
            while (category <= 10)
            {
                Navigation.Packages();
                while (category <= 10)
                {
                    Navigation.Filter_packages(Get.Category_packages(category), "");
                    Navigation.Backpack(Settings.b_sell);
                    Basic.Click_if("//a[@clas='paging_button paging_right_full']");
                    List<IWebElement> elements = Get_items(Bot.driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'draggable')]"));
                    if (elements.Count == 0)
                        category++;
                    if (!Double_click_items(elements, true))
                        break;
                }

                while (true)
                {
                    if (!Choose_shop(shop))
                    {
                        if (!RegistryValues.Read_b("c_rubles"))
                            return;
                        else
                            shop = 1;
                    }
                    if (!Double_click_items(Get_items(Bot.driver.FindElementsByXPath("//div[@id='inv']//div[contains(@class,'draggable')]")), false))
                        break;
                    else
                        shop++;
                }
            }
        }

        public static void Buy()
        {
            if (RegistryValues.Read_b("c_food"))
                Buy("Jadalne");
            if (RegistryValues.Read_b("c_boosters"))
                Buy("Przyspieszacze");
            if (RegistryValues.Read_b("c_auctions"))
            {
                Buy("Pierścienie");
                Buy("Amulety");
            }
        }

        private static void Buy(string category)
        {
            if (category == "Jadalne" || category == "Przyspieszacze")
            {
                Navigation.Packages();
                Navigation.Filter_packages(category, "");
                string var = "food";
                if (category == "Przyspieszacze")
                    var = "boosters";
                int pages = RegistryValues.Read_i(var+"_pages");
                for (int i = 0; i < pages * 10; i++)
                {
                    if (Basic.Search_element(
                        "//div[@class='paging_numbers']//a[@href][text()='" + Convert.ToString(i) + "']"))
                        return;
                }
            }
            Navigation.Main_menu("Dom aukcyjny");
            Navigation.Filter_auction_house("", category);
            string path = "//div[@class='auction_bid_div']//span[text()='Schowaj swoje złoto tu']/../../input[@value='Licytuj']";
            while (!Basic.Search_element("//div[text()='Nie masz wystarczającej ilości złota!']") && Basic.Search_element(path))
                Basic.Click_element(path);
        }
         static bool Double_click_items(List<IWebElement> elements, bool packages)
        {
            bool result = false;
            string var = "inv";
            if (!packages)
                var = "shop";
            foreach(IWebElement element in elements)
            {
                string hash = element.GetAttribute("data-hash");
                Basic.Double_click(element);
                if (!Basic.Search_element("//div[@id='" + var + "']//div[@data-hash='" + hash + "']"))
                { result = !result; break; }
            }
            if (packages)
                return !result;
            return result;
        }

         static bool Choose_shop(int shop)
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
                    if (RegistryValues.Read_b("c_rubles"))
                        Basic.Click_element("//input[@value='Nowe towary']");
                    return false;
            }
            Basic.Click_element("//div[contains(@class,'shopTab')][contains(text(),'sprzedaj')]");
            Navigation.Backpack(Settings.b_sell);
            return true;
        }

         static List<IWebElement> Get_items(IReadOnlyCollection<IWebElement> all)
        {
            List<IWebElement> elements = new List<IWebElement>();
            foreach(IWebElement element in all)
            {
                string quality = element.GetAttribute("data-quality");
                if (!RegistryValues.Read_b("c_sell_purple") && quality == "2" ||
                    !RegistryValues.Read_b("c_sell_orange") && quality == "3" ||
                    !RegistryValues.Read_b("c_sell_red") && quality == "4") continue;
                elements.Add(element);
            }
            return elements;
        }
    }
}
