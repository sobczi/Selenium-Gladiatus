using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GladiatusBOT
{
    public partial class Main : Form
    {
        bool force_sleep = false;
        public Main()
        {
            InitializeComponent();
            Read_settings();

            Thread w_sleep = new Thread(Watch_sleep);
            w_sleep.Name = "update_sleep_button";
            w_sleep.IsBackground = true;
            w_sleep.Start();

        }

        void Watch_sleep()
        {
            bool last = RegistryValues.Read_b("c_sleep");
            while(!force_sleep)
            {
                if(last != Bot.sleep_mode)
                {
                    last = Bot.sleep_mode;
                    FontStyle var = FontStyle.Regular;
                    if (last)
                        var = FontStyle.Bold;
                    sleep_btn.Font = new System.Drawing.Font(sleep_btn.Font.Name, sleep_btn.Font.Size, var);
                }
                Thread.Sleep(Bot.wait);
            }
        }

        void Read_settings()
        {
            labelName.Text = RegistryValues.Read_s("username");
            labelServer.Text = Get.Read_server(RegistryValues.Read_i("server"));
            FontStyle var = FontStyle.Regular;
            if (RegistryValues.Read_b("c_sleep"))
                var = FontStyle.Bold;
            sleep_btn.Font = new System.Drawing.Font(sleep_btn.Font.Name, sleep_btn.Font.Size, var);
        }

        private void Settings_btn_Click(object sender, System.EventArgs e)
        {
            new Settings().Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            while (Bot.driver == null) { }
            Bot.driver.Quit();
            Application.Exit();
        }

        private void Sleep_btn_Click(object sender, System.EventArgs e)
        {
            force_sleep = true;
            Bot.sleep_mode = true;
            sleep_btn.Font = new System.Drawing.Font(sleep_btn.Font.Name, sleep_btn.Font.Size, FontStyle.Bold);
        }
    }
}
