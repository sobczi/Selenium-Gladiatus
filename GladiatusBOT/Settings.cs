using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GladiatusBOT
{
    public partial class Settings : Form
    {
        static readonly RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Gladiatus", true);
        public static string username = RegistryValues.Read_s("username");
        public static string password = RegistryValues.Read_s("password");
        public static string server = Get.Read_server(RegistryValues.Read_i("server"));

        public static int heal_level = RegistryValues.Read_i("heal_level");
        public static int gold_pack = RegistryValues.Read_i("gold_pack");
        public static int gold_text = RegistryValues.Read_i("gold_take");
        public static int food_pages = RegistryValues.Read_i("food_pages");
        public static int boosters_pages = RegistryValues.Read_i("boosters_pages");
        public static int difference = RegistryValues.Read_i("difference");
        public static int o_dungeon = RegistryValues.Read_i("o_dungeon");
        public static int o_expedition = RegistryValues.Read_i("o_expedition")+1;

        public static bool c_expedition = RegistryValues.Read_b("c_expedition");
        public static bool c_dungeon = RegistryValues.Read_b("c_dungeon");
        public static bool c_event = RegistryValues.Read_b("c_event");
        public static bool c_heal = RegistryValues.Read_b("c_heal");
        public static bool c_food = RegistryValues.Read_b("c_food");
        public static bool c_extract = RegistryValues.Read_b("c_extract");
        public static bool c_sell = RegistryValues.Read_b("c_sell");
        public static bool c_auctions = RegistryValues.Read_b("c_auctions");
        public static bool c_boosters = RegistryValues.Read_b("c_boosters");

        public static string b_extract = Get.Read_backpack(RegistryValues.Read_i("b_extract"));
        public static string b_food = Get.Read_backpack(RegistryValues.Read_i("b_food"));
        public static string b_sell = Get.Read_backpack(RegistryValues.Read_i("b_sell"));

        public Settings()
        {
            InitializeComponent();
            Read_settings();
            this.MaximizeBox = false;
        }

        void Save_settings()
        {
            key.SetValue("username", textNick.Text);
            key.SetValue("password", textPassword.Text);

            key.SetValue("heal_level", Convert.ToInt32(textHeal.Text));
            key.SetValue("gold_pack", Convert.ToInt32(textGoldPack.Text));
            key.SetValue("gold_take", Convert.ToInt32(textGoldTake.Text));
            key.SetValue("food_pages", Convert.ToInt32(textFood.Text));
            key.SetValue("boosters_pages", Convert.ToInt32(textBoosters.Text));
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
            key.SetValue("c_sleep", checkSleep.Checked);
            key.SetValue("c_headless", checkHeadless.Checked);
            key.SetValue("c_rubles", checkSpentRubles.Checked);
            key.SetValue("c_pack", checkPack.Checked);
            key.SetValue("c_costume", checkCostume.Checked);
            key.SetValue("c_training", checkTraining.Checked);
            key.SetValue("c_extract_purple", checkExtractPurple.Checked);
            key.SetValue("c_extract_orange", checkExtractOrange.Checked);
            key.SetValue("c_extract_red", checkExtractRed.Checked);
            key.SetValue("c_sell_purple", checkSellPurple.Checked);
            key.SetValue("c_sell_orange", checkSellOrange.Checked);
            key.SetValue("c_sell_red", checkSellRed.Checked);
            key.SetValue("c_arena", checkArena.Checked);
            key.SetValue("c_turma", checkTurma.Checked);
        }

        void Read_settings()
        {
            textNick.Text = RegistryValues.Read_s("username");
            textPassword.Text = RegistryValues.Read_s("password");
            textHeal.Text = RegistryValues.Read_s("heal_level");
            textGoldPack.Text = RegistryValues.Read_s("gold_pack");
            textGoldTake.Text = RegistryValues.Read_s("gold_take");
            textFood.Text = RegistryValues.Read_s("food_pages");
            textBoosters.Text = RegistryValues.Read_s("boosters_pages");
            textDifference.Text = RegistryValues.Read_s("difference");

            comboServer.SelectedIndex = RegistryValues.Read_i("server");
            comboExtract.SelectedIndex = RegistryValues.Read_i("b_extract");
            comboFood.SelectedIndex = RegistryValues.Read_i("b_food");
            comboSell.SelectedIndex = RegistryValues.Read_i("b_sell");
            comboExpedition.SelectedIndex = RegistryValues.Read_i("o_expedition");
            comboDungeon.SelectedIndex = RegistryValues.Read_i("o_dungeon");
            comboTraining.SelectedIndex = RegistryValues.Read_i("o_training");

            checkExpedition.Checked = RegistryValues.Read_b("c_expedition");
            checkDungeon.Checked = RegistryValues.Read_b("c_dungeon");
            checkEvent.Checked = RegistryValues.Read_b("c_event");
            checkHeal.Checked = RegistryValues.Read_b("c_heal");
            checkFood.Checked = RegistryValues.Read_b("c_food");
            checkExtract.Checked = RegistryValues.Read_b("c_extract");
            checkSell.Checked = RegistryValues.Read_b("c_sell");
            checkAuctions.Checked = RegistryValues.Read_b("c_auctions");
            checkBoosters.Checked = RegistryValues.Read_b("c_boosters");
            checkSleep.Checked = RegistryValues.Read_b("c_sleep");
            checkHeadless.Checked = RegistryValues.Read_b("c_headless");
            checkSpentRubles.Checked = RegistryValues.Read_b("c_rubles");
            checkPack.Checked = RegistryValues.Read_b("c_pack");
            checkCostume.Checked = RegistryValues.Read_b("c_costume");
            checkTraining.Checked = RegistryValues.Read_b("c_training");
            checkSellPurple.Checked = RegistryValues.Read_b("c_sell_purple");
            checkSellOrange.Checked = RegistryValues.Read_b("c_sell_orange");
            checkSellRed.Checked = RegistryValues.Read_b("c_sell_red");
            checkExtractPurple.Checked = RegistryValues.Read_b("c_extract_purple");
            checkExtractOrange.Checked = RegistryValues.Read_b("c_extract_orange");
            checkExtractRed.Checked = RegistryValues.Read_b("c_extract_red");
            checkArena.Checked = RegistryValues.Read_b("c_arena");
            checkTurma.Checked = RegistryValues.Read_b("c_turma");

            Check_Avability_Sell(null, null);
            Check_Avability_Extract(null, null);
            Check_Avability_Auction(null, null);
            Check_Avability_Boosters(null, null);
            Check_Avability_Pack(null, null);
            Check_Avability_Food(null, null);
            Check_Avability_Health(null, null);
            Check_Avability_Backpack_Food(null, null);
            Check_Avability_Dungeon(null, null);
            Check_Avability_Expedition(null, null);
            Check_Avability_Training(null, null);
            Check_Avability_Difference();
        }

        void Check_Avability_Expedition(object sender, EventArgs e)
        {
            if (!checkExpedition.Checked)
                comboExpedition.Enabled = false;
            else
                comboExpedition.Enabled = true;
        }

        void Check_Avability_Dungeon(object sender, EventArgs e)
        {
            if (!checkDungeon.Checked)
                comboDungeon.Enabled = false;
            else
                comboDungeon.Enabled = true;
        }

        void Check_Avability_Training(object sender, EventArgs e)
        {
            if (!checkTraining.Checked)
                comboTraining.Enabled = false;
            else
                comboTraining.Enabled = true;
        }

        void Check_Avability_Backpack_Food(object sender, EventArgs e)
        {
            if (!checkHeal.Checked && !checkFood.Checked)
                comboFood.Enabled = false;
            else
                comboFood.Enabled = true;
        }

        void Check_Avability_Health(object sender, EventArgs e)
        {
            if (!checkHeal.Checked)
                textHeal.Enabled = false;
            else
                textHeal.Enabled = true;
            Check_Avability_Backpack_Food(null, null);
        }

        void Check_Avability_Difference()
        {
            if (checkAuctions.Checked || checkFood.Checked || checkBoosters.Checked)
                textDifference.Enabled = true;
            else
                textDifference.Enabled = false;
        }

        void Check_Avability_Pack(object sender, EventArgs e)
        {
            if (!checkPack.Checked)
                textGoldPack.Enabled = false;
            else
                textGoldPack.Enabled = true;
        }

        void Check_Avability_Auction(object sender, EventArgs e)
        {
            if (!checkAuctions.Checked)
                textDifference.Enabled = false;
            else
                textDifference.Enabled = true;
            Check_Avability_Difference();
        }

        void Check_Avability_Food(object sender, EventArgs e)
        {
            if (!checkFood.Checked)
                textFood.Enabled = false;
            else
                textFood.Enabled = true;
            Check_Avability_Difference();
            Check_Avability_Backpack_Food(null, null);
        }

        void Check_Avability_Boosters(object sender, EventArgs e)
        {
            if (!checkBoosters.Checked)
                textBoosters.Enabled = false;
            else
                textBoosters.Enabled = true;
            Check_Avability_Difference();
        }

        void Check_Avability_Sell(object sender, EventArgs e)
        {
            if(checkSell.Checked)
            {
                checkSellPurple.Enabled = true;
                checkSellOrange.Enabled = true;
                checkSellRed.Enabled = true;
                comboSell.Enabled = true;
            }
            else
            {
                checkSellPurple.Enabled = false;
                checkSellOrange.Enabled = false;
                checkSellRed.Enabled = false;
                comboSell.Enabled = false;
            }
        }

        void Check_Avability_Extract(object sender, EventArgs e)
        {
            if(checkExtract.Checked)
            {
                checkExtractPurple.Enabled = true;
                checkExtractOrange.Enabled = true;
                checkExtractRed.Enabled = true;
                comboExtract.Enabled = true;
            }
            else
            {
                checkExtractPurple.Enabled = false;
                checkExtractOrange.Enabled = false;
                checkExtractRed.Enabled = false;
                comboExtract.Enabled = false;
            }
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) { this.Hide(); }

        private void ButtonDownloadPackages_Click(object sender, EventArgs e) { Bot.Download_packages = true; }
    }
}
