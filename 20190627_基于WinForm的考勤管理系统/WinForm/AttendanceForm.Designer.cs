namespace _20190627_基于WinForm的考勤管理系统.WinForm
{
    partial class AttendanceForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageinfo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPageadd = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonadd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageedit = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tabPagedel = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageinfo.SuspendLayout();
            this.tabPageadd.SuspendLayout();
            this.tabPageedit.SuspendLayout();
            this.tabPagedel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageinfo);
            this.tabControl1.Controls.Add(this.tabPageadd);
            this.tabControl1.Controls.Add(this.tabPageedit);
            this.tabControl1.Controls.Add(this.tabPagedel);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 143);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPageinfo
            // 
            this.tabPageinfo.Controls.Add(this.label2);
            this.tabPageinfo.Controls.Add(this.button1);
            this.tabPageinfo.Controls.Add(this.label1);
            this.tabPageinfo.Controls.Add(this.textBox1);
            this.tabPageinfo.Controls.Add(this.comboBox1);
            this.tabPageinfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageinfo.Name = "tabPageinfo";
            this.tabPageinfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageinfo.Size = new System.Drawing.Size(773, 117);
            this.tabPageinfo.TabIndex = 0;
            this.tabPageinfo.Text = "查询考勤记录";
            this.tabPageinfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F);
            this.label2.Location = new System.Drawing.Point(152, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "查询，查询条件：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "关键字查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "按";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(367, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 26);
            this.textBox1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "员工姓名",
            "性别"});
            this.comboBox1.Location = new System.Drawing.Point(59, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "员工姓名";
            // 
            // tabPageadd
            // 
            this.tabPageadd.Controls.Add(this.comboBox2);
            this.tabPageadd.Controls.Add(this.dateTimePicker1);
            this.tabPageadd.Controls.Add(this.buttonadd);
            this.tabPageadd.Controls.Add(this.label10);
            this.tabPageadd.Controls.Add(this.label4);
            this.tabPageadd.Controls.Add(this.textBox2);
            this.tabPageadd.Controls.Add(this.label3);
            this.tabPageadd.Location = new System.Drawing.Point(4, 22);
            this.tabPageadd.Name = "tabPageadd";
            this.tabPageadd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageadd.Size = new System.Drawing.Size(773, 117);
            this.tabPageadd.TabIndex = 1;
            this.tabPageadd.Text = "添加考勤记录";
            this.tabPageadd.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBox2.Location = new System.Drawing.Point(259, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(62, 20);
            this.comboBox2.TabIndex = 24;
            this.comboBox2.Text = "男";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(413, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 21);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(407, 60);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(150, 42);
            this.buttonadd.TabIndex = 22;
            this.buttonadd.Text = "添加";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.Buttonadd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(342, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "考勤时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "员工性别：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(67, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "员工姓名：";
            // 
            // tabPageedit
            // 
            this.tabPageedit.Controls.Add(this.textBox3);
            this.tabPageedit.Controls.Add(this.button3);
            this.tabPageedit.Controls.Add(this.button2);
            this.tabPageedit.Controls.Add(this.textBox10);
            this.tabPageedit.Controls.Add(this.label14);
            this.tabPageedit.Controls.Add(this.label15);
            this.tabPageedit.Controls.Add(this.textBox11);
            this.tabPageedit.Controls.Add(this.label16);
            this.tabPageedit.Controls.Add(this.textBox17);
            this.tabPageedit.Controls.Add(this.label24);
            this.tabPageedit.Location = new System.Drawing.Point(4, 22);
            this.tabPageedit.Name = "tabPageedit";
            this.tabPageedit.Size = new System.Drawing.Size(773, 117);
            this.tabPageedit.TabIndex = 2;
            this.tabPageedit.Text = "修改考勤记录";
            this.tabPageedit.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(197, 81);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(58, 21);
            this.textBox3.TabIndex = 40;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(501, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 45;
            this.button3.Text = "提交修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "加载数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(350, 81);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(125, 21);
            this.textBox10.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(279, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "考勤日期：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(155, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 40;
            this.label15.Text = "性别：";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(77, 81);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(58, 21);
            this.textBox11.TabIndex = 39;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 38;
            this.label16.Text = "员工姓名：";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(71, 29);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 21);
            this.textBox17.TabIndex = 23;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 32);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 22;
            this.label24.Text = "考勤ID：";
            // 
            // tabPagedel
            // 
            this.tabPagedel.Controls.Add(this.button4);
            this.tabPagedel.Controls.Add(this.textBox18);
            this.tabPagedel.Controls.Add(this.label25);
            this.tabPagedel.Location = new System.Drawing.Point(4, 22);
            this.tabPagedel.Name = "tabPagedel";
            this.tabPagedel.Size = new System.Drawing.Size(773, 117);
            this.tabPagedel.TabIndex = 3;
            this.tabPagedel.Text = "删除考勤记录";
            this.tabPagedel.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(480, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 38);
            this.button4.TabIndex = 26;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // textBox18
            // 
            this.textBox18.Font = new System.Drawing.Font("宋体", 20F);
            this.textBox18.Location = new System.Drawing.Point(164, 35);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(292, 38);
            this.textBox18.TabIndex = 25;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 20F);
            this.label25.Location = new System.Drawing.Point(26, 38);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(121, 27);
            this.label25.TabIndex = 24;
            this.label25.Text = "考勤ID：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 161);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(773, 277);
            this.dataGridView1.TabIndex = 11;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Name = "AttendanceForm";
            this.Text = "AttendanceForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPageinfo.ResumeLayout(false);
            this.tabPageinfo.PerformLayout();
            this.tabPageadd.ResumeLayout(false);
            this.tabPageadd.PerformLayout();
            this.tabPageedit.ResumeLayout(false);
            this.tabPageedit.PerformLayout();
            this.tabPagedel.ResumeLayout(false);
            this.tabPagedel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageinfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPageedit;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabPage tabPagedel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tabPageadd;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}