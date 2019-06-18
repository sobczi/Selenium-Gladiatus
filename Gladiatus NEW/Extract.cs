using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Gladiatus_NEW
{
    class Extract
    {
        private static readonly ChromeDriver driver = Program.driver;

        public static void Extract_items()
        {
            Get_items();
            Navigation.Extract();
            Navigation.Backpack(User.Default.extract_backpack);
            string inv_draggable = "//div[@id='inv']//div[contains(@class,'ui-draggable')]";
            for(int i=0; i<6; i++)
            {
                if (!Basic.Search_element(inv_draggable))
                    return;
                string first = "//div[contains(@class,'forge_closed "+Convert.ToString(i)+"')]";
                string second = "//div[contains(@class,'forge_finished-succeeded "+Convert.ToString(i)+"')]";
                if (Basic.Search_element(first))
                    Basic.Click_element(first);
                else if (Basic.Search_element(second))
                {
                    Basic.Click_element(second);
                    Basic.Click_element("//div[contains(text(),'Wyślij jako pakiet')]");
                }
                else
                    continue;
                Basic.Wait_for_element("//div[@class='forge_closed "+Convert.ToString(i)+" tabActive']");
                Navigation.Backpack(User.Default.extract_backpack);
                Basic.Move_release(inv_draggable, "//fieldset[@id='crafting_input']//div[@class='ui-droppable']");
                while (!Get.Element("//div[@class='icon_gold']").Displayed) { Thread.Sleep(100); }
                Basic.Click_element("//div[@class='icon_gold']");
                Basic.Wait_for_element("//div[@class='forge_crafting "+Convert.ToString(i)+" tabActive']");
            }
            Store();
        }
        private static void Get_items()
        {
            Navigation.Extract();
            Navigation.Backpack(User.Default.extract_backpack);
            int first_it = driver.FindElementsByXPath("//div[contains(@class,'forge_closed')]").Count;
            int second_it = driver.FindElementsByXPath("//div[contains(@class,'forge_finished-succeeded')]").Count;
            int third_it = driver.FindElementsByXPath("//div[@id='inv']//div[contains(@class,'draggable')]").Count;
            int it = first_it + second_it - third_it;

            Navigation.Packages();
            string colour = "";
            if (User.Default.extract_purple)
                colour = "Mars (purpurowy)";
            else if (User.Default.extract_orange)
                colour = "Jupiter (pomarańczowy)";
            else if (User.Default.extract_red)
                colour = "Olimp (czerwony)";

            Navigation.Filter_packages("", colour);
            if (Basic.Search_element("//a[@class='paging_button paging_right_full']"))
                Basic.Click_element("//a[@class='paging_button paging_right_full']");
            while(true)
            {
                List<IWebElement> elements = Load_items();
                if (elements.Count == 0 && Basic.Search_element("//a[@class='paging_button paging_right_step']"))
                {
                    Basic.Click_element("//a[@class='paging_button paging_right_step']");
                    continue;
                }
                else if(elements.Count == 0)
                    break;

                it = Move_items(elements, it);
                if (it < 0)
                    return;
                if (Basic.Search_element("//a[@class='paging_button paging_right_step']"))
                    Basic.Click_element("//a[@class='paging_button paging_right_step']");
            }

            if (it > 0)
            {
                string[] customs = null;
                if (File.Exists(@"settings/extract.txt"))
                    customs = File.ReadAllLines(@"settings/extract.txt");
                Navigation.Packages();
                Navigation.Backpack(User.Default.extract_backpack);
                for (int i=0; i<customs.Length; i++)
                {
                    IWebElement textbox = Get.Element("//input[@name='qry']");
                    textbox.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                    textbox.SendKeys(OpenQA.Selenium.Keys.Delete);
                    textbox.SendKeys(customs[i]);
                    Basic.Click_element("//input[@value='Filtr']");
                    List<IWebElement> elements = Load_items();
                    it = Move_items(elements, it);
                    if (it < 0)
                        return;
                }
            }

            if(it > 0)
            {
                Navigation.Packages();
                Navigation.Backpack(User.Default.extract_backpack);
                if (Basic.Search_element("//a[@class='paging_button paging_right_full']"))
                    Basic.Click_element("//a[@class='paging_button paging_right_full']");
                while (true)
                {
                    List<IWebElement> elements = Load_items();
                    it = Move_items(elements, it);
                    if (it < 0)
                        return;
                    if (Basic.Search_element("//a[@class='paging_button paging_left_step']"))
                        Basic.Click_element("//a[@class='paging_button paging_left_step']");
                }
            }
        }

        private static int Move_items(List<IWebElement> elements, int it)
        {
            Navigation.Backpack(User.Default.extract_backpack);
            foreach (IWebElement element in elements)
            {
                Basic.Move_move(element, "//div[@id='inv']");
                if (Basic.Search_element("//div[@class='ui-droppable grid-droparea image-grayed active']"))
                {
                    Basic.Release("//div[@class='ui-droppable grid-droparea image-grayed active']");
                    Basic.Wait_for_element("//div[@id='inv']//div[@data-hash='"+element.GetAttribute("data-hash")+"']");
                    it--;
                }
                else
                    return -1;
            }
            return it;
        }

        private static List<IWebElement> Load_items()
        {
            List<IWebElement> ready = new List<IWebElement>();
            List<string> invalid = new List<string>
            {
                "64",
                "4096",
                "8192",
                "32768",
                "-1"
            };

            IReadOnlyCollection<IWebElement> elements = driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'ui-draggable')]");
            foreach (IWebElement element in elements)
            {
                if (!invalid.Contains(element.GetAttribute("data-content-type")))
                    ready.Add(element);
            }

            return ready;
        }

        private static void Store()
        {
            Navigation.Warehouse();
            if (Basic.Search_element("//button[@id='store'][@disabled='']"))
                Basic.Click_element("//input[@id='from-packages']");
            Basic.Click_element("//button[@id='store']");
        }
    }
}
