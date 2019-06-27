using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GladiatusBOT
{
    public partial class Form1 : Form
    {
        static readonly RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Gladiatus", true);
        public Form1()
        {
            InitializeComponent();
            Read_settings();
        }

        void Save_settings()
        {
            key.SetValue("username", textNick.Text);
            key.SetValue("password", textPassword.Text);

            key.SetValue("heal_level", Convert.ToInt32(textHeal.Text));
            key.SetValue("gold_pack", Convert.ToInt32(textGoldPack.Text));
            key.SetValue("gold_take", Convert.ToInt32(textGoldTake.Text));
            key.SetValue("food_pages", Convert.ToInt32(textFood.Text));
            key.SetValue("boosters", Convert.ToInt32(textBoosters.Text));
            key.SetValue("difference", Convert.ToInt32(textDifference.Text));

            key.SetValue("server", comboServer.SelectedIndex);
            key.SetValue("b_extract", comboExtract.SelectedIndex);
            key.SetValue("b_food", comboFood.SelectedIndex);
            key.SetValue("b_sell", comboSell.SelectedIndex);
            key.SetValue("o_expedition", comboExpedition.SelectedIndex);
            key.SetValue("o_dungeon", comboDungeon.SelectedIndex);
            key.SetValue("o_training",comboTraining.SelectedIndex);

            key.SetValue("c_expedition", checkExpedition.Checked);
            key.SetValue("c_dungeon",checkDungeon.Checked);
            key.SetValue("c_event",checkEvent.Checked);
            key.SetValue("c_heal",checkHeal.Checked);
            key.SetValue("c_food",checkFood.Checked);
            key.SetValue("c_extract",checkExtract.Checked);
            key.SetValue("c_sell",checkSell.Checked);
            key.SetValue("c_auctions",checkAuctions.Checked);
            key.SetValue("c_boosters",checkBoosters.Checked);
        }

        void Read_settings()
        {
            textNick.Text = Read_s("username");
            textPassword.Text = Read_s("password");
            textHeal.Text = Read_s("heal_level");
            textGoldPack.Text = Read_s("gold_pack");
            textGoldTake.Text = Read_s("gold_take");
            textFood.Text = Read_s("food_pages");
            textBoosters.Text = Read_s("boosters");
            textDifference.Text = Read_s("difference");

            comboServer.SelectedIndex = Read_i("server");
            comboExtract.SelectedIndex = Read_i("b_extract");
            comboFood.SelectedIndex = Read_i("b_food");
            comboSell.SelectedIndex = Read_i("b_sell");
            comboExpedition.SelectedIndex = Read_i("o_expedition");
            comboDungeon.SelectedIndex = Read_i("o_dungeon");
            comboTraining.SelectedIndex = Read_i("o_training");

            checkExpedition.Checked = Read_b("c_expedition");
            checkDungeon.Checked = Read_b("c_dungeon");
            checkEvent.Checked = Read_b("c_event");
            checkHeal.Checked = Read_b("c_heal");
            checkFood.Checked = Read_b("c_food");
            checkExtract.Checked = Read_b("c_extract");
            checkSell.Checked = Read_b("c_sell");
            checkAuctions.Checked = Read_b("c_auctions");
            checkBoosters.Checked = Read_b("c_boosters");
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e) { Save_settings(); }

        string Read_s(string var) { return Convert.ToString(key.GetValue(var)); }

        bool Read_b(string var) { return Convert.ToBoolean(key.GetValue(var)); }

        int Read_i(string var)
        {
            int temp = Convert.ToInt32(key.GetValue(var));
            if (temp == 0)
                return 0;
            return temp;
        }

        void BtnSave_Click(object sender, EventArgs e) { Save_settings(); }

        private void TextHeal_TextChanged(object sender, EventArgs e)
        {
            Only_digits(sender, e);
            TextBox t = sender as TextBox;
            if(t.Text != "" && Convert.ToInt32(t.Text) > 99)
                t.Text = "99";
        }

        private void Only_digits(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            t.Text = Regex.Match(t.Text, @"\d*").Value;
            t.SelectionStart = t.Text.Length;
            t.SelectionLength = 0;
        }
    }
}
