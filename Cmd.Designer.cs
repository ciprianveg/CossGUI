namespace WindowsFormsApplication1
{
    partial class Cmd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmd));
            this.outputField = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.inputField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.costDownTextBox = new System.Windows.Forms.TextBox();
            this.profitTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.orderSize = new System.Windows.Forms.TextBox();
            this.startBotButton = new System.Windows.Forms.Button();
            this.coinLabel = new System.Windows.Forms.Label();
            this.refCoinLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pairsComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.startManualButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.allTickerDataButton = new System.Windows.Forms.Button();
            this.marketTickerDataButton = new System.Windows.Forms.Button();
            this.checkMarketParirsButton = new System.Windows.Forms.Button();
            this.orderHistoryButton = new System.Windows.Forms.Button();
            this.pairDepthButton = new System.Windows.Forms.Button();
            this.balanceButton = new System.Windows.Forms.Button();
            this.sellButton = new System.Windows.Forms.Button();
            this.buyButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputField
            // 
            resources.ApplyResources(this.outputField, "outputField");
            this.outputField.Name = "outputField";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputField
            // 
            resources.ApplyResources(this.inputField, "inputField");
            this.inputField.Name = "inputField";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.restartButton, "restartButton");
            this.restartButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.restartButton.Name = "restartButton";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.quitButton, "quitButton");
            this.quitButton.ForeColor = System.Drawing.Color.Red;
            this.quitButton.Name = "quitButton";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.resultTextBox);
            this.tabPage1.Controls.Add(this.costDownTextBox);
            this.tabPage1.Controls.Add(this.profitTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.priceTextBox);
            this.tabPage1.Controls.Add(this.orderSize);
            this.tabPage1.Controls.Add(this.startBotButton);
            this.tabPage1.Controls.Add(this.coinLabel);
            this.tabPage1.Controls.Add(this.refCoinLabel);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pairsComboBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // resultTextBox
            // 
            resources.ApplyResources(this.resultTextBox, "resultTextBox");
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            // 
            // costDownTextBox
            // 
            resources.ApplyResources(this.costDownTextBox, "costDownTextBox");
            this.costDownTextBox.Name = "costDownTextBox";
            // 
            // profitTextBox
            // 
            resources.ApplyResources(this.profitTextBox, "profitTextBox");
            this.profitTextBox.Name = "profitTextBox";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LavenderBlush;
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // priceTextBox
            // 
            resources.ApplyResources(this.priceTextBox, "priceTextBox");
            this.priceTextBox.Name = "priceTextBox";
            // 
            // orderSize
            // 
            resources.ApplyResources(this.orderSize, "orderSize");
            this.orderSize.Name = "orderSize";
            // 
            // startBotButton
            // 
            this.startBotButton.BackColor = System.Drawing.Color.LawnGreen;
            resources.ApplyResources(this.startBotButton, "startBotButton");
            this.startBotButton.Name = "startBotButton";
            this.startBotButton.UseVisualStyleBackColor = false;
            this.startBotButton.Click += new System.EventHandler(this.startBotButton_Click);
            // 
            // coinLabel
            // 
            resources.ApplyResources(this.coinLabel, "coinLabel");
            this.coinLabel.Name = "coinLabel";
            this.coinLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // refCoinLabel
            // 
            resources.ApplyResources(this.refCoinLabel, "refCoinLabel");
            this.refCoinLabel.Name = "refCoinLabel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pairsComboBox
            // 
            this.pairsComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.pairsComboBox, "pairsComboBox");
            this.pairsComboBox.Name = "pairsComboBox";
            this.pairsComboBox.SelectedValueChanged += new System.EventHandler(this.pairsComboBox_SelectedValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.startManualButton);
            this.tabPage2.Controls.Add(this.helpButton);
            this.tabPage2.Controls.Add(this.cancelButton);
            this.tabPage2.Controls.Add(this.allTickerDataButton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.inputField);
            this.tabPage2.Controls.Add(this.marketTickerDataButton);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.checkMarketParirsButton);
            this.tabPage2.Controls.Add(this.orderHistoryButton);
            this.tabPage2.Controls.Add(this.pairDepthButton);
            this.tabPage2.Controls.Add(this.balanceButton);
            this.tabPage2.Controls.Add(this.sellButton);
            this.tabPage2.Controls.Add(this.buyButton);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // startManualButton
            // 
            resources.ApplyResources(this.startManualButton, "startManualButton");
            this.startManualButton.Name = "startManualButton";
            this.startManualButton.UseVisualStyleBackColor = true;
            this.startManualButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // helpButton
            // 
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click_1);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // allTickerDataButton
            // 
            resources.ApplyResources(this.allTickerDataButton, "allTickerDataButton");
            this.allTickerDataButton.Name = "allTickerDataButton";
            this.allTickerDataButton.UseVisualStyleBackColor = true;
            this.allTickerDataButton.Click += new System.EventHandler(this.allTickerDataButton_Click_1);
            // 
            // marketTickerDataButton
            // 
            resources.ApplyResources(this.marketTickerDataButton, "marketTickerDataButton");
            this.marketTickerDataButton.Name = "marketTickerDataButton";
            this.marketTickerDataButton.UseVisualStyleBackColor = true;
            this.marketTickerDataButton.Click += new System.EventHandler(this.marketTickerDataButton_Click_1);
            // 
            // checkMarketParirsButton
            // 
            resources.ApplyResources(this.checkMarketParirsButton, "checkMarketParirsButton");
            this.checkMarketParirsButton.Name = "checkMarketParirsButton";
            this.checkMarketParirsButton.UseVisualStyleBackColor = true;
            this.checkMarketParirsButton.Click += new System.EventHandler(this.checkMarketParirsButton_Click_1);
            // 
            // orderHistoryButton
            // 
            resources.ApplyResources(this.orderHistoryButton, "orderHistoryButton");
            this.orderHistoryButton.Name = "orderHistoryButton";
            this.orderHistoryButton.UseVisualStyleBackColor = true;
            this.orderHistoryButton.Click += new System.EventHandler(this.orderHistoryButton_Click_1);
            // 
            // pairDepthButton
            // 
            resources.ApplyResources(this.pairDepthButton, "pairDepthButton");
            this.pairDepthButton.Name = "pairDepthButton";
            this.pairDepthButton.UseVisualStyleBackColor = true;
            this.pairDepthButton.Click += new System.EventHandler(this.pairDepthButton_Click_1);
            // 
            // balanceButton
            // 
            resources.ApplyResources(this.balanceButton, "balanceButton");
            this.balanceButton.Name = "balanceButton";
            this.balanceButton.UseVisualStyleBackColor = true;
            this.balanceButton.Click += new System.EventHandler(this.balanceButton_Click);
            // 
            // sellButton
            // 
            this.sellButton.BackColor = System.Drawing.Color.Tomato;
            resources.ApplyResources(this.sellButton, "sellButton");
            this.sellButton.Name = "sellButton";
            this.sellButton.UseVisualStyleBackColor = false;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click_1);
            // 
            // buyButton
            // 
            this.buyButton.BackColor = System.Drawing.Color.YellowGreen;
            resources.ApplyResources(this.buyButton, "buyButton");
            this.buyButton.Name = "buyButton";
            this.buyButton.UseVisualStyleBackColor = false;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // Cmd
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.outputField);
            this.Name = "Cmd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cmd_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputField;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label coinLabel;
        private System.Windows.Forms.Label refCoinLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pairsComboBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button allTickerDataButton;
        private System.Windows.Forms.Button marketTickerDataButton;
        private System.Windows.Forms.Button checkMarketParirsButton;
        private System.Windows.Forms.Button orderHistoryButton;
        private System.Windows.Forms.Button pairDepthButton;
        private System.Windows.Forms.Button balanceButton;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox orderSize;
        private System.Windows.Forms.Button startBotButton;
        private System.Windows.Forms.Button startManualButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox costDownTextBox;
        private System.Windows.Forms.TextBox profitTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox resultTextBox;
    }
}

