using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatusBOT
{
    class RegistryValues
    {
        static readonly RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Gladiatus", true);

        public static string Read_s(string var) { return Convert.ToString(key.GetValue(var)); }

        public static bool Read_b(string var) { return Convert.ToBoolean(key.GetValue(var)); }

        public static int Read_i(string var)
        {
            int temp = Convert.ToInt32(key.GetValue(var));
            if (temp == 0)
                return 0;
            return temp;
        }

        public static void SetKey(string variable, int value) { key.SetValue(variable, value); }
    }
}
