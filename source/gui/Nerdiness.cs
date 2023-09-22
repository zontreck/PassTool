using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronBarCode;

namespace PassTool.GUI
{
    public partial class Nerdiness : Form
    {
        PassTool mainForm;
        public Nerdiness(PassTool main)
        {
            mainForm = main;
            InitializeComponent();


            RefreshBarcodes();
        }

        public void RefreshBarcodes()
        {
            try
            {

                pictureBox1.Image = BarcodeWriter.CreateBarcode(Encoding.UTF8.GetBytes(mainForm.textBox2.Text), BarcodeEncoding.Code128).Image;

                pictureBox2.Image = BarcodeWriter.CreateBarcode(Encoding.UTF8.GetBytes(mainForm.textBox2.Text), BarcodeEncoding.QRCode).Image;

                pictureBox3.Image = BarcodeWriter.CreateBarcode(Encoding.UTF8.GetBytes(mainForm.textBox2.Text), BarcodeEncoding.DataMatrix).Image;
            }
            catch (Exception e)
            {

            }
        }

    }
}
