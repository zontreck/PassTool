namespace PassTool.GUI
{
    partial class Activation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Activation));
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            licenseValidity = new System.Windows.Forms.Button();
            activateButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox1.Location = new System.Drawing.Point(12, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(575, 39);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(98, 25);
            label1.TabIndex = 1;
            label1.Text = "Serial Key:";
            // 
            // licenseValidity
            // 
            licenseValidity.AutoEllipsis = true;
            licenseValidity.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            licenseValidity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            licenseValidity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            licenseValidity.Location = new System.Drawing.Point(550, 37);
            licenseValidity.Name = "licenseValidity";
            licenseValidity.Size = new System.Drawing.Size(37, 39);
            licenseValidity.TabIndex = 2;
            licenseValidity.UseVisualStyleBackColor = false;
            // 
            // activateButton
            // 
            activateButton.Enabled = false;
            activateButton.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            activateButton.Location = new System.Drawing.Point(88, 108);
            activateButton.Name = "activateButton";
            activateButton.Size = new System.Drawing.Size(114, 47);
            activateButton.TabIndex = 3;
            activateButton.Text = "Activate";
            activateButton.UseVisualStyleBackColor = true;
            activateButton.Click += activateButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cancelButton.Location = new System.Drawing.Point(352, 108);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(114, 47);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // Activation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(599, 167);
            Controls.Add(cancelButton);
            Controls.Add(activateButton);
            Controls.Add(licenseValidity);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Activation";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            Text = "Activation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button licenseValidity;
        private System.Windows.Forms.Button activateButton;
        private System.Windows.Forms.Button cancelButton;
    }
}