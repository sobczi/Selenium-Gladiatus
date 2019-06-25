using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;
using System;

namespace Gladiatus_NEW
{
    class Basic
    {
        static Actions ac;
         static void Check_events()
        {
            List<string> paths = new List<string>
            {
                "//input[@id='linkLoginBonus']",
                "//a[contains(@onclick,'MAX_simplepop')]",
                "//*[@id='linkcancelnotification']",
                "//*[@id='linknotification']"
            };
            Program.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(0);
            foreach (string path in paths)
            {
                try { Program.driver.FindElementByXPath(path).Click(); }
                catch { continue; }
            }
            Program.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Program.wait);
        }
        public static bool Search_element(string path)
        {
            if (Program.driver.FindElementsByXPath(path).Count > 0)
                return true;
            else
                return false;
        }

        public static void Wait_for_element(string path)
        {
            Program.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
            Program.driver.FindElementByXPath(path);
            Program.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Program.wait);
            while (!Get.Element(path).Displayed)
                Thread.Sleep(100);
        }

        public static void Move_move(string path1, string path2)
        {
            IWebElement element1 = Get.Element(path1);
            IWebElement element2 = Get.Element(path2);

            ac = new Actions(Program.driver);
            ac.ClickAndHold(element1);
            ac.MoveToElement(element2).Perform();
        }

        public static void Move_move(IWebElement element1, IWebElement element2)
        {
            ac = new Actions(Program.driver);
            ac.ClickAndHold(element1);
            ac.MoveToElement(element2).Perform();
        }

        public static void Move_move(IWebElement element1, string element2)
        {
            ac = new Actions(Program.driver);
            ac.ClickAndHold(element1);
            ac.MoveToElement(Program.driver.FindElementByXPath(element2)).Perform();
        }

        public static void Move_release(string path1, string path2)
        {
            IWebElement element1 = Get.Element(path1);
            IWebElement element2 = Get.Element(path2);

            ac = new Actions(Program.driver);
            ac.ClickAndHold(element1);
            ac.Release(element2).Perform();
        }

        public static void Move_release(IWebElement element1, IWebElement element2)
        {
            ac = new Actions(Program.driver);
            ac.ClickAndHold(element1);
            ac.Release(element2).Perform();
        }

        public static void Mouse_move(string path)
        {
            ac = new Actions(Program.driver);
            ac.MoveToElement(Get.Element(path)).Perform();
        }

        public static void Mouse_move(IWebElement element)
        {
            ac = new Actions(Program.driver);
            ac.MoveToElement(element).Perform();
        }

        public static void Drag_and_drop(string path1, string path2)
        {
            Wait_for_element(path1);
            IWebElement element1 = Get.Element(path1);
            Wait_for_element(path2);
            IWebElement element2 = Get.Element(path2);
            ac = new Actions(Program.driver);
            ac.DragAndDrop(element1, element2).Perform();
        }

        public static void Release(string path)
        {
            ac = new Actions(Program.driver);
            ac.Release(Program.driver.FindElementByXPath(path)).Perform();
        }

        public static void Click_element(string path)
        {
            Check_events();
            IWebElement element = Get.Element(path);
            ac = new Actions(Program.driver);
            ac.MoveToElement(element).Perform();
            element.Click();
        }

        public static void Double_click(IWebElement element)
        {
            ac = new Actions(Program.driver);
            ac.DoubleClick(element).Perform();
        }

        public static bool Click_if(string path)
        {
            Check_events();
            if(Basic.Search_element(path) && Program.driver.FindElementByXPath(path).Displayed)
                Basic.Click_element(path);
            else
                return false;
            return true;
        }

        public static string Get_digits(string path)
        {
            return Regex.Match(Program.driver.FindElementByXPath(path).Text,@"\d+").Value;
        }
    }
}
