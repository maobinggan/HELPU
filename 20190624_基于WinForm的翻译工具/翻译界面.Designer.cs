namespace _20190624_基于WinForm的翻译工具
{
    partial class 翻译界面
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
            if (disposing && (components != null)) {
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查看个人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在状态栏显示日期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FloralWhite;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(629, 83);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "汉语->英语",
            "英语->汉语"});
            this.comboBox1.Location = new System.Drawing.Point(21, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "汉语->英语";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(653, 46);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 83);
            this.vScrollBar1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(51, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 185);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入文本";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vScrollBar2);
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new System.Drawing.Point(51, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 146);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "翻译结果";
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(653, 46);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 83);
            this.vScrollBar2.TabIndex = 3;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(21, 34);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(629, 83);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看个人信息ToolStripMenuItem,
            this.返回ToolStripMenuItem,
            this.在状态栏显示日期ToolStripMenuItem,
            this.返回ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查看个人信息ToolStripMenuItem
            // 
            this.查看个人信息ToolStripMenuItem.Name = "查看个人信息ToolStripMenuItem";
            this.查看个人信息ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.查看个人信息ToolStripMenuItem.Text = "查看当前用户";
            this.查看个人信息ToolStripMenuItem.Click += new System.EventHandler(this.查看个人信息ToolStripMenuItem_Click);
            // 
            // 返回ToolStripMenuItem
            // 
            this.返回ToolStripMenuItem.Name = "返回ToolStripMenuItem";
            this.返回ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.返回ToolStripMenuItem.Text = "修改用户名";
            this.返回ToolStripMenuItem.Click += new System.EventHandler(this.返回ToolStripMenuItem_Click);
            // 
            // 在状态栏显示日期ToolStripMenuItem
            // 
            this.在状态栏显示日期ToolStripMenuItem.Name = "在状态栏显示日期ToolStripMenuItem";
            this.在状态栏显示日期ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.在状态栏显示日期ToolStripMenuItem.Text = "显示日期";
            this.在状态栏显示日期ToolStripMenuItem.Click += new System.EventHandler(this.在状态栏显示日期ToolStripMenuItem_Click);
            // 
            // 返回ToolStripMenuItem1
            // 
            this.返回ToolStripMenuItem1.Name = "返回ToolStripMenuItem1";
            this.返回ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.返回ToolStripMenuItem1.Text = "返回";
            this.返回ToolStripMenuItem1.Click += new System.EventHandler(this.返回ToolStripMenuItem1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "翻译！";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // 翻译界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(848, 499);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "翻译界面";
            this.Text = "翻译界面";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看个人信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 返回ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在状态栏显示日期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 返回ToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
    }
}