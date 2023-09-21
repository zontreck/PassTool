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
    public partial class About : Form
    {
        public About(FontFamily font)
        {
            InitializeComponent();

            label4.Text = $"{GitVersion.FullVersion}";

            float fontSize = 11;
            label1.Font = new Font(font, fontSize, FontStyle.Regular);
            label2.Font = new Font(font, fontSize, FontStyle.Regular);
            label3.Font = new Font(font, fontSize, FontStyle.Regular);
            label4.Font = new Font(font, fontSize, FontStyle.Regular);
            label5.Font = new Font(font, fontSize, FontStyle.Regular);
            linkLabel1.Font = new Font(font, fontSize, FontStyle.Regular);

            Refresh();
        }
    }
}
