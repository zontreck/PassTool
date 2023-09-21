using System;

namespace PassTool.GUI
{
    partial class PassTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private static object[] DEFAULT_BLACKLIST = new object[] { ",", ".", "'", "\"", "/", "\\", "|" };
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassTool));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveLastLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveBlacklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            saveSeedNotRecommendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            seedBar = new System.Windows.Forms.ProgressBar();
            seedBox = new System.Windows.Forms.TextBox();
            lengthBox = new System.Windows.Forms.TextBox();
            lengthBar = new System.Windows.Forms.ProgressBar();
            menuStrip1.SuspendLayout();
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
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { optionsToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveLastLengthToolStripMenuItem, saveBlacklistToolStripMenuItem, toolStripSeparator1, resetToolStripMenuItem, toolStripSeparator2, saveSeedNotRecommendedToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // saveLastLengthToolStripMenuItem
            // 
            saveLastLengthToolStripMenuItem.Checked = true;
            saveLastLengthToolStripMenuItem.CheckOnClick = true;
            saveLastLengthToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            saveLastLengthToolStripMenuItem.Name = "saveLastLengthToolStripMenuItem";
            saveLastLengthToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            saveLastLengthToolStripMenuItem.Text = "Save Last Length";
            // 
            // saveBlacklistToolStripMenuItem
            // 
            saveBlacklistToolStripMenuItem.Checked = true;
            saveBlacklistToolStripMenuItem.CheckOnClick = true;
            saveBlacklistToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            saveBlacklistToolStripMenuItem.Name = "saveBlacklistToolStripMenuItem";
            saveBlacklistToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            saveBlacklistToolStripMenuItem.Text = "Save Blacklist";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // saveSeedNotRecommendedToolStripMenuItem
            // 
            saveSeedNotRecommendedToolStripMenuItem.CheckOnClick = true;
            saveSeedNotRecommendedToolStripMenuItem.Name = "saveSeedNotRecommendedToolStripMenuItem";
            saveSeedNotRecommendedToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            saveSeedNotRecommendedToolStripMenuItem.Text = "Save Seed (Not Recommended)";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            listBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Location = new System.Drawing.Point(389, 261);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new System.Drawing.Size(145, 124);
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
            button1.Location = new System.Drawing.Point(314, 302);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(69, 39);
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
            progressBar1.Location = new System.Drawing.Point(12, 500);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(783, 41);
            progressBar1.Step = 1;
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
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 544);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(807, 22);
            statusStrip1.TabIndex = 18;
            statusStrip1.Text = "statusStrip1";
            // 
            // seedBar
            // 
            seedBar.Location = new System.Drawing.Point(165, 142);
            seedBar.Name = "seedBar";
            seedBar.Size = new System.Drawing.Size(468, 32);
            seedBar.TabIndex = 19;
            seedBar.MouseClick += seedBar_MouseClick;
            // 
            // seedBox
            // 
            seedBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            seedBox.Location = new System.Drawing.Point(639, 142);
            seedBox.Name = "seedBox";
            seedBox.Size = new System.Drawing.Size(156, 35);
            seedBox.TabIndex = 20;
            seedBox.Leave += seedBox_Leave;
            // 
            // lengthBox
            // 
            lengthBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lengthBox.Location = new System.Drawing.Point(639, 208);
            lengthBox.Name = "lengthBox";
            lengthBox.Size = new System.Drawing.Size(156, 35);
            lengthBox.TabIndex = 22;
            lengthBox.Leave += lengthBox_Leave;
            // 
            // lengthBar
            // 
            lengthBar.Location = new System.Drawing.Point(165, 208);
            lengthBar.Name = "lengthBar";
            lengthBar.Size = new System.Drawing.Size(468, 32);
            lengthBar.TabIndex = 21;
            lengthBar.MouseClick += lengthBar_MouseClick;
            // 
            // PassTool
            // 
            ClientSize = new System.Drawing.Size(807, 566);
            Controls.Add(lengthBox);
            Controls.Add(lengthBar);
            Controls.Add(seedBox);
            Controls.Add(seedBar);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "PassTool";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Password Tool";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ProgressBar seedBar;
        private System.Windows.Forms.TextBox seedBox;
        private System.Windows.Forms.TextBox lengthBox;
        private System.Windows.Forms.ProgressBar lengthBar;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLastLengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBlacklistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveSeedNotRecommendedToolStripMenuItem;
    }
}