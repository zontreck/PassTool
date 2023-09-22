using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP.CS.EventsBus;
using TP.CS.Registry;

namespace PassTool.GUI
{
    public partial class Activation : Form
    {

        public bool activated;
        public Licensing license;

        public Activation(FontFamily font)
        {
            InitializeComponent();

            activateButton.Font = new Font(font, 16, FontStyle.Bold);
            cancelButton.Font = new Font(font, 16, FontStyle.Bold);

            activated = GUISettings.Instance.codec.Activated.Value;
            if (activated)
            {
                licenseValidity.BackColor = Color.DarkGreen;

                textBox1.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                license = new Licensing(textBox1.Text, false);
                if (license.Expired())
                {
                    licenseValidity.BackColor = Color.DarkRed;
                    activateButton.Enabled = false;

                    Text = "Activation - License is Expired";
                    return;
                }


                licenseValidity.BackColor = Color.DarkGreen;
                activateButton.Enabled = true;

                Text = $"Activation - {license.Name} - {license.RemainingDays()}";
            }
            catch (Exception ex)
            {
                license = null;
                licenseValidity.BackColor = Color.DarkRed;
                activateButton.Enabled = false;

                Text = "Activation - License Invalid";
            }
        }

        private void activateButton_Click(object sender, EventArgs e)
        {
            if(EventBus.Broadcast(new ActivationEvent(license))){
                MessageBox.Show("Activation Rejected");
                textBox1.Text = "";
            }else
            {
                MessageBox.Show("Activation successful");

                Close();
            }
        }
    }

    [Cancellable]
    public class ActivationEvent : Event
    {
        public Licensing license;

        public ActivationEvent(Licensing license)
        {
            this.license = license;
        }
    }
}
