﻿using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GladiatusBOT
{
    class Task
    {
        public static void Login()
        {
            Bot.driver.Navigate().GoToUrl("https://lobby.gladiatus.gameforge.com/pl_PL/?mod=start&submod=index");
            Basic.Click_element("//ul[@class='tabsList']//span[text()='Login']");
            Get.Element("//input[@type='email']").SendKeys(Settings.username);
            Get.Element("//input[@type='password']").SendKeys(Settings.password);
            Basic.Click_element("//button[@type='submit']");
            Basic.Click_element("//span[text()='Ostatnia gra']");
            foreach(string title in Bot.driver.WindowHandles)
                Bot.driver.SwitchTo().Window(title);
        }

        public static void Training()
        {
            if (!RegistryValues.Read_b("c_training"))
                return;
            Navigation.Main_menu("Trening");
            if (!Basic.Search_element("//a[@title='trenuj']"))
                return;
            Bot.driver.FindElementsByXPath("//div[@id='training_box']//img[@alt='']")
                [RegistryValues.Read_i("o_training")+1].Click();
        }

        public static void Take_food()
        {
            Navigation.Packages();
            Navigation.Filter_packages("Jadalne", "");
            Basic.Click_if("//a[@class='paging_button paging_right_full']");
            Navigation.Backpack(Settings.b_food);
            IReadOnlyCollection<IWebElement> elements = Bot.driver.FindElementsByXPath("//div[@id='packages']//div[@data-content-type='64']");
            foreach (IWebElement element in elements)
                if (!Basic.Move_to_inventory(element))
                    return;
        }

        public static void Heal_me()
        {
            if (!RegistryValues.Read_b("c_heal"))
                return;
            while(Get.Hp() < Settings.heal_level)
            {
                Navigation.Main_menu("Podgląd");
                Navigation.Backpack(Settings.b_food);
                if (!Basic.Search_element("//div[@id='inv']//div[@data-content-type='64']")) { Take_food(); continue; }
                Basic.Drag_and_drop("//div[@id='inv']//div[@data-content-type='64']","//div[@id='avatar']//div[@class='ui-droppable']");
                Thread.Sleep(2000);
            }
        }

        public static bool Hades_costume()
        {
            if (!RegistryValues.Read_b("c_costume") || Basic.Search_element("//div[contains(@onmousemove,'Zbroja Disa Patera')]"))
                return false;
            Navigation.Main_menu("Podgląd");
            Basic.Click_element("//input[@value='zmień']");
            if (Basic.Click_if("//input[contains(@onclick,'Zbroja Disa Patera')]"))
                Basic.Click_element("//td[@id='buttonleftchangeCostume']/input[@value='Tak']");
            else
                return false;
            return true;
        }

        public static bool Expedition()
        {
            int points = Convert.ToInt32(Get.Points_expedition());
            if (!RegistryValues.Read_b("c_expedition") || points == 0)
                return false;
            Heal_me();
            Basic.Wait_for_element("//div[@id='cooldown_bar_expedition']/div[@class='cooldown_bar_text']");
            Basic.Click_element("//div[@id='cooldown_bar_expedition']/a[@class='cooldown_bar_link']");
            Basic.Click_element("//div[@class='expedition_box']["+Convert.ToString(Settings.o_expedition)+"]//button[contains(@class,'awesome')]");
            Basic.Wait_for_element("//table[@style='border-spacing:0;']//td[2]");

            if (points == 1)
                return false;
            else
                return true;
        }

        public static bool Arena()
        {
            if (!RegistryValues.Read_b("c_arena"))
                return false;
            Heal_me();
            Basic.Wait_for_element("//div[@id='cooldown_bar_arena']//div[@class='cooldown_bar_text']");
            Basic.Click_element("//div[@id='cooldown_bar_arena']//a[@class='cooldown_bar_link']");
            Basic.Click_element("//div[@class='attack']");
            Basic.Wait_for_element("//body[@id='reportsPage']");
            return true;
        }

        public static bool Circus_Turma()
        {
            if (!RegistryValues.Read_b("c_turma"))
                return false;
            Basic.Wait_for_element("//div[@id='cooldown_bar_ct']//div[@class='cooldown_bar_text']");
            Basic.Click_element("//div[@id='cooldown_bar_ct']//a[@class='cooldown_bar_link']");
            Basic.Click_element("//div[@class='attack']");
            Basic.Wait_for_element("//body[@id='reportsPage']");
            return true;
        }

        public static bool Event()
        {
            if (!RegistryValues.Read_b("c_event"))
                return false;
            Heal_me();
            Basic.Click_element("//div[@id='cooldown_bar_expedition']/a[@class='cooldown_bar_link']");
            if (Basic.Click_if("//a[contains(@class,'menuitem glow eyecatcher')]"))
            {
                if (Basic.Search_element("//div[@class='serverquest_reward_header']"))
                    return false;
                string text = Bot.driver.FindElementByXPath("//div[@class='section-header']/p[2]").GetAttribute("textContent");
                int points = Convert.ToInt32(Regex.Match(text, @"\d+").Value);
                if (points > 0)
                {
                    if(!Basic.Search_element("//span[@class='ticker'][contains(text(),'Czas do następnej ekspedycji')]"))
                        Basic.Click_element("//button[@class='expedition_button awesome-button ']");
                }
                else
                    return false;
            }
            else
                return false;
            return true;
        }

        public static bool Dungeon()
        {
            if (Basic.Search_element("//div[@id='cooldown_bar_dungeon']/a[@class='cooldown_bar_link']"))
                if (!Get.Element("//div[@id='cooldown_bar_dungeon']/a[@class='cooldown_bar_link']").Displayed)
                    return false;
            int points = Convert.ToInt32(Get.Element("//*[@id='dungeonpoints_value_point']").Text);
            if (!RegistryValues.Read_b("c_dungeon") || points == 0)
                return false;
            Basic.Wait_for_element("//div[@id='cooldown_bar_dungeon']/div[@class='cooldown_bar_text']");
            Basic.Click_element("//div[@id='cooldown_bar_dungeon']/a[@class='cooldown_bar_link']");
            if(Basic.Search_element("//input[@value='normalne']") || Basic.Search_element("//input[@value='zaawansowane']"))
            {
                if(Settings.o_dungeon == 1 && Basic.Click_if("input[@value='zaawansowane']")) { }
                else
                    Basic.Click_element("//input[@value='normalne']");
            }
            Basic.Wait_for_element("//span[@class='dungeon_header_open']");
            Basic.Click_element("//img[contains(@src,'combatloc.gif')]");
            Basic.Wait_for_element("//table[@style='border-spacing:0;']//td[2]");

            if (points == 1)
                return true;
            else
                return false;
        }

        public static void Take_Gold()
        {
            Navigation.Packages();
            Navigation.Filter_packages("Złoto", "");
            Basic.Click_if("//a[@class='paging_button paging_right_full']");
            while(Get.Gold() < RegistryValues.Read_i("gold_take") && Basic.Search_element("//div[@id='packages']//div[contains(@class,'draggable')]"))
            {
                IReadOnlyCollection<IWebElement> elements = Bot.driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'draggable')]");
                foreach(IWebElement element in elements)
                {
                    Basic.Double_click(element);
                    if (Get.Gold() < RegistryValues.Read_i("gold_take"))
                        break;
                }
            }
        }
    }
}
