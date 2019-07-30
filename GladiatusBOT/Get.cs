using OpenQA.Selenium;
using System.Threading;
using System;

namespace GladiatusBOT
{
    class Get
    {
        public static string Level()
        {
            return Element("//div[@id='header_values_level']").Text;
        }

        public static string Progress()
        {
            return Element("//div[@id='header_values_xp_percent']").Text;
        }
        public static string Rubles()
        {
            return Element("//*[@id='sstat_ruby_val']").Text;
        }

        public static string Gold_s()
        {
            return Element("//*[@id='sstat_gold_val']").Text;
        }

        public static string Points_expedition()
        {
            return Element("//span[@id='expeditionpoints_value_point']").Text;
        }

        public static string Points_dungeon()
        {
            string p = Element("//span[@id='dungeonpoints_value_point']").Text;
            if(p=="")
                return "0";
            return p;
        }

        public static string Read_server(int var)
        {
            switch (var)
            {
                case 0:
                    return "1";
                case 1:
                    return "25";
                case 2:
                    return "34";
                case 3:
                    return "35";
                case 4:
                    return "36";
                case 5:
                    return "37";
                case 6:
                    return "38";
                default:
                    return "1";
            }
        }

        public static string Read_backpack(int var)
        {
            switch (var)
            {
                case 0:
                    return "512";
                case 1:
                    return "513";
                case 2:
                    return "514";
                case 3:
                    return "515";
                case 4:
                    return "516";
                default:
                    return "512";
            }
        }
        public static string Category_packages(string v)
        {
            switch (v)
            {
                case "2":
                    return "Bronie";
                case "4":
                    return "Tarcze";
                case "8":
                    return "Napierśniki";
                case "1":
                    return "Hełmy";
                case "256":
                    return "Rękawice";
                case "512":
                    return "Buty";
                case "48":
                    return "Pierścienie";
                case "1024":
                    return "Amulety";
                case "4096":
                    return "Bonusy";
                case "8192":
                    return "Błogosławieństwa";
                case "16384":
                    return "Najemnik";
                case "32768":
                    return "Składniki kuźnicze";
                case "65536":
                    return "Dodatki";
                default:
                    return "Wszystko";
            }
        }

        public static string Category_packages(int it)
        {
            switch(it)
            {
                case 1:
                    return "Bronie";
                case 2:
                    return "Tarcze";
                case 3:
                    return "Napierśniki";
                case 4:
                    return "Hełmy";
                case 5:
                    return "Rękawice";
                case 6:
                    return "Buty";
                case 7:
                    return "Pierścienie";
                case 8:
                    return "Amulety";
                case 9:
                    return "Bonusy";
                case 10:
                    return "Błogosławieństwa";
                default:
                    return "Wszystko";
            }
        }

        public static string Backpack(string v)
        {
            switch (v)
            {
                case "1":
                    return "512";
                case "2":
                    return "513";
                case "3":
                    return "514";
                case "4":
                    return "515";
                case "5":
                    return "516";
                case "6":
                    return "517";
                default:
                    return "512";
            }
        }

        public static string Quality_pack(string v)
        {
            switch (v)
            {
                case "0":
                    return "Ceres (zielony)";
                case "1":
                    return "Neptun (niebieski)";
                case "2":
                    return "Mars (purpurowy)";
                case "3":
                    return "Jupiter (pomarańczowy)";
                case "4":
                    return "Olimp (czerwony)";
                default:
                    return "Normalny";
            }
        }

        public static int Gold()
        {
            return Convert.ToInt32(Element("//*[@id='sstat_gold_val']").Text.Replace(".", ""));
        }

        public static int Hp()
        {
            return Convert.ToInt32(Element("//*[@id='header_values_hp_percent']").Text.Replace("%", ""));
        }

        public static IWebElement Element(string path)
        {
            Basic.Wait_for_element(path);
            return Bot.driver.FindElementByXPath(path);
        }

    }
}
