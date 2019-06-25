using _20190625_基于WinForm的门店管理系统.DAL;
using _20190625_基于WinForm的门店管理系统.Model;
using CCWin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190625_基于WinForm的门店管理系统.WinForm
{
    class StoreForm : Skin_DevExpress
    {

        /// <summary>
        /// 显示数据网格控件
        /// </summary>
        public void ShowDataGird()
        {
            this.skinDataGridView1.DataSource = null;
            this.skinDataGridView1.Columns.Clear(); //清理按钮和集合


            List<Store> list = StoreDAL.FindList(new Store(), new List<string>());
            skinDataGridView1.DataSource = list;

            skinDataGridView1.Columns["storeName"].HeaderText = "门店名";
            skinDataGridView1.Columns["storeAddr"].HeaderText = "门店地址";
            skinDataGridView1.Columns["storeMaster"].HeaderText = "店长";

            skinDataGridView1.Columns["id"].Visible = false;

            DataGridViewButtonColumn col_Btn_alter = new DataGridViewButtonColumn();
            col_Btn_alter.Name = "colBtn_alter";
            col_Btn_alter.HeaderText = "";
            col_Btn_alter.DefaultCellStyle.NullValue = "修改";
            skinDataGridView1.Columns.Add(col_Btn_alter);

            DataGridViewButtonColumn col_Btn_Drop = new DataGridViewButtonColumn();
            col_Btn_Drop.Name = "colBtn_drop";
            col_Btn_Drop.HeaderText = "";
            col_Btn_Drop.DefaultCellStyle.NullValue = "删除";
            skinDataGridView1.Columns.Add(col_Btn_Drop);
        }


        public StoreForm()
        {
            InitializeComponent();
            ShowDataGird();
        }

















        private CCWin.SkinControl.SkinButton btnAbout;
        private System.ComponentModel.IContainer components;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAbout = new CCWin.SkinControl.SkinButton();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.skinDataGridView1 = new CCWin.SkinControl.SkinDataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.btnAbout.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAbout.DownBack = null;
            this.btnAbout.Location = new System.Drawing.Point(65, 300);
            this.btnAbout.MouseBack = null;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.NormlBack = null;
            this.btnAbout.Size = new System.Drawing.Size(121, 35);
            this.btnAbout.TabIndex = 15;
            this.btnAbout.Text = "新增门店";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(62, 251);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(44, 17);
            this.skinLabel3.TabIndex = 14;
            this.skinLabel3.Text = "店长：";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(38, 185);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(68, 17);
            this.skinLabel2.TabIndex = 13;
            this.skinLabel2.Text = "门店地址：";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(38, 115);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(68, 17);
            this.skinLabel1.TabIndex = 12;
            this.skinLabel1.Text = "门店名称：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 21);
            this.textBox1.TabIndex = 11;
            // 
            // skinDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.skinDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.skinDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView1.ColumnFont = null;
            this.skinDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.skinDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView1.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.skinDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.skinDataGridView1.EnableHeadersVisualStyles = false;
            this.skinDataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.skinDataGridView1.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinDataGridView1.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView1.Location = new System.Drawing.Point(259, 90);
            this.skinDataGridView1.Name = "skinDataGridView1";
            this.skinDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.skinDataGridView1.RowTemplate.Height = 23;
            this.skinDataGridView1.Size = new System.Drawing.Size(578, 245);
            this.skinDataGridView1.TabIndex = 10;
            this.skinDataGridView1.TitleBack = null;
            this.skinDataGridView1.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView1.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.skinDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SkinDataGridView1_CellContentClick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 184);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(127, 21);
            this.textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(112, 251);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(127, 21);
            this.textBox3.TabIndex = 17;
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(844, 430);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.skinDataGridView1);
            this.Name = "StoreForm";
            this.Text = "门店管理";
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 点击新增门店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") { MessageBoxEx.Show("请填写完整信息", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Store model = new Store();
            model.StoreName = textBox1.Text;
            model.StoreAddr = textBox2.Text;
            model.StoreMaster = textBox3.Text;
            if (StoreDAL.Add(model)) { ShowDataGird(); MessageBoxEx.Show("添加门店成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void SkinDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "colBtn_drop") {
                Store model = new Store();
                model.Id = Convert.ToInt32(skinDataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                if (StoreDAL.Drop(model, new List<string>() { "id" })) { ShowDataGird(); MessageBoxEx.Show("删除成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "colBtn_alter") {
                Store model = new Store();
                model.Id = Convert.ToInt32(skinDataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                model.StoreName = skinDataGridView1.Rows[e.RowIndex].Cells["StoreName"].Value.ToString();
                model.StoreMaster = skinDataGridView1.Rows[e.RowIndex].Cells["StoreMaster"].Value.ToString();
                if (StoreDAL.AlterByPK(model, "id")) { ShowDataGird(); MessageBoxEx.Show("修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
