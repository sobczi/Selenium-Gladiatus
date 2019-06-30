﻿using OpenQA.Selenium;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GladiatusBOT
{
    class Task
    {
        public static void Login()
        {
            Bot.driver.Navigate().GoToUrl("https://pl.gladiatus.gameforge.com/game/");
            Get.Element("//input[@id='login_username']").SendKeys(Form1.username);
            Get.Element("//input[@id='login_password']").SendKeys(Form1.password);
            Basic.Click_element("//optgroup[@label='Prowincje']//option[contains(text(),'"+Form1.server+"')]");
            Basic.Click_element("//*[@id='loginsubmit']");
        }

        public static void Disable_notifications()
        {
            Basic.Click_element("//a[@href][text() = 'Profil']");
            Basic.Click_element("//input[@value='Ustawienia']");

            Basic.Click_element("//label[@for='top_fixed_bar__false']");
            Basic.Click_element("//label[@for='sound_notifications__false']");
            Basic.Click_element("//label[@for='cooldown_sound_notifications__false']");
            Basic.Click_element("//label[@for='browser_notifications__false']");
            Basic.Click_element("//input[@value='Zapisz wszystko']");

            Basic.Click_element("//li[@data-category='market']");
            Basic.Click_element("//label[@for='soulbound_warning__false']");
            Basic.Click_element("//input[@value='Zapisz wszystko']");
        }

        public static void Heal_me()
        {
            while(Get.Hp() < Form1.heal_level)
            {
                Navigation.Main_menu("Podgląd");
                Navigation.Backpack(Form1.b_food);
                if(!Basic.Search_element("//div[@id='inv']//div[@data-content-type='64']"))
                {
                    Navigation.Packages();
                    Navigation.Filter_packages("Jadalne","");
                    IReadOnlyCollection<IWebElement> elements = Bot.driver.FindElementsByXPath("//div[@id='packages']//div[@data-content-type='64']");
                    foreach (IWebElement element in elements)
                        Basic.Double_click(element);
                }
                Navigation.Main_menu("Podgląd");
                Navigation.Backpack(Form1.b_food);
                Basic.Drag_and_drop("//div[@id='inv']//div[@data-content-type='64']","//div[@id='avatar']//div[@class='ui-droppable']");
                Thread.Sleep(2000);
            }
        }

        public static bool Hades_costume()
        {
            if (Basic.Search_element("//div[contains(@onmousemove,'Zbroja Disa Patera')]"))
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
            int points = Convert.ToInt32(Get.Element("//*[@id='expeditionpoints_value_point']").Text);
            if (!Form1.c_expedition || points == 0)
                return false;
            Heal_me();
            Basic.Wait_for_element("//div[@id='cooldown_bar_expedition']/div[@class='cooldown_bar_text']");
            Basic.Click_element("//div[@id='cooldown_bar_expedition']/a[@class='cooldown_bar_link']");

            Basic.Click_element("//button[contains(@onclick,'"+Form1.o_expedition+"')]");
            Basic.Wait_for_element("//table[@style='border-spacing:0;']//td[2]");

            if (points == 1)
                return false;
            else
                return true;
        }

        public static bool Dungeon()
        {
            if (Basic.Search_element("//div[@id='cooldown_bar_dungeon']/a[@class='cooldown_bar_link']"))
                if (!Get.Element("//div[@id='cooldown_bar_dungeon']/a[@class='cooldown_bar_link']").Displayed)
                    return false;
            int points = Convert.ToInt32(Get.Element("//*[@id='dungeonpoints_value_point']").Text);
            if (points == 0)
                return false;
            Basic.Wait_for_element("//div[@id='cooldown_bar_dungeon']/div[@class='cooldown_bar_text']");
            Basic.Click_element("//div[@id='cooldown_bar_dungeon']/div[@class='cooldown_bar_link']");
            if(Basic.Search_element("input[@value='Normalne']") || Basic.Search_element("input[@value='zaawansowane']"))
            {
                if(Form1.o_dungeon == 1 && Basic.Click_if("input[@value='zaawansowane']")) { }
                else
                    Basic.Click_element("//input[@value='Normalne']");
            }
            Basic.Wait_for_element("//span[@class='dungeon_header_open']");
            Basic.Click_element("//img[contains(@src,'combatloc.gif')]");
            Basic.Wait_for_element("//table[@style='border-spacing:0;]//td[2]");

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
            while(Get.Gold() < 185000000 && Basic.Search_element("//div[@id='packages']//div[contains(@class,'draggable')]"))
            {
                IReadOnlyCollection<IWebElement> elements = Bot.driver.FindElementsByXPath("//div[@id='packages']//div[contains(@class,'draggable')]");
                foreach(IWebElement element in elements)
                {
                    Basic.Double_click(element);
                    if (Get.Gold() < 185000000)
                        break;
                }
            }
        }
    }
}