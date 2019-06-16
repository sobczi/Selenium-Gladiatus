using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace Gladiatus_NEW
{
    class Task
    {
        private static readonly ChromeDriver driver = Program.driver;
        public static void Login()
        {
            driver.Navigate().GoToUrl("https://pl.gladiatus.gameforge.com/game/");
            Get.Element("//input[@id='login_username']").SendKeys(User.Default.username);
            Get.Element("//input[@id='login_password']").SendKeys(User.Default.password);
            Basic.Click_element("//optgroup[@label='Prowincje']//option[contains(text(),'"+User.Default.server+"')]");
            Basic.Click_element("//*[@id='loginsubmit']");
        }

        public static void Heal_me()
        {
            while(Get.Hp() < User.Default.heal_level)
            {
                Navigation.review();
                Navigation.backpack(User.Default.heal_backpack);
                Basic.Drag_and_drop("//div[@id='inv']//div[@data-content-type='16777215']",
                    "//div[@id='avatar']//div[@class='ui-droppable']");
                Thread.Sleep(2000);
            }
        }

        public static bool Take_hades_costume()
        {
            if (Basic.Search_element("//div[contains(@onmousemove,'Zbroja Disa Patera')]"))
                return false;
            Navigation.review();
            Basic.Click_element("//input[@value='zmień']");
            if (Basic.Search_element("//input[contains(@onclick,'Zbroja Disa Patera')]"))
            {
                Basic.Click_element("//input[contains(@onclick,'Zbroja Disa Patera')]");
                Basic.Click_element("//td[@id='buttonleftchangeCostume']/input[@value='Tak']");
                return true;
            }
            else
                return false;
        }

        public static bool Expedition()
        {
            int points = Convert.ToInt32(Get.Element("//*[@id='expeditionpoints_value_point']").Text);
            if (!User.Default.expedition || points == 0)
                return false;
            Heal_me();
            Basic.Wait_for_element("//div[@id='cooldown_bar_expedition']/div[@class='cooldown_bar_text']");
            Basic.Click_element("//div[@id='cooldown_bar_expedition']/a[@class='cooldown_bar_link']");

            Basic.Click_element("//button[contains(@onclick,'"+User.Default.expedition_option+"')]");
            Basic.Wait_for_element("//table[@style='border-spacing:0;']//td[2]");

            if (points == 1)
                return false;
            else
                return true;
        }

        public static bool Dungeon(bool exit)
        {
            if (exit)
                return false;
            
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
                if(User.Default.dungeon_advenced && !Basic.Search_element("//input[@value='zaawansowane'][@disabled='disabled']"))
                    Basic.Click_element("input[@value='zaawansowane']");
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
    }
}
