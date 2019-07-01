using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace GladiatusBOT
{
    class Pack
    {
         static Actions ac = Bot.ac;

         static string[] lines;
         static string[] classes;
         static string[] soulbounds;
         static string[] prices;
         static string[] levels;
         static string[] qualities;
         static string[] amounts;
         static string[] solds;
         static string[] categories;

         static string xpath1;
         static string xpath2;

         static int found_it = -1;
         struct Item
        {
            public string name;
            public string price;
            public string level;
            public string quality;
            public string amount;
            public string soulbound;
        }

        public static void Buy()
        {
            if (RegistryValues.Read_b("c_pack") || RegistryValues.Read_i("gold_pack") > Get.Gold())
                return;
            Read_packages();
            while (Get.Gold() > Settings.gold_pack)
            {
                Navigation.Guild_market();
                if (!Basic.Search_element("//input[@value='Kup']"))
                    return;
                int found_case = 0;
                int orginal_case = 0;

                int gold_level = Get.Gold();
                for(int i=0; i<lines.Count(); i++)
                {
                    if (gold_level - Convert.ToInt32(prices[i]) > 0)
                    {
                        found_case = i;
                        orginal_case = i;
                        break;
                    }
                }
                int first_it = Bot.driver.FindElementsByXPath("//input[@value='Kup']").Count;
                int second_it = Bot.driver.FindElementsByXPath("//input[@value='Anuluj']").Count;
                int it = first_it + second_it;

                Item item = new Item();
                while(true)
                {
                    item = new Item
                    {
                        name = classes[found_case],
                        price = prices[found_case],
                        level = levels[found_case],
                        quality = qualities[found_case],
                        amount = amounts[found_case],
                        soulbound = soulbounds[found_case]
                    };

                    List<IWebElement> elements = new List<IWebElement>();
                    List<int> positions = new List<int>();
                    for (int i=2; i<it+1; i++)
                    {
                        if(Basic.Search_element("//section[@id='market_table']//tr[position()='"+Convert.ToString(i)+"']/" + "td[@align='center']/input[@value='Kup']"))
                        {
                            elements.Add(Get.Element("//section[@id='market_table']//" + "tr[position()='" + Convert.ToString(i) + "']/td[@style]/div[@style]"));
                            positions.Add(i);
                        }
                    }

                    int found_i = -1;
                    for(int i=0; i<elements.Count; i++)
                    {
                        if(Compare_elements(elements.ElementAt(i), found_case))
                        {
                            found_i = positions[i];
                            found_it = found_case;
                            break;
                        }
                    }

                    if (found_i != -1)
                    {
                        int gold_before = Get.Gold();
                        Basic.Click_element("//section[@id='market_table']//tr[position()='" + Convert.ToString(found_i) + "']" + "/td[@align='center']/input[@value='Kup']");
                        if (gold_before - Get.Gold() == Convert.ToInt32(item.price))
                            break;
                    }

                    if (found_case != lines.Count() - 1)
                        found_case++;
                    else if (Basic.Search_element("//a[contains(text(),'Następna strona')]") &&
                        found_case == lines.Count() - 1)
                    {
                        found_case = orginal_case;
                        Basic.Click_element("//a[contains(text(),'Następna strona')]");
                    }
                    else if (found_case == lines.Count() - 1)
                        return;
                }

                Prepare_xpath(item);
                Navigation.Packages();
                Navigation.Filter_packages(categories[found_case], qualities[found_case]);
                Navigation.Backpack(Settings.b_sell);
                if (!Take_from_packages())
                    return;
                Sell_on_market();
            }
        }

        public static void Search()
        {
            if (!RegistryValues.Read_b("c_pack"))
                return;

            Read_packages();
            IReadOnlyCollection<IWebElement> elements;
            IWebElement found_element;
            while (true)
            {
                Navigation.Guild_market();
                Navigation.Backpack(Settings.b_sell);
                elements = Bot.driver.FindElementsByXPath("//div[@id='inv']//div[contains(@class,'draggable')]");
                found_element = Find_element(elements);
                if (found_element != null)
                {
                    Prepare_xpath(found_it);
                    Sell_on_market();
                }
                else
                    break;
            }

            Navigation.Packages();
            Navigation.Backpack(Settings.b_sell);
            while (true)
            {
                elements = Bot.driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'draggable')]");
                found_element = Find_element(elements);
                if (found_element != null)
                {
                    Prepare_xpath(found_it);
                    Basic.Move_move(found_element, "//div[@id='inv']");
                    Basic.Release("//div[@class='ui-droppable grid-droparea image-grayed active']");
                    Sell_on_market();
                    continue;
                }

                if (Basic.Click_if("//a[@class='paging_button paging_right_step']")) { }
                else
                    return;
            }
        }

        public static void Save()
        {
            string path = "packages.txt";
            if (File.Exists(path))
                File.Delete(path);

            Directory.CreateDirectory("settings");
            Navigation.Guild_market();
            while (true)
            {
                int first_it = Bot.driver.FindElementsByXPath("//input[@value='Kup']").Count;
                int second_it = Bot.driver.FindElementsByXPath("//input[@value='Anuluj']").Count;
                int it = first_it + second_it;

                for (int i = 2; i < it + 2; i++)
                {
                    string price = Get.Element("//section[@id='market_table']//" +
                        "tr[position()='" + Convert.ToString(i) + "']/td[position()='3']").Text.Replace(".", "");
                    IWebElement element = Get.Element("//section[@id='market_table']//" +
                        "tr[position()='" + Convert.ToString(i) + "']/td[@style]/div[@style]");
                    string soulbound = element.GetAttribute("data-soulbound-to");
                    string level = element.GetAttribute("data-level");
                    string amount = element.GetAttribute("data-amount");
                    string quality = element.GetAttribute("data-quality");
                    string category = element.GetAttribute("data-content-type");
                    string name = Regex.Match(element.GetAttribute("class"), @"item-i-\d{1,2}-\d{1,2}").Value;
                    bool solds = false;
                    ac = new Actions(Bot.driver);
                    ac.MoveToElement(Get.Element("//section[@id='market_table']//tr[position()='" +
                        Convert.ToString(i) + "']/td[@style]/div[@style]")).Perform();
                    if (Basic.Search_element("//p[contains(text(),'Wskazówka')]"))
                        solds = true;

                    string ready_line = "class_name='" + name + "' soulbound='" + soulbound + "' price='" + price +
                        "' category='" + category + "' quality='" + quality + "' level='" + level + "' amount='" + amount +
                        "' sold='" + solds + "'";
                    File.AppendAllText(path, ready_line + Environment.NewLine);
                }
                if (Basic.Click_if("//a[contains(text(), 'Następna strona')]")) { }
                else
                    return;
            }
        }

         static bool Compare_elements(IWebElement element, int it)
        {
            if (element.GetAttribute("soul") != null && element.GetAttribute("soul") != soulbounds[it])
                return false;
            if (element.GetAttribute("class").Contains(classes[it]) &&
                element.GetAttribute("data-level") == levels[it] &&
                element.GetAttribute("data-amount") == amounts[it] &&
                element.GetAttribute("data-quality") == qualities[it] &&
                Check_sold(element) == solds[it])
                return true;
            else
                return false;
        }

         static IWebElement Find_element(IReadOnlyCollection<IWebElement> elements)
        {
            foreach(IWebElement element in elements)
            {
                for(int i=0; i<classes.Count(); i++)
                {
                    if (Compare_elements(element, i))
                    {
                        found_it = i;
                        return element;
                    }
                }
            }
            return null;
        }

         static void Sell_on_market()
        {
            while (true)
            {
                Navigation.Guild_market();
                Navigation.Backpack(Settings.b_sell);
                Basic.Drag_and_drop(xpath2, "//div[@id='market_sell']/div[@class='ui-droppable']");
                Basic.Click_element("//select[@id='dauer']//option[@value='3']");
                IWebElement element = Get.Element("//input[@name='preis']");
                element.Clear();
                element.SendKeys(prices[found_it]);
                Basic.Click_element("//input[@value='Oferta']");
                if (!Basic.Search_element("//div[@class='message fail']"))
                    return;
                else
                {
                    Basic.Wait_for_element("//div[@class='cooldown_bar_text'][text()='Na wyprawę']");
                    Bot.driver.Navigate().Refresh();
                    Task.Expedition();
                }
            }
        }

         static bool Take_from_packages()
        {
            bool found = false;
            if (!Basic.Search_element(xpath1) && Basic.Search_element(xpath2))
                return !found;
            else if (Basic.Search_element(xpath1))
                found = true;
            else
            {
                while(Basic.Search_element("//a[@class='paging_button paging_right_step']"))
                {
                    if (Basic.Search_element(xpath1) && Check_sold())
                    {
                        found = true;
                        break;
                    }
                }
            }

            if(found)
            {
                Basic.Move_move(xpath1, "//div[@id='inv']");
                if (Basic.Search_element("//div[@class='ui-droppable grid-droparea image-grayed active']"))
                {
                    Basic.Release("//div[@class='ui-droppable grid-droparea image-grayed active']");
                    return true;
                }
            }
            return false;
        }

         static bool Check_sold()
        {
            Basic.Mouse_move(xpath1);
            if (Basic.Search_element("//p[contains(text(),'Wskazówka')]"))
                return true;
            else
                return false;
        }

         static string Check_sold(IWebElement element)
        {
            Basic.Mouse_move(element);
            if (Basic.Search_element("//p[contains(text(),'Wskazówka')]"))
                return "True";
            else
                return "False";
        }

         static void Prepare_xpath(int it)
        {
            Item item = new Item
            {
                name = classes[it],
                amount = amounts[it],
                price = prices[it],
                level = levels[it],
                quality = qualities[it],
                soulbound = soulbounds[it],
            };
            Prepare_xpath(item);
        }

         static void Prepare_xpath(Item item)
        {
            xpath1 = "//div[@class='packageItem']//div";
            xpath2 = "//div[@id='inv']//div";
            List<string> xpaths = new List<string>
            {
                "[contains(concat(' ', normalize-space(@class), ' '), '" + item.name + "')]",
                "[@data-level='" + item.level + "']",
                "[@data-quality='" + item.quality + "']",
                "[@data-amount='" + item.amount + "']",
            };

            if (item.soulbound != "")
                xpaths.Add("[@data-soulbound-to='" + item.soulbound + "']");


            foreach (string path in xpaths)
            {
                xpath1 += path;
                xpath2 += path;
            }
        }

         static void Read_packages()
        {
            if (!File.Exists("settings/packages.txt"))
                return;
            int lineCount = File.ReadLines("settings/packages.txt").Count();
            if (lineCount == 0) { return; }
            lines = File.ReadAllLines("settings/packages.txt");
            classes = new string[lines.Length];
            soulbounds = new string[lines.Length];
            prices = new string[lines.Length];
            levels = new string[lines.Length];
            qualities = new string[lines.Length];
            amounts = new string[lines.Length];
            solds = new string[lines.Length];
            categories = new string[lines.Length];

            string regex = "\'(.*?)\'";
            int iterator = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] separated_line = lines[i].Split(' ');
                classes[iterator] = Regex.Match(separated_line[0], regex).Value.Replace("'", "");
                soulbounds[iterator] = Regex.Match(separated_line[1], regex).Value.Replace("'", "");
                prices[iterator] = Regex.Match(separated_line[2], regex).Value.Replace("'", "");
                categories[iterator] = Regex.Match(separated_line[3], regex).Value.Replace("'", "");
                qualities[iterator] = Regex.Match(separated_line[4], regex).Value.Replace("'", "");
                levels[iterator] = Regex.Match(separated_line[5], regex).Value.Replace("'", "");
                amounts[iterator] = Regex.Match(separated_line[6], regex).Value.Replace("'", "");
                solds[iterator] = Regex.Match(separated_line[7], regex).Value.Replace("'", "");
                iterator++;
            }

            bool changed = true;
            while(changed)
            {
                changed = false;
                for(int i=0; i<lines.Length-1; i++)
                {
                    if(Convert.ToInt32(prices[i]) < Convert.ToInt32(prices[i+1]))
                    {
                        changed = true;
                        string temp = classes[i];
                        classes[i] = classes[i + 1];
                        classes[i + 1] = temp;

                        temp = soulbounds[i];
                        soulbounds[i] = soulbounds[i + 1];
                        soulbounds[i + 1] = temp;

                        temp = prices[i];
                        prices[i] = prices[i + 1];
                        prices[i + 1] = temp;

                        temp = categories[i];
                        categories[i] = categories[i + 1];
                        categories[i + 1] = temp;

                        temp = qualities[i];
                        qualities[i] = qualities[i + 1];
                        qualities[i + 1] = temp;

                        temp = levels[i];
                        levels[i] = levels[i + 1];
                        levels[i + 1] = temp;

                        temp = amounts[i];
                        amounts[i] = amounts[i + 1];
                        amounts[i + 1] = temp;

                        temp = solds[i];
                        solds[i] = solds[i + 1];
                        solds[i + 1] = temp;
                    }
                }
            }
        }

    }
}
