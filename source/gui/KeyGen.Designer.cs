namespace PassTool.GUI
{
    partial class KeyGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyGen));
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            checkBox4 = new System.Windows.Forms.CheckBox();
            panel1 = new System.Windows.Forms.Panel();
            textBox4 = new System.Windows.Forms.TextBox();
            checkBox5 = new System.Windows.Forms.CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 316);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(334, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            label1.Location = new System.Drawing.Point(12, 276);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 25);
            label1.TabIndex = 1;
            label1.Text = "Serial:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            label2.Location = new System.Drawing.Point(12, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(109, 25);
            label2.TabIndex = 3;
            label2.Text = "Expiration:";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(12, 48);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(334, 23);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            label3.Location = new System.Drawing.Point(12, 103);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 25);
            label3.TabIndex = 5;
            label3.Text = "Name:";
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(12, 139);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(334, 23);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            label4.Location = new System.Drawing.Point(12, 165);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(122, 25);
            label4.TabIndex = 6;
            label4.Text = "Type Of Key:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = System.Drawing.Color.Fuchsia;
            checkBox1.Location = new System.Drawing.Point(12, 198);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(78, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Customer";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.ForeColor = System.Drawing.Color.Fuchsia;
            checkBox2.Location = new System.Drawing.Point(96, 198);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(68, 19);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "Support";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.ForeColor = System.Drawing.Color.Fuchsia;
            checkBox3.Location = new System.Drawing.Point(170, 198);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(61, 19);
            checkBox3.TabIndex = 9;
            checkBox3.Text = "Patron";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.ForeColor = System.Drawing.Color.Fuchsia;
            checkBox4.Location = new System.Drawing.Point(12, 254);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(84, 19);
            checkBox4.TabIndex = 10;
            checkBox4.Text = "Base64 Key";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.DarkGray;
            panel1.Controls.Add(textBox4);
            panel1.Location = new System.Drawing.Point(352, 28);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(341, 320);
            panel1.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.BackColor = System.Drawing.Color.Black;
            textBox4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox4.ForeColor = System.Drawing.Color.Lime;
            textBox4.Location = new System.Drawing.Point(3, 3);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox4.Size = new System.Drawing.Size(335, 308);
            textBox4.TabIndex = 0;
            textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.ForeColor = System.Drawing.Color.Fuchsia;
            checkBox5.Location = new System.Drawing.Point(237, 198);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new System.Drawing.Size(79, 19);
            checkBox5.TabIndex = 12;
            checkBox5.Text = "Developer";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox5_CheckedChanged;
            // 
            // KeyGen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(705, 360);
            Controls.Add(checkBox5);
            Controls.Add(panel1);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "KeyGen";
            Text = "KeyGen";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}