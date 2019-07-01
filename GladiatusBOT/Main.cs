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
            this.MaximizeBox = false;
            taskbar.ContextMenuStrip = taskbarMenu;
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
                    sleep_btn.Font = new Font(sleep_btn.Font.Name, sleep_btn.Font.Size, var);
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
            sleep_btn.Font = new Font(sleep_btn.Font.Name, sleep_btn.Font.Size, var);
        }

        private void Settings_btn_Click(object sender, EventArgs e) { new Settings().Show(); }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Bot.work = false;
            this.Hide();
            while (Bot.driver == null) { }
            Bot.driver.Quit();
            Application.Exit();
        }

        private void Sleep_btn_Click(object sender, EventArgs e)
        {
            force_sleep = true;
            Bot.sleep_mode = true;
            sleep_btn.Font = new Font(sleep_btn.Font.Name, sleep_btn.Font.Size, FontStyle.Bold);
        }

        private void Gold_btn_Click(object sender, EventArgs e)
        {
            Bot.Take_gold = true;
            gold_btn.Font = new Font(gold_btn.Font.Name, gold_btn.Font.Size, FontStyle.Bold);
        }

        private void Sell_btn_Click(object sender, EventArgs e)
        {
            Bot.Sell_items = true;
            sell_btn.Font = new Font(sell_btn.Font.Name, sell_btn.Font.Size, FontStyle.Bold);
        }

        private void BtnBotting_Click(object sender, EventArgs e)
        {
            Bot.work = !Bot.work;
            FontStyle var = FontStyle.Bold;
            if (!Bot.work)
                var = FontStyle.Regular;
            btnBotting.Font = new Font(btnBotting.Font.Name, btnBotting.Font.Size, var);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            taskbar.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Thread w_sleep = new Thread(Watch_sleep);
            w_sleep.Name = "update_sleep_button";
            w_sleep.IsBackground = true;
            w_sleep.Start();
            if(this.WindowState == FormWindowState.Normal)
            { this.Hide(); this.ShowInTaskbar = false; taskbar.Visible = true; }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            { this.Hide(); taskbar.Visible = true; }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) { Main_FormClosed(null, null); }
    }
}
