using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassTool.GUI
{
    public partial class PassTool : Form
    {
        private About abt = new About();


        public PassTool()
        {
            InitializeComponent();

            trackBar1.Maximum = int.MaxValue;
            trackBar1.Minimum = int.MinValue;
            numericUpDown2.Maximum = 40;
            numericUpDown2.Minimum = 1;
            numericUpDown1.Maximum = int.MaxValue;
            numericUpDown1.Minimum = int.MinValue;

            trackBar2.Maximum = 40;
            trackBar2.Minimum = 1;



            Random rng = new Random();
            trackBar1.Value = rng.Next(0, 0xFFFF);

            numericUpDown1.Value = trackBar1.Value;
            numericUpDown2.Value = trackBar2.Value;


        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abt = new About();
            abt.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            recalculate();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
            recalculate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = (int)numericUpDown2.Value;
            progressBar1.Maximum = trackBar2.Value;
            recalculate();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;
            progressBar1.Maximum = trackBar2.Value;
            recalculate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            recalculate();
        }

        private void recalculate()
        {

            textBox2.Text = CipherPassword.Manipulate(textBox1.Text, (long)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);


                char item = (char)listBox1.SelectedItem;
                CipherPassword.BLACKLIST.Remove((long)item);

                listBox1.SelectedItem = null;
                recalculate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.TextLength == 0) return;

            listBox1.Items.Add(textBox3.Text);
            char item = (char)textBox3.Text[0];
            textBox3.Text = "";


            CipherPassword.BLACKLIST.Add((long)item);
            recalculate();
        }
    }
}
