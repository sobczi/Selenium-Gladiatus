﻿using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Gladiatus_NEW
{
    class Sys
    {
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        static bool sleep_mode = true;

        public static void Handle_exception(Exception ex)
        {
            string path = @"settings\exceptions.txt";
            string content = "=======START=======" + Environment.NewLine;
            content += "Error Message: " + ex.Message + Environment.NewLine;
            content += "Stack Trace: " + ex.StackTrace + Environment.NewLine;
            content += "Date: " + DateTime.Now + Environment.NewLine;
            content += "=======END=======" + Environment.NewLine;
            File.AppendAllText(path, content);
        }

        public static void Catch_mouse()
        {
            var main_pos = Cursor.Position; 
            while(true)
            {
                if(main_pos != Cursor.Position)
                {
                    sleep_mode = false;
                    return;
                }
                Thread.Sleep(Program.wait);
            }
        }

        public static void Sleep()
        {
            if(sleep_mode)
                SetSuspendState(false, true, false);
        }

        public static void Kill_chromes()
        {
            foreach(Process process in Process.GetProcesses())
            {
                string name = process.ProcessName;
                if (name == "chromedriver")
                    process.Close();
            }
        }

        public static void Kill_all(List<Thread> threads)
        {
            Kill_chromes();
            foreach (Thread thread in threads)
                thread.Abort();
        }
    }
}
