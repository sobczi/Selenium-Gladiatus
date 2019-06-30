namespace GladiatusBOT
{
    partial class Settings
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnSave = new System.Windows.Forms.Button();
            this.textNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textGoldPack = new System.Windows.Forms.TextBox();
            this.comboServer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboTraining = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboExpedition = new System.Windows.Forms.ComboBox();
            this.comboDungeon = new System.Windows.Forms.ComboBox();
            this.checkEvent = new System.Windows.Forms.CheckBox();
            this.checkExpedition = new System.Windows.Forms.CheckBox();
            this.checkDungeon = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboSell = new System.Windows.Forms.ComboBox();
            this.comboFood = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboExtract = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textHeal = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textDifference = new System.Windows.Forms.TextBox();
            this.textGoldTake = new System.Windows.Forms.TextBox();
            this.textBoosters = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textFood = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkCostume = new System.Windows.Forms.CheckBox();
            this.checkPack = new System.Windows.Forms.CheckBox();
            this.checkSpentRubles = new System.Windows.Forms.CheckBox();
            this.checkHeadless = new System.Windows.Forms.CheckBox();
            this.checkSleep = new System.Windows.Forms.CheckBox();
            this.checkAuctions = new System.Windows.Forms.CheckBox();
            this.checkBoosters = new System.Windows.Forms.CheckBox();
            this.checkSell = new System.Windows.Forms.CheckBox();
            this.checkExtract = new System.Windows.Forms.CheckBox();
            this.checkHeal = new System.Windows.Forms.CheckBox();
            this.checkFood = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonDownloadPackages = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkSellRed = new System.Windows.Forms.CheckBox();
            this.checkSellOrange = new System.Windows.Forms.CheckBox();
            this.checkSellPurple = new System.Windows.Forms.CheckBox();
            this.checkExtractRed = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.checkExtractOrange = new System.Windows.Forms.CheckBox();
            this.checkExtractPurple = new System.Windows.Forms.CheckBox();
            this.checkTraining = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // textNick
            // 
            resources.ApplyResources(this.textNick, "textNick");
            this.textNick.Name = "textNick";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textPassword
            // 
            resources.ApplyResources(this.textPassword, "textPassword");
            this.textPassword.Name = "textPassword";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textGoldPack
            // 
            resources.ApplyResources(this.textGoldPack, "textGoldPack");
            this.textGoldPack.Name = "textGoldPack";
            this.textGoldPack.TextChanged += new System.EventHandler(this.Only_digits);
            // 
            // comboServer
            // 
            resources.ApplyResources(this.comboServer, "comboServer");
            this.comboServer.FormattingEnabled = true;
            this.comboServer.Items.AddRange(new object[] {
            resources.GetString("comboServer.Items"),
            resources.GetString("comboServer.Items1"),
            resources.GetString("comboServer.Items2"),
            resources.GetString("comboServer.Items3"),
            resources.GetString("comboServer.Items4"),
            resources.GetString("comboServer.Items5"),
            resources.GetString("comboServer.Items6")});
            this.comboServer.Name = "comboServer";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textNick);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboServer);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboTraining);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboExpedition);
            this.groupBox2.Controls.Add(this.comboDungeon);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // comboTraining
            // 
            this.comboTraining.FormattingEnabled = true;
            this.comboTraining.Items.AddRange(new object[] {
            resources.GetString("comboTraining.Items"),
            resources.GetString("comboTraining.Items1"),
            resources.GetString("comboTraining.Items2"),
            resources.GetString("comboTraining.Items3"),
            resources.GetString("comboTraining.Items4"),
            resources.GetString("comboTraining.Items5")});
            resources.ApplyResources(this.comboTraining, "comboTraining");
            this.comboTraining.Name = "comboTraining";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboExpedition
            // 
            resources.ApplyResources(this.comboExpedition, "comboExpedition");
            this.comboExpedition.FormattingEnabled = true;
            this.comboExpedition.Items.AddRange(new object[] {
            resources.GetString("comboExpedition.Items"),
            resources.GetString("comboExpedition.Items1"),
            resources.GetString("comboExpedition.Items2"),
            resources.GetString("comboExpedition.Items3")});
            this.comboExpedition.Name = "comboExpedition";
            // 
            // comboDungeon
            // 
            resources.ApplyResources(this.comboDungeon, "comboDungeon");
            this.comboDungeon.FormattingEnabled = true;
            this.comboDungeon.Items.AddRange(new object[] {
            resources.GetString("comboDungeon.Items"),
            resources.GetString("comboDungeon.Items1")});
            this.comboDungeon.Name = "comboDungeon";
            // 
            // checkEvent
            // 
            resources.ApplyResources(this.checkEvent, "checkEvent");
            this.checkEvent.Name = "checkEvent";
            this.checkEvent.UseVisualStyleBackColor = true;
            // 
            // checkExpedition
            // 
            resources.ApplyResources(this.checkExpedition, "checkExpedition");
            this.checkExpedition.Name = "checkExpedition";
            this.checkExpedition.UseVisualStyleBackColor = true;
            // 
            // checkDungeon
            // 
            resources.ApplyResources(this.checkDungeon, "checkDungeon");
            this.checkDungeon.Name = "checkDungeon";
            this.checkDungeon.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboSell);
            this.groupBox3.Controls.Add(this.comboFood);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboExtract);
            this.groupBox3.Controls.Add(this.label9);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // comboSell
            // 
            resources.ApplyResources(this.comboSell, "comboSell");
            this.comboSell.FormattingEnabled = true;
            this.comboSell.Items.AddRange(new object[] {
            resources.GetString("comboSell.Items"),
            resources.GetString("comboSell.Items1"),
            resources.GetString("comboSell.Items2"),
            resources.GetString("comboSell.Items3"),
            resources.GetString("comboSell.Items4")});
            this.comboSell.Name = "comboSell";
            // 
            // comboFood
            // 
            resources.ApplyResources(this.comboFood, "comboFood");
            this.comboFood.FormattingEnabled = true;
            this.comboFood.Items.AddRange(new object[] {
            resources.GetString("comboFood.Items"),
            resources.GetString("comboFood.Items1"),
            resources.GetString("comboFood.Items2"),
            resources.GetString("comboFood.Items3"),
            resources.GetString("comboFood.Items4")});
            this.comboFood.Name = "comboFood";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // comboExtract
            // 
            resources.ApplyResources(this.comboExtract, "comboExtract");
            this.comboExtract.FormattingEnabled = true;
            this.comboExtract.Items.AddRange(new object[] {
            resources.GetString("comboExtract.Items"),
            resources.GetString("comboExtract.Items1"),
            resources.GetString("comboExtract.Items2"),
            resources.GetString("comboExtract.Items3"),
            resources.GetString("comboExtract.Items4")});
            this.comboExtract.Name = "comboExtract";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textHeal
            // 
            resources.ApplyResources(this.textHeal, "textHeal");
            this.textHeal.Name = "textHeal";
            this.textHeal.TextChanged += new System.EventHandler(this.TextHeal_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.textDifference);
            this.groupBox4.Controls.Add(this.textGoldTake);
            this.groupBox4.Controls.Add(this.textBoosters);
            this.groupBox4.Controls.Add(this.textGoldPack);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textFood);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.textHeal);
            this.groupBox4.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // textDifference
            // 
            resources.ApplyResources(this.textDifference, "textDifference");
            this.textDifference.Name = "textDifference";
            this.textDifference.TextChanged += new System.EventHandler(this.Only_digits);
            // 
            // textGoldTake
            // 
            resources.ApplyResources(this.textGoldTake, "textGoldTake");
            this.textGoldTake.Name = "textGoldTake";
            this.textGoldTake.TextChanged += new System.EventHandler(this.Only_digits);
            // 
            // textBoosters
            // 
            resources.ApplyResources(this.textBoosters, "textBoosters");
            this.textBoosters.Name = "textBoosters";
            this.textBoosters.TextChanged += new System.EventHandler(this.Only_digits);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // textFood
            // 
            resources.ApplyResources(this.textFood, "textFood");
            this.textFood.Name = "textFood";
            this.textFood.TextChanged += new System.EventHandler(this.Only_digits);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkTraining);
            this.groupBox5.Controls.Add(this.checkCostume);
            this.groupBox5.Controls.Add(this.checkPack);
            this.groupBox5.Controls.Add(this.checkSpentRubles);
            this.groupBox5.Controls.Add(this.checkHeadless);
            this.groupBox5.Controls.Add(this.checkSleep);
            this.groupBox5.Controls.Add(this.checkAuctions);
            this.groupBox5.Controls.Add(this.checkBoosters);
            this.groupBox5.Controls.Add(this.checkSell);
            this.groupBox5.Controls.Add(this.checkExtract);
            this.groupBox5.Controls.Add(this.checkHeal);
            this.groupBox5.Controls.Add(this.checkFood);
            this.groupBox5.Controls.Add(this.checkExpedition);
            this.groupBox5.Controls.Add(this.checkDungeon);
            this.groupBox5.Controls.Add(this.checkEvent);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // checkCostume
            // 
            resources.ApplyResources(this.checkCostume, "checkCostume");
            this.checkCostume.Name = "checkCostume";
            this.checkCostume.UseVisualStyleBackColor = true;
            // 
            // checkPack
            // 
            resources.ApplyResources(this.checkPack, "checkPack");
            this.checkPack.Name = "checkPack";
            this.checkPack.UseVisualStyleBackColor = true;
            // 
            // checkSpentRubles
            // 
            resources.ApplyResources(this.checkSpentRubles, "checkSpentRubles");
            this.checkSpentRubles.Name = "checkSpentRubles";
            this.checkSpentRubles.UseVisualStyleBackColor = true;
            // 
            // checkHeadless
            // 
            resources.ApplyResources(this.checkHeadless, "checkHeadless");
            this.checkHeadless.Name = "checkHeadless";
            this.checkHeadless.UseVisualStyleBackColor = true;
            // 
            // checkSleep
            // 
            resources.ApplyResources(this.checkSleep, "checkSleep");
            this.checkSleep.Name = "checkSleep";
            this.checkSleep.UseVisualStyleBackColor = true;
            // 
            // checkAuctions
            // 
            resources.ApplyResources(this.checkAuctions, "checkAuctions");
            this.checkAuctions.Name = "checkAuctions";
            this.checkAuctions.UseVisualStyleBackColor = true;
            // 
            // checkBoosters
            // 
            resources.ApplyResources(this.checkBoosters, "checkBoosters");
            this.checkBoosters.Name = "checkBoosters";
            this.checkBoosters.UseVisualStyleBackColor = true;
            // 
            // checkSell
            // 
            resources.ApplyResources(this.checkSell, "checkSell");
            this.checkSell.Name = "checkSell";
            this.checkSell.UseVisualStyleBackColor = true;
            // 
            // checkExtract
            // 
            resources.ApplyResources(this.checkExtract, "checkExtract");
            this.checkExtract.Name = "checkExtract";
            this.checkExtract.UseVisualStyleBackColor = true;
            // 
            // checkHeal
            // 
            resources.ApplyResources(this.checkHeal, "checkHeal");
            this.checkHeal.Name = "checkHeal";
            this.checkHeal.UseVisualStyleBackColor = true;
            // 
            // checkFood
            // 
            resources.ApplyResources(this.checkFood, "checkFood");
            this.checkFood.Name = "checkFood";
            this.checkFood.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonDownloadPackages);
            this.groupBox6.Controls.Add(this.btnSave);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // buttonDownloadPackages
            // 
            resources.ApplyResources(this.buttonDownloadPackages, "buttonDownloadPackages");
            this.buttonDownloadPackages.Name = "buttonDownloadPackages";
            this.buttonDownloadPackages.UseVisualStyleBackColor = true;
            this.buttonDownloadPackages.Click += new System.EventHandler(this.ButtonDownloadPackages_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkSellRed);
            this.groupBox7.Controls.Add(this.checkSellOrange);
            this.groupBox7.Controls.Add(this.checkSellPurple);
            this.groupBox7.Controls.Add(this.checkExtractRed);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.checkExtractOrange);
            this.groupBox7.Controls.Add(this.checkExtractPurple);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // checkSellRed
            // 
            resources.ApplyResources(this.checkSellRed, "checkSellRed");
            this.checkSellRed.Name = "checkSellRed";
            this.checkSellRed.UseVisualStyleBackColor = true;
            // 
            // checkSellOrange
            // 
            resources.ApplyResources(this.checkSellOrange, "checkSellOrange");
            this.checkSellOrange.Name = "checkSellOrange";
            this.checkSellOrange.UseVisualStyleBackColor = true;
            // 
            // checkSellPurple
            // 
            resources.ApplyResources(this.checkSellPurple, "checkSellPurple");
            this.checkSellPurple.Name = "checkSellPurple";
            this.checkSellPurple.UseVisualStyleBackColor = true;
            // 
            // checkExtractRed
            // 
            resources.ApplyResources(this.checkExtractRed, "checkExtractRed");
            this.checkExtractRed.Name = "checkExtractRed";
            this.checkExtractRed.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // checkExtractOrange
            // 
            resources.ApplyResources(this.checkExtractOrange, "checkExtractOrange");
            this.checkExtractOrange.Name = "checkExtractOrange";
            this.checkExtractOrange.UseVisualStyleBackColor = true;
            // 
            // checkExtractPurple
            // 
            resources.ApplyResources(this.checkExtractPurple, "checkExtractPurple");
            this.checkExtractPurple.Name = "checkExtractPurple";
            this.checkExtractPurple.UseVisualStyleBackColor = true;
            // 
            // checkTraining
            // 
            resources.ApplyResources(this.checkTraining, "checkTraining");
            this.checkTraining.Name = "checkTraining";
            this.checkTraining.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textGoldPack;
        private System.Windows.Forms.ComboBox comboServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkEvent;
        private System.Windows.Forms.CheckBox checkExpedition;
        private System.Windows.Forms.ComboBox comboExpedition;
        private System.Windows.Forms.ComboBox comboDungeon;
        private System.Windows.Forms.CheckBox checkDungeon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textHeal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboSell;
        private System.Windows.Forms.ComboBox comboFood;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboExtract;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboTraining;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textGoldTake;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textDifference;
        private System.Windows.Forms.TextBox textBoosters;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textFood;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkFood;
        private System.Windows.Forms.CheckBox checkAuctions;
        private System.Windows.Forms.CheckBox checkBoosters;
        private System.Windows.Forms.CheckBox checkSell;
        private System.Windows.Forms.CheckBox checkExtract;
        private System.Windows.Forms.CheckBox checkHeal;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonDownloadPackages;
        private System.Windows.Forms.CheckBox checkSleep;
        private System.Windows.Forms.CheckBox checkSpentRubles;
        private System.Windows.Forms.CheckBox checkHeadless;
        private System.Windows.Forms.CheckBox checkCostume;
        private System.Windows.Forms.CheckBox checkPack;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkSellRed;
        private System.Windows.Forms.CheckBox checkSellOrange;
        private System.Windows.Forms.CheckBox checkSellPurple;
        private System.Windows.Forms.CheckBox checkExtractRed;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkExtractOrange;
        private System.Windows.Forms.CheckBox checkExtractPurple;
        private System.Windows.Forms.CheckBox checkTraining;
    }
}

