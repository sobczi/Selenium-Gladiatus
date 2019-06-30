using System;
using System.Threading;
using System.Windows.Forms;

namespace GladiatusBOT
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread catch_mouse = new Thread(Sys.Catch_mouse);
            catch_mouse.Name = "mouse";
            catch_mouse.IsBackground = true;
            catch_mouse.Start();


            Thread bot = new Thread(Bot.Run);
            bot.Name = "bot";
            bot.IsBackground = true;
            bot.Start();

            Bot.form = new Main();
            Application.Run(Bot.form);
        }
    }
}
