using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace Gladiatus_NEW
{
    class Pack
    {
        private static readonly ChromeDriver driver = Program.driver;
        private static Actions ac = Program.ac;

        private static string[] lines;
        private static string[] classes;
        private static string[] soulbounds;
        private static string[] prices;
        private static string[] levels;
        private static string[] qualities;
        private static string[] amounts;
        private static string[] solds;
        private static string[] categories;

        private static bool[] switchers;
        private static string xpath1;
        private static string xpath2;

        private static int found_it = 0;
        public static void Pack_gold()
        {
            if (!User.Default.pack || User.Default.pack_level > Get.Gold())
                return;
            Read_packages();
            while (Get.Gold() > User.Default.pack_level)
            {
                Navigation.guild_market();
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
                int first_it = driver.FindElementsByXPath("//input[@value='Kup']").Count;
                int second_it = driver.FindElementsByXPath("//input[@value='Anuluj']").Count;
                int it = first_it + second_it;

                bool bought = false;
                while(!bought)
                {
                    string[] variables = new string[6];
                    variables[0] = classes[found_case];
                    variables[1] = prices[found_case];
                    variables[2] = levels[found_case];
                    variables[3] = qualities[found_case];
                    variables[4] = amounts[found_case];
                    variables[5] = soulbounds[found_case];

                    Read_switchers(variables);
                    bought = false;
                    string[] t_variables = new string[6];
                    for (int i=2; i<it+1; i++)
                    {
                        if(Basic.Search_element("//section[@id='market_table']//tr[position()='"+Convert.ToString(i)+"']/" +
                            "td[@align='center']/input[@value='Kup']"))
                        {
                            IWebElement element = Get.Element("//section[@id='market_table']//" +
                                "tr[position()='"+Convert.ToString(i)+"']/td[@style]/div[@style]");

                            for(int j=0; j<classes.Count(); j++)
                            {
                                if (Compare_elements(element, j))
                                    break;
                            }
                        }

                        int gold_before = Get.Gold();
                        Basic.Click_element("//section[@id='market_table']//tr[position()='" + Convert.ToString(i) + "']" +
                            "/td[@align='center']/input[@value='Kup']");
                        if (gold_before - Get.Gold() == Convert.ToInt32(t_variables[1]))
                        {
                            bought = true;
                            break;
                        }

                        if (!bought && found_case != lines.Count() - 1)
                            found_case++;
                        else if (!bought && Basic.Search_element("//a[contains(text(),'Następna strona')]") &&
                            found_case == lines.Count() - 1)
                        {
                            found_case = orginal_case;
                            Basic.Click_element("//a[contains(text(),'Następna strona')]");
                        }
                        else if(!bought && found_case == lines.Count() - 1)
                            return;
                    }

                    Prepare_xpath(t_variables);
                    while(true)
                    {
                        Navigation.packages();
                        Filter_packages(categories[found_case], qualities[found_case]);
                        Navigation.backpack(User.Default.free_backpack);
                        if (!Take_from_packages())
                            return;
                        Navigation.guild_market();
                        Navigation.backpack(User.Default.free_backpack);
                        if (!Sell_on_market(t_variables[1]))
                        {
                            Basic.Wait_for_element("//div[@id='cooldown_bar_expedition']/div[@class='cooldown_bar_text']");
                            Task.Expedition();
                        }
                        else
                            break;
                    }
                }
            }
        }

        private static bool Compare_elements(IWebElement element, int it)
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

        private static IWebElement Find_element(IReadOnlyCollection<IWebElement> elements)
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

        public static void Pack_search()
        {
            if (!User.Default.pack)
                return;

            Read_packages();
            IReadOnlyCollection<IWebElement> elements;
            IWebElement found_element;
            while (true)
            {
                Navigation.packages();
                Navigation.backpack(User.Default.free_backpack);
                elements = driver.FindElementsByXPath("//div[@id='inv']//div[contains(@class,'draggable')]");
                found_element = Find_element(elements);
                if (found_element != null)
                    Sell_on_market(found_element);
                else
                    break;
            }

            Navigation.packages();
            Navigation.backpack(User.Default.free_backpack);
            while (true)
            {
                elements = driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'draggable')]");
                found_element = Find_element(elements);
                if(found_element != null)
                {
                    Basic.Move_move(found_element, "//div[@id='inv']");
                    Basic.Release("//div[@class='ui-droppable grid-droparea image-grayed active']");
                    Sell_on_market(found_element);
                    Navigation.packages();
                    Navigation.backpack(User.Default.free_backpack);
                    continue;
                }

                if (Basic.Search_element("//a[@class='paging_button paging_right_step']"))
                    Basic.Click_element("//a[@class='paging_button paging_right_step']");
                else
                    return;
            }
        }

        public static void Save_packages()
        {
            string path = "settings/packages.txt";
            if (File.Exists(path))
                File.Delete(path);

            Directory.CreateDirectory("settings");
            Navigation.guild_market();
            int first_it = driver.FindElementsByXPath("//input[@value='Kup']").Count;
            int second_it = driver.FindElementsByXPath("//input[@value='Anuluj']").Count;
            int it = first_it + second_it;
            
            for(int i=2; i<it; i++)
            {
                string price = Get.Element("//section[@id='market_table']//" +
                    "tr[position()='" + Convert.ToString(i) + "']/td[position()='3']").Text.Replace(".", "");
                IWebElement element = Get.Element("//section[@id='market_table']//" +
                    "tr[position()='"+Convert.ToString(i)+"']/td[@style]/div[@style]");
                string soulbound = element.GetAttribute("data-soulbound-to");
                string level = element.GetAttribute("data-level");
                string amount = element.GetAttribute("data-amount");
                string quality = element.GetAttribute("data-quality");
                string category = element.GetAttribute("data-content-type");
                string name = element.GetAttribute("class");
                bool solds = false;
                ac = new Actions(driver);
                ac.MoveToElement(Get.Element("//section[@id='market_table']//tr[position()='" +
                    Convert.ToString(i) + "']/td[@style]/div[@style]")).Perform();
                if (Basic.Search_element("//p[contains(text(),'Wskazówka')]"))
                    solds = true;

                string ready_line = "class_name='" + name + "' soulbound='" + soulbound + "' price='" + price + 
                    "' category='" + category + "' quality='" + quality + "' level='" + level + "' amount='" + amount +
                    "' sold='" + solds + "'";
                File.AppendAllText(path, ready_line + Environment.NewLine);
            }
        }

        private static bool Sell_on_market(string price)
        {
            Navigation.guild_market();
            Basic.Drag_and_drop(xpath1,"//div[@id='market_sell']/div[@class='ui-droppable']");
            Basic.Click_element("//select[@id='dauer']//option[@value='3']");
            IWebElement element = Get.Element("//input[@name='preis']");
            element.Clear();
            element.SendKeys(price);
            Basic.Click_element("//input[@value='Oferta']");
            if (Basic.Search_element("//div[@class='message fail']"))
                return false;
            return true;
        }

        private static void Sell_on_market(IWebElement element)
        {
            string name = Regex.Match(element.GetAttribute("class"), @"item-i-\d{1,2}-\d{1,2}").Value;
            string level = element.GetAttribute("data-level");
            string amount = element.GetAttribute("data-amount");
            string category = element.GetAttribute("data-content-type");
            string soul = element.GetAttribute("data-soulbound-to");
            string quality = element.GetAttribute("data-quality");

            string path = "//div[@id='inv']//div";
            path += "[contains(concat(' ', normalize-space(@class), ' '), ' " + name + "')]";
            path += "[@data-level='" + level + "']";
            path += "[@data-amount='" + amount + "']";
            path += "[@data-content-type='" + category + "']";
            path += "[@data-quality='" + quality + "']";

            if(soul != null)
                path += "[@data-soulbound-to='" + soul + "']";

            while (true)
            {
                Navigation.guild_market();
                Basic.Drag_and_drop(path, "//div[@id='market_sell']/div[@class='ui-droppable']");
                Basic.Click_element("//select[@id='dauer']//option[@value='3']");
                element = Get.Element("//input[@name='preis']");
                element.Clear();
                element.SendKeys(prices[found_it]);
                Basic.Click_element("//input[@value='Oferta']");
                if (Basic.Search_element("//div[@class='message fail']"))
                    Task.Expedition();
                else
                    break;
            }
        }

        private static bool Take_from_packages()
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

        private static bool Check_sold()
        {
            ac = new Actions(driver);
            ac.MoveToElement(Get.Element(xpath1)).Perform();
            if (Basic.Search_element("//p[contains(text(),'Wskazówka')]"))
                return true;
            else
                return false;
        }

        private static string Check_sold(IWebElement element)
        {
            ac = new Actions(driver);
            ac.MoveToElement(element).Perform();
            if (Basic.Search_element("//p[contains(text(),'Wskazówka')]"))
                return "True";
            else
                return "False";
        }

        private static void Filter_packages(string category, string quality)
        {
            try { Convert.ToInt32(category); category = Get.Category_packages(category); }
            catch { }

            try { Convert.ToInt32(quality); quality = Get.Quality_pack(quality); }
            catch { }

            Basic.Click_element("//select[@name='f']//option[text() = '"+category+"']");
            Basic.Click_element("//select[@name='fq']//option[text() = '"+quality+"']");
            Basic.Click_element("//input[@value='Filtr']");
        }

        private static void Prepare_xpath(string[] variables)
        {
            xpath1 = "//div[@class='packageItem']//div";
            xpath2 = "//div[@id='inv']//";
            string[] helper = new string[5];
            helper[0] = "[contains(concat(' ', normalize-space(@class), ' '), ' ";
            helper[1] = "[@data-soulbound-to='";
            helper[2] = "[@data-level='";
            helper[3] = "[@data-quality='";
            helper[4] = "[@data-amount='";
            
            for(int i=0; i<helper.Count(); i++)
            {
                if(variables[i+1] != "None")
                {
                    xpath1 += helper[i];
                    xpath2 += helper[i];
                    if (i == 1)
                    {
                        xpath1 += "')]";
                        xpath2 += "')]";
                    }
                    else
                    {
                        xpath1 += "']";
                        xpath2 += "']";
                    }
                }
            }
        }

        private static void Read_packages()
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

        private static void Read_switchers(string[] variables)
        {
            switchers = new bool[variables.Count()];
            for(int i=0; i<variables.Count(); i++)
            {
                if (variables[i] != "None")
                    switchers[i] = true;
            }
        }
    }
}
