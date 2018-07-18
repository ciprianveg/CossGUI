using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Cmd : Form
    {
        public Cmd()
        {
            InitializeComponent();
            Load();
            this.KeyPreview = true;
        }

        System.Diagnostics.Process p;
        StreamWriter inputStream;
        StreamReader outputStream;
        StreamReader errorStream;
        byte[] readOutputBuffer = new byte[8192];
        byte[] readErrorBuffer = new byte[8192];
        Font outputFont = new Font("Consolas", 10);
        Font errorFont = new Font("Consolas", 10, FontStyle.Bold);
        Color outputColor = Color.LightGray;
        Color errorColor = Color.Red;
        String ticks="";
        String prices = "";
        string[] ticksArray = null;
        string[] pricesArray = null;
        string cossbotPath = "C:\\cossbot";
        private void Load()
        {
            inputField.Select();
            outputField.BackColor = Color.Black;

          //  ProcessStartInfo ps = new ProcessStartInfo("node.exe", "C:\\Users\\Ciprian\\Downloads\\COSSbot-JS-master\\COSSbot-JS-master\\COSSbot\\main.js -i");
            ProcessStartInfo ps = new ProcessStartInfo(cossbotPath+"\\start.bat");

            ps.RedirectStandardInput = true;
            ps.RedirectStandardOutput = true;
            ps.RedirectStandardError = true;
            ps.UseShellExecute = false;
            //ps.Verb = "runas";
            ps.CreateNoWindow = false;
            ps.StandardErrorEncoding = Encoding.ASCII;
            ps.StandardOutputEncoding = Encoding.ASCII;
            ps.WorkingDirectory = cossbotPath;
            try
            {
                p = Process.Start(ps);
                inputStream = p.StandardInput;
                outputStream = p.StandardOutput;
                errorStream = p.StandardError;
                DoReadOutput();
                DoReadError();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }
        }

        void DoReadOutput()
        {
            outputStream.BaseStream.BeginRead(readOutputBuffer, 0, readOutputBuffer.Length, new AsyncCallback(OnReadOutputCompleted), null);
        }

        void OnReadOutputCompleted(IAsyncResult result)
        {
            if (outputStream == null) return;
            if(outputStream.BaseStream == null) return;
            int cbRead = outputStream.BaseStream.EndRead(result);
            ProcessOutput(readOutputBuffer, cbRead);
            DoReadOutput();
        }

        void DoReadError()
        {
            errorStream.BaseStream.BeginRead(readErrorBuffer, 0, readErrorBuffer.Length, new AsyncCallback(OnReadErrorCompleted), null);
        }

        void OnReadErrorCompleted(IAsyncResult result)
        {   if (errorStream == null) return;
            if (errorStream.BaseStream == null) return;
            int cbRead = errorStream.BaseStream.EndRead(result);
            ProcessError(readErrorBuffer, cbRead);
            DoReadError();
        }
        bool firstTime = true;
            private void ProcessOutput(byte[] buffer, int cbRead)
        {
            if(firstTime) System.Threading.Thread.Sleep(2000);
            firstTime = false;
            string text = p.StartInfo.StandardOutputEncoding.GetString(buffer, 0, cbRead);
            this.Invoke((Action)delegate
            {
                try { 
                if (text.StartsWith("TICKSTART")){
                        
                        ticks = "";prices = "";
                        
                        return;
                    }
                if (text.StartsWith("TICKEND")){
                       
                        ticks.Replace("'", ""); prices.Replace("'", "");
                    
                    text += "-"+ticks + prices;
                    return;
                }
                if (text.StartsWith("NOOUT")){
                        processTicks(text);
                         return;
                    }
                this.outputField.SelectionFont = outputFont;
                this.outputField.SelectionColor = Color.White;
                this.outputField.AppendText(text);
                this.outputField.SelectionStart = this.outputField.Text.Length;
                this.outputField.ScrollToCaret();
                DisplayDialog(text);
                updateHistory();    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
                }
            });
        }

        private void updateHistory()
        {
            string line;
            try
            {
                int i = pairsComboBox.SelectedIndex;
                if (i < 0) return;
                int dash = ticksArray[i].IndexOf("-");
                if (dash == -1) return;
                this.resultTextBox.Text = "";
                string coin = ticksArray[i].Substring(0, dash).Trim().ToUpper();
                string reff = ticksArray[i].Substring(dash + 1).Trim().ToUpper();
                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(cossbotPath+"\\pairdata\\" + ticksArray[pairsComboBox.SelectedIndex] + ".json");
                line = file.ReadToEnd();
                if (line != null)
                {
                    line = line.Replace("],", "|");
                    line = line.Replace("]", "");
                    line = line.Replace("[", "");
                    
                    string[] r = line.Split('|');
                    for (int n = 0; n < r.Length; n++)
                    {

                        string[] a = r[n].Split(',');
                        if (a.Length < 2) continue;
                        this.resultTextBox.SelectionColor = Color.Green;
                        line = coin + " amount " + a[1] + ". Price " + a[0] + reff + "\n";
                        this.resultTextBox.AppendText(line);
                        this.resultTextBox.SelectionStart = this.resultTextBox.Text.Length;
                        this.resultTextBox.ScrollToCaret();
                    }
                }

                file.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }
        }

        private void processTicks(string bigText) {
            //Console.WriteLine("processTicks"+bigText);
            using (StringReader sr = new StringReader(bigText))
            {
                string text;
                while ((text = sr.ReadLine()) != null)
                {
                   // Console.WriteLine("!" + text);
                    if (text.StartsWith("TICKSTART"))
                    {

                        continue;
                    }
                    if (text.StartsWith("TICKEND"))
                    {
                        ticks=ticks.Replace("'", ""); prices=prices.Replace("'", "");
                        refreshPairs();
                        //Console.WriteLine("-" + ticks + prices);
                        continue;
                    }
                    if (text.StartsWith("NOOUT"))
                    {
                        int pipe = text.IndexOf("|");
                        if (pipe == -1) return;
                        ticks += text.Substring(5, pipe-5).Trim() + ";";
                        prices += text.Substring(pipe + 1).Trim() + ";";
                       // Console.WriteLine("t" + ticks + prices);
                        continue;
                    }
                }
            }
        }
        private void refreshPairs() {
            ticksArray = ticks.Split(';');
            pricesArray = prices.Split(';');
            pairsComboBox.DataSource= ticksArray;
            pairsComboBox.Refresh();
           // pairsComboBox.SelectedItem = "coss-eth";

        }
        private void ProcessError(byte[] buffer, int cbRead)
        {
            string text = p.StartInfo.StandardErrorEncoding.GetString(buffer, 0, cbRead);
            this.Invoke((Action)delegate
            {
                this.outputField.SelectionFont = errorFont;
                this.outputField.SelectionColor = Color.Red;
                this.outputField.AppendText(text);
                this.outputField.SelectionStart = this.outputField.Text.Length;
                this.outputField.ScrollToCaret();
            });
        }

        private void DisplayDialog(String text) {
            if (text.Contains("Would you like to place a limit buy (1) or market buy (2):"))
            {
                var lst = new List<string>() { "Limit buy", "Market buy" };
                frmDialogcs dlg = new frmDialogcs(lst);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string selected = dlg.selectedString;
                    if (selected == "Limit buy")
                        Send("1");
                    else Send("2");
                }
                return;

            }
            if (text.Contains("QUse COSSbot manually (m), automatic trading (a), or quit (q)"))
            {
                var lst = new List<string>() { "Manual", "Automatic", "Quit" };
                frmDialogcs dlg = new frmDialogcs(lst);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string selected = dlg.selectedString;
                    if (selected == "Manual")
                        Send("m");
                    else {
                        if (selected == "Automatic")
                            Send("a"); 
                        else Send("q");
                    }

                }
                return;

            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
            }
            base.OnKeyDown(e);
        }

        void Send()
        {
            string text = this.inputField.Text+"\n";
            this.inputField.Text = "";
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            if (bytes != null)
            {
                inputStream.BaseStream.Write(bytes, 0, bytes.Length);
                inputStream.Flush();
            }
        }
        void Send(string text)
        {
            text = text + "\n";

            this.outputField.AppendText("!"+text);
            this.outputField.SelectionStart = this.outputField.Text.Length;
            this.outputField.ScrollToCaret();

            this.inputField.Text = "";
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            if (bytes != null)
            {
                inputStream.BaseStream.Write(bytes, 0, bytes.Length);
                inputStream.Flush();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Send();
        }

        

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked) Send("m");
            //else Send("a");
        }

        private void balance_Click(object sender, EventArgs e)
        {
            Send("1");
        }

        
      


        


        private void backButton_Click(object sender, EventArgs e)
        {
            Send("b");
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            outputStream.Close();
            errorStream.Close();
            inputStream.Close();
            p.Close();
            ProcessStartInfo ps = new ProcessStartInfo(cossbotPath+"\\stop.bat");

            ps.WorkingDirectory = cossbotPath;
            try
            {
                p = Process.Start(ps);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }
            try
            {

                p.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }           //Close the current process
            Environment.Exit(0);

        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            outputStream.Close();
            errorStream.Close();
            inputStream.Close();
            p.Close();
            ProcessStartInfo ps = new ProcessStartInfo(cossbotPath+"\\stop.bat");

            ps.WorkingDirectory = cossbotPath;
            try
            {
                p = Process.Start(ps);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }
            //Start process, friendly name is something like MyApp.exe (from current bin directory)
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
            try
            {

                p.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }           //Close the current process
            Environment.Exit(0);

           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cmd_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Send("m");
        }

        private void pairsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            updateFields(pairsComboBox.SelectedIndex);
            updateHistory();
        }
        private void updateFields(int i) {
            priceTextBox.Text = pricesArray[i];
            int dash = ticksArray[i].IndexOf("-");
            if (dash == -1) return;
            string coin = ticksArray[i].Substring(0, dash).Trim().ToUpper();
            string reff = ticksArray[i].Substring(dash+1).Trim().ToUpper();
            coinLabel.Text = "Please enter the current price of "+coin+" in "+reff+":";
            label3.Text = "What is the order size you want COSSbot to make in units of " + coin + ":";
            refCoinLabel.Text = "In order to protect user funds, COSSbot requires a parameter of order size.\n This will prevent COSSbot from making buy/sell orders larger than the specified size.\nUser must ensure that they have adequate funds in " + reff + ".";

        }

        private void startBotButton_Click(object sender, EventArgs e)
        {
            string price = priceTextBox.Text.Trim();
            string pair = ticksArray[pairsComboBox.SelectedIndex];
            string order = orderSize.Text.Trim();
            string percentUp = profitTextBox.Text.Trim();
            string percentDown = costDownTextBox.Text.Trim();
            Send("a");
            System.Threading.Thread.Sleep(1000);
            Send(pair);
            System.Threading.Thread.Sleep(1000);
            Send(order);
            System.Threading.Thread.Sleep(1000);
            Send(price);
            System.Threading.Thread.Sleep(1000);
            Send(percentUp);
            System.Threading.Thread.Sleep(1000);
            Send(percentDown);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void helpButton_Click_1(object sender, EventArgs e)
        {
            Send("h");
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            Send("4");
        }

        private void allTickerDataButton_Click_1(object sender, EventArgs e)
        {
            Send("9");
        }

        private void marketTickerDataButton_Click_1(object sender, EventArgs e)
        {
            Send("8");
        }

        private void checkMarketParirsButton_Click_1(object sender, EventArgs e)
        {
            Send("7");
        }

        private void orderHistoryButton_Click_1(object sender, EventArgs e)
        {
            Send("6");
        }

        private void pairDepthButton_Click_1(object sender, EventArgs e)
        {
            Send("5");
        }

        private void balanceButton_Click(object sender, EventArgs e)
        {
            Send("1");
        }

        private void sellButton_Click_1(object sender, EventArgs e)
        {
            Send("3");
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            Send("2");
        }

        private void Cmd_FormClosing(object sender, FormClosingEventArgs e)
        {
            outputStream.Close();
            errorStream.Close();
            inputStream.Close();
            p.Close();
            ProcessStartInfo ps = new ProcessStartInfo(cossbotPath + "\\stop.bat");

            ps.WorkingDirectory = cossbotPath;
            try
            {
                p = Process.Start(ps);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }
            try
            {

                p.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Just in case there's a problem on your end. :-)
            }           //Close the current process
            Environment.Exit(0);

        }
    }



    public partial class frmDialogcs : Form
    {
        public string selectedString;

      
        public frmDialogcs(IList<string> lst)
        {
            
            for (int i = 0; i < lst.Count; i++)
            {
                RadioButton rdb = new RadioButton();
                rdb.Text = lst[i];
                rdb.Size = new Size(100, 30);
                this.Controls.Add(rdb);
                rdb.Location = new Point(20, 20 + 35 * i);
                rdb.CheckedChanged += (s, ee) =>
                {
                    var r = s as RadioButton;
                    if (r.Checked)
                        this.selectedString = r.Text;
                };
                
            }
            Button ok = new System.Windows.Forms.Button();
            ok.Text = "OK";
            ok.Size = new Size(80, 30);
            this.Controls.Add(ok);
            ok.Click += new System.EventHandler(btnOK_Click);
            ok.Location = new Point(30, 30 + 35 * lst.Count);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
    
}
