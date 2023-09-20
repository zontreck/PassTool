namespace PassTool.GUI
{
    partial class PassTool
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            trackBar1 = new System.Windows.Forms.TrackBar();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            trackBar2 = new System.Windows.Forms.TrackBar();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            listBox1 = new System.Windows.Forms.ListBox();
            label5 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            textBox3 = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            button3 = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(807, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Card Characters", 20.2499981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(230, 32);
            label1.TabIndex = 1;
            label1.Text = "Cipher Text:";
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox1.Location = new System.Drawing.Point(248, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(540, 43);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Card Characters", 20.2499981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(12, 141);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 32);
            label2.TabIndex = 3;
            label2.Text = "Seed:";
            // 
            // trackBar1
            // 
            trackBar1.Location = new System.Drawing.Point(158, 141);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(511, 45);
            trackBar1.TabIndex = 4;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown1.Location = new System.Drawing.Point(675, 141);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(120, 29);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // trackBar2
            // 
            trackBar2.Location = new System.Drawing.Point(158, 210);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new System.Drawing.Size(511, 45);
            trackBar2.TabIndex = 6;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown2.Location = new System.Drawing.Point(675, 210);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(120, 29);
            numericUpDown2.TabIndex = 7;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Card Characters", 20.2499981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(12, 210);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(140, 32);
            label3.TabIndex = 8;
            label3.Text = "Length:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Card Characters", 20.2499981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(12, 406);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(176, 32);
            label4.TabIndex = 9;
            label4.Text = "Password:";
            // 
            // textBox2
            // 
            textBox2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox2.Location = new System.Drawing.Point(248, 406);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(421, 43);
            textBox2.TabIndex = 10;
            textBox2.Text = "PLACEHOLDER";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new System.Drawing.Point(466, 261);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(259, 94);
            listBox1.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Card Characters", 20.2499981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(12, 261);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(194, 32);
            label5.TabIndex = 12;
            label5.Text = "BLACKLIST:";
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(731, 261);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(64, 32);
            button1.TabIndex = 13;
            button1.Text = "DEL";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox3.Location = new System.Drawing.Point(212, 261);
            textBox3.MaxLength = 1;
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(85, 35);
            textBox3.TabIndex = 14;
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(314, 261);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(69, 35);
            button2.TabIndex = 15;
            button2.Text = "ADD";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(12, 491);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(783, 41);
            progressBar1.Step = 1;
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 16;
            progressBar1.Value = 50;
            // 
            // button3
            // 
            button3.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.Location = new System.Drawing.Point(675, 406);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(113, 43);
            button3.TabIndex = 17;
            button3.Text = "Copy";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // PassTool
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(807, 544);
            Controls.Add(button3);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDown2);
            Controls.Add(trackBar2);
            Controls.Add(numericUpDown1);
            Controls.Add(trackBar1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "PassTool";
            Opacity = 0.9D;
            RightToLeft = System.Windows.Forms.RightToLeft.No;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Password Tool";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
    }
}