using TP.CS.EventsBus;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP.CS.Registry;

namespace PassTool.GUI
{
    public partial class PassTool : Form
    {
        public bool Ready;
        public Point MousePosition;

        public PassTool()
        {
            InitializeComponent();

            seedBar.Maximum = int.MaxValue;
            seedBar.Minimum = 0;
            lengthBar.Minimum = 1;
            lengthBar.Maximum = 40;



            Random rng = new Random();

            seedBar.Value = rng.Next(0, 0xFFFF);
            seedBox.Text = $"{seedBar.Value}";
            lengthBar.Value = 5;
            lengthBox.Text = "5";
            progressBar1.Value = 0;

            Shown += PassTool_Shown;
            Invalidated += PassTool_Invalidated;

            Paint += PassTool_Paint;
            MouseMove += PassTool_MouseMove;


            GUISettings.SettingsLoad(Program.Hive);

            int len = GUISettings.Instance.codec.LastLength.Value;
            lengthBar.Value = len;
            progressBar1.Maximum = len;
            lengthBox.Text = len.ToString();

            foreach(string X in GUISettings.Instance.codec.Blacklist)
            {
                listBox1.Items.Add(X);
                CipherPassword.BLACKLIST.Add(X[0]);
                
            }
        }

        private void PassTool_MouseMove(object sender, MouseEventArgs e)
        {
            MousePosition = e.Location;

            statusStrip1.Text = $"MouseX: {MousePosition.X}; MouseY: {MousePosition.Y}";
        }

        private void PassTool_Paint(object sender, PaintEventArgs e)
        {
            Ready = true;
        }

        private void PassTool_Invalidated(object sender, InvalidateEventArgs e)
        {
            Ready = false;
        }

        private void PassTool_Shown(object sender, EventArgs e)
        {
            Ready = true;
            recalculate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            recalculate();
        }

        private void recalculate()
        {

            if (Ready)
                textBox2.Text = CipherPassword.Manipulate(textBox1.Text, (long)seedBar.Value, (int)lengthBar.Value);
            /**/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**/
            if (listBox1.SelectedItem != null)
            {
                string item = (string)listBox1.SelectedItem;
                listBox1.Items.Remove(listBox1.SelectedItem);


                CipherPassword.BLACKLIST.Remove(item[0]);
                GUISettings.Instance.codec.Blacklist.Remove(item);

                listBox1.SelectedItem = null;
                recalculate();
            }
            /**/
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /**/
            if (textBox3.TextLength == 0) return;

            listBox1.Items.Add(textBox3.Text);
            char item = (char)textBox3.Text[0];

            textBox3.Text = "";

            CipherPassword.BLACKLIST.Add((long)item);
            GUISettings.Instance.codec.Blacklist.Add(textBox3.Text);
            

            recalculate();
            /**/
        }

        [Subscribe(Priority.Very_High)]
        public static void onCipherTick(CipherTickEvent e)
        {
            /**/
            if (Program.passTool != null && Program.passTool.textBox2 != null)
            {

                Program.passTool.textBox2.Text = e.Pass;
                Program.passTool.progressBar1.Value = e.Pass.Length;

                if (Program.passTool.Ready)
                    Program.passTool.Refresh();
            }
            /**/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text, TextDataFormat.Text);

            MessageBox.Show("Password copied to clipboard");
        }

        private void seedBar_MouseClick(object sender, MouseEventArgs e)
        {
            MousePosition = e.Location;
            // Get the percentage value for where the click occured.

            int percent = getPercentForBar(seedBar);
            int val = getBarValueByPercent(seedBar, percent);

            seedBar.Value = val;
            seedBox.Text = val.ToString();

            recalculate();
        }

        int getPercentForBar(ProgressBar bar)
        {
            /*
             * 
             * 
             * 
             *          bar
             *          
             *          1. Get location of bar
             *          2. Calculate the X offset of the left side of the bar
             *              2a. This can be done by taking the bar location - width/2
             *          3. Take the LeftPosition and subtract it from the Mouse X.
             *          
             *              
             */
            int percent = 0;


            percent = MousePosition.X * 100 / bar.Size.Width;

            return percent;
        }

        int getBarValueByPercent(ProgressBar bar, int percent)
        {
            long val = percent;
            val *= bar.Maximum;
            val /= 100;


            return (int)val;
        }

        private void lengthBar_MouseClick(object sender, MouseEventArgs e)
        {

            MousePosition = e.Location;
            // Get the percentage value for where the click occured.

            int percent = getPercentForBar(lengthBar);
            int val = getBarValueByPercent(lengthBar, percent);

            lengthBar.Value = val;
            lengthBox.Text = val.ToString();

            progressBar1.Value = 0;
            progressBar1.Maximum = val;

            GUISettings.Instance.codec.LastLength.setInt32(val);

            recalculate();
        }

        private void seedBox_Leave(object sender, EventArgs e)
        {
            seedBar.Value = int.Parse(seedBox.Text);
            recalculate();
        }

        private void lengthBox_Leave(object sender, EventArgs e)
        {
            lengthBar.Value = int.Parse(lengthBox.Text);

            progressBar1.Value = 0;
            progressBar1.Maximum = lengthBar.Value;

            GUISettings.Instance.codec.LastLength.setInt32(lengthBar.Value);
            recalculate();
        }
    }
}
