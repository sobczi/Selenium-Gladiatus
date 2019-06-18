using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;

namespace Gladiatus_NEW
{
    class Basic
    {
        private static readonly ChromeDriver driver = Program.driver;
        private static Actions ac;
        private static void Check_events()
        {
            List<string> paths = new List<string>
            {
                "//input[@id='linkLoginBonus']",
                "//a[contains(@onclick,'MAX_simplepop')]",
                "//*[@id='linkcancelnotification']",
                "//*[@id='linknotification']"
            };
            foreach (string path in paths)
            {
                try { driver.FindElementByXPath(path).Click(); }
                catch { continue; }
            }
        }
        public static bool Search_element(string path)
        {
            IReadOnlyCollection<IWebElement> list_elements = driver.FindElementsByXPath(path);
                if (list_elements.Count > 0)
                return true;
            else
                return false;
        }

        public static void Wait_for_element(string path)
        {
            while (!Search_element(path))
                Thread.Sleep(100);
            while (!Get.Element(path).Displayed)
                Thread.Sleep(100);
        }

        public static void Move_move(string path1, string path2)
        {
            IWebElement element1 = Get.Element(path1);
            IWebElement element2 = Get.Element(path2);

            ac = new Actions(driver);
            ac.ClickAndHold(element1);
            ac.MoveToElement(element2).Perform();
        }

        public static void Move_move(IWebElement element1, IWebElement element2)
        {
            ac = new Actions(driver);
            ac.ClickAndHold(element1);
            ac.MoveToElement(element2).Perform();
        }

        public static void Move_move(IWebElement element1, string element2)
        {
            ac = new Actions(driver);
            ac.ClickAndHold(element1);
            ac.MoveToElement(Get.Element(element2)).Perform();
        }

        public static void Move_release(string path1, string path2)
        {
            IWebElement element1 = Get.Element(path1);
            IWebElement element2 = Get.Element(path2);

            ac = new Actions(driver);
            ac.ClickAndHold(element1);
            ac.Release(element2).Perform();
        }

        public static void Move_release(IWebElement element1, IWebElement element2)
        {
            ac = new Actions(driver);
            ac.ClickAndHold(element1);
            ac.Release(element2).Perform();
        }

        public static void Mouse_move(string path)
        {
            ac = new Actions(driver);
            ac.MoveToElement(Get.Element(path)).Perform();
        }

        public static void Drag_and_drop(string path1, string path2)
        {
            Wait_for_element(path1);
            IWebElement element1 = Get.Element(path1);
            Wait_for_element(path2);
            IWebElement element2 = Get.Element(path2);
            ac = new Actions(driver);
            ac.DragAndDrop(element1, element2).Perform();
        }

        public static void Release(string path)
        {
            ac = new Actions(driver);
            ac.Release(driver.FindElementByXPath(path)).Perform();
        }

        public static void Click_element(string path1)
        {
            Check_events();
            Get.Element(path1).Click();
        }

        public static string Get_digits(string path)
        {
            return Regex.Match(driver.FindElementByXPath(path).Text,@"\d+").Value;
        }
    }
}
