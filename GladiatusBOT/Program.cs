using System;
using System.Threading;
using System.Windows.Forms;

namespace GladiatusBOT
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Thread t = new Thread(() =>
            //{
            //    Application.Run(new Form1());
            //});
            //t.SetApartmentState(ApartmentState.STA);
            //t.Start();
            //Thread form = new Thread();
            //form.Start();



            Thread catch_mouse = new Thread(Sys.Catch_mouse);
            catch_mouse.IsBackground = true;
            catch_mouse.Start();


            Bot.Run();
            //Thread bot = new Thread(Bot.Run);
            //bot.IsBackground = true;
            //bot.Start();
        }
    }
}
