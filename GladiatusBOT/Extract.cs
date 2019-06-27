using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace GladiatusBOT
{
    class Extract
    {
        public static void Extract_items()
        {
            Get_items();
            Navigation.Main_menu("Roztapiarka");
            Navigation.Backpack(Form1.b_extract);
            string inv_draggable = "//div[@id='inv']//div[contains(@class,'ui-draggable')]";
            for(int i=0; i<6; i++)
            {
                if (!Basic.Search_element(inv_draggable))
                    break;
                string first = "//div[contains(@class,'forge_closed "+Convert.ToString(i)+"')]";
                string second = "//div[contains(@class,'forge_finished-succeeded "+Convert.ToString(i)+"')]";
                if (Basic.Click_if(first)) { }
                else if (Basic.Click_if(second))
                    Basic.Click_element("//div[contains(text(),'Wyślij jako pakiet')]");
                else
                    continue;
                Basic.Wait_for_element("//div[@class='forge_closed "+Convert.ToString(i)+" tabActive']");
                Navigation.Backpack(Form1.b_extract);
                Basic.Move_release(inv_draggable, "//fieldset[@id='crafting_input']//div[@class='ui-droppable']");
                while (!Get.Element("//div[@class='icon_gold']").Displayed) { Thread.Sleep(100); }
                Basic.Click_element("//div[@class='icon_gold']");
                Thread.Sleep(750);
                if (Basic.Search_element("//div[@id='ajaxErrorDialog']"))
                    break;
                Basic.Wait_for_element("//div[@class='forge_crafting "+Convert.ToString(i)+" tabActive']");
            }
            Store();
        }
         static void Get_items()
        {
            Navigation.Main_menu("Roztapiarka");
            Navigation.Backpack(Form1.b_extract);
            int first_it = Bot.driver.FindElementsByXPath("//div[contains(@class,'forge_closed')]").Count;
            int second_it = Bot.driver.FindElementsByXPath("//div[contains(@class,'forge_finished-succeeded')]").Count;
            int third_it = Bot.driver.FindElementsByXPath("//div[@id='inv']//div[contains(@class,'draggable')]").Count;
            int it = first_it + second_it - third_it;

            //if (User.Default.extract_purple)
            //    colour = "Mars (purpurowy)";
            //else if (User.Default.extract_orange)
            //    colour = "Jupiter (pomarańczowy)";
            //else if (User.Default.extract_red)
            //    colour = "Olimp (czerwony)";

            Navigation.Packages();
            string colour = "Jupiter (pomarańczowy)";
            Navigation.Filter_packages("", colour);
            Basic.Click_if("//a[@class='paging_button paging_right_full']");
            while (true)
            {
                List<IWebElement> elements = Load_items();
                if(elements.Count == 0)
                {
                    if (Basic.Click_if("//a[@class='paging_button paging_left_step']"))
                        continue;
                    break;
                }

                it = Move_items(elements, it);
                if (it < 0)
                    return;
                Basic.Click_if("//a[@class='paging_button paging_left_step']");
            }

            if (it > 0)
            {
                string[] customs = null;
                if (File.Exists(@"extract.txt"))
                    customs = File.ReadAllLines(@"extract.txt");
                Navigation.Packages();
                Navigation.Backpack(Form1.b_extract);
                for (int i=0; i<customs.Length; i++)
                {
                    IWebElement textbox = Get.Element("//input[@name='qry']");
                    textbox.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                    textbox.SendKeys(OpenQA.Selenium.Keys.Delete);
                    textbox.SendKeys(customs[i]);
                    Basic.Click_element("//input[@value='Filtr']");
                    do
                    {
                        List<IWebElement> elements = Load_items();
                        if (elements.Count == 0)
                            break;
                        it = Move_items(elements, it);
                        if (it < 0)
                            return;
                    } while (Basic.Click_if("//a[@class='paging_button paging_left_step']"));
                }
            }

            if(it > 0)
            {
                Navigation.Packages();
                Navigation.Backpack(Form1.b_extract);
                Basic.Click_if("//a[@class='paging_button paging_right_full']");
                while (true)
                {
                    List<IWebElement> elements = Load_items();
                    if (elements.Count == 0)
                    {
                        if (Basic.Click_if("//a[@class='paging_button paging_left_step']"))
                            continue;
                        break;
                    }
                    it = Move_items(elements, it);
                    if (it < 0)
                        return;
                }
            }
        }

         static int Move_items(List<IWebElement> elements, int it)
        {
            Navigation.Backpack(Form1.b_extract);
            foreach (IWebElement element in elements)
            {
                string hash = element.GetAttribute("data-hash");
                Basic.Double_click(element);
                if (Basic.Search_element("//div[@id='packages']//div[@data-hash='" + hash + "']"))
                    it--;
                else
                    return -1;
            }
            return it;
        }

         static List<IWebElement> Load_items()
        {
            List<IWebElement> ready = new List<IWebElement>();
            List<string> invalid = new List<string>
            {
                "64",
                "4096",
                "8192",
                "32768",
                "-1",
                "131072",
                "8388608",
                "1048576",
                "4194304",
                "2097152",
            };

            IReadOnlyCollection<IWebElement> elements = Bot.driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'ui-draggable')]");
            foreach (IWebElement element in elements)
            {
                if (!invalid.Contains(element.GetAttribute("data-content-type")))
                    ready.Add(element);
            }

            return ready;
        }

         static void Store()
        {
            Navigation.Main_menu("Magazyn surowców");
            if (Basic.Search_element("//button[@id='store'][@disabled='']"))
                Basic.Click_element("//input[@id='from-packages']");
            Basic.Click_element("//button[@id='store']");
        }
    }
}
