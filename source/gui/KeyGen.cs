using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP.CS.Registry;

namespace PassTool.GUI
{
    public partial class KeyGen : Form
    {
        public Licensing lic = new Licensing();
        public KeyGen()
        {
            InitializeComponent();


            lic.TypeOfKey = Licensing.KeyType.Customer;

            checkBox1.Checked = true;
            lic.B64 = false;




            textBox1.Text = $"{lic}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;

                lic.TypeOfKey = Licensing.KeyType.Customer;

                textBox1.Text = $"{lic}";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {

                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;

                lic.TypeOfKey = Licensing.KeyType.Support;

                textBox1.Text = $"{lic}";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox5.Checked = false;

                lic.TypeOfKey = Licensing.KeyType.Patron;

                textBox1.Text = $"{lic}";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            lic.Name = textBox3.Text;

            textBox1.Text = $"{lic}";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lic.Expiry = short.Parse(textBox2.Text);

            }
            catch (Exception ex)
            {
                lic.Expiry = -1;
            }

            textBox1.Text = $"{lic}";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            lic.B64 = checkBox4.Checked;
            textBox1.Text = $"{lic}";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox5.Checked)
            {

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;

                lic.TypeOfKey = Licensing.KeyType.Developer;

                textBox1.Text = $"{lic}";
            }
        }
    }
}
