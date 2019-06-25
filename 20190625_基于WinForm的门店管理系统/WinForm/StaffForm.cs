using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _20190625_基于WinForm的门店管理系统.DAL;
using _20190625_基于WinForm的门店管理系统.Model;

namespace _20190625_基于WinForm的门店管理系统.WinForm
{
    public partial class StaffForm : Skin_DevExpress
    {

        /// <summary>
        /// 填满组合框
        /// </summary>
        public void FillComboBox()
        {
            List<Store> list = StoreDAL.FindList(new Store(), new List<string>());
            comboBox2.DataSource = list;
            comboBox2.DisplayMember = "StoreName"; //设置要显示的List元素中的属性
        }


        /// <summary>
        /// 显示数据网格控件
        /// </summary>
        public void ShowDataGird()
        {
            this.skinDataGridView1.DataSource = null;
            this.skinDataGridView1.Columns.Clear(); //清理按钮和集合


            List<View_Staff_Store> list = View_Staff_StoreDAL.FindList(new View_Staff_Store(), new List<string>());
            skinDataGridView1.DataSource = list;

            skinDataGridView1.Columns["Staff_Id"].HeaderText = "员工ID";
            skinDataGridView1.Columns["Staff_Name"].HeaderText = "姓名";
            skinDataGridView1.Columns["Staff_Gender"].HeaderText = "员工性别";
            skinDataGridView1.Columns["Store_Id"].HeaderText = "门店ID";
            skinDataGridView1.Columns["Store_Name"].HeaderText = "门店名称";

            skinDataGridView1.Columns["Staff_Id"].ReadOnly = true;
            skinDataGridView1.Columns["Store_Name"].ReadOnly = true;

            DataGridViewButtonColumn col_Btn_alter = new DataGridViewButtonColumn();
            col_Btn_alter.Name = "colBtn_alter";
            col_Btn_alter.HeaderText = "";
            col_Btn_alter.DefaultCellStyle.NullValue = "修改员工资料";
            skinDataGridView1.Columns.Add(col_Btn_alter);

            DataGridViewButtonColumn col_Btn_Drop = new DataGridViewButtonColumn();
            col_Btn_Drop.Name = "colBtn_drop";
            col_Btn_Drop.HeaderText = "";
            col_Btn_Drop.DefaultCellStyle.NullValue = "删除";
            skinDataGridView1.Columns.Add(col_Btn_Drop);
        }

        /// <summary>
        /// 构造器
        /// </summary>
        public StaffForm()
        {
            InitializeComponent();
            FillComboBox();
            ShowDataGird();
        }

        /// <summary>
        /// 点击录入员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBoxEx.Show("请填写员工姓名", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Staff model = new Staff();
            model.StaffName = textBox1.Text;
            model.Gender = comboBox1.Text;
            model.Store_Id = StoreDAL.FindModel(new Store(comboBox2.Text.ToString(), null, null), new List<string>() { "StoreName" }).Id;
            if (StaffDAL.Add(model)) { ShowDataGird(); MessageBoxEx.Show("新增员工成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void SkinDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "colBtn_drop") {
                Staff model = new Staff();
                model.Id = Convert.ToInt32(skinDataGridView1.Rows[e.RowIndex].Cells["staff_id"].Value);
                if (StaffDAL.Drop(model, new List<string>() { "id" })) { ShowDataGird(); MessageBoxEx.Show("删除成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "colBtn_alter") {
                Staff model = new Staff();
                model.Id = Convert.ToInt32(skinDataGridView1.Rows[e.RowIndex].Cells["staff_id"].Value);
                model.StaffName = skinDataGridView1.Rows[e.RowIndex].Cells["staff_name"].Value.ToString();
                model.Store_Id = Convert.ToInt32(skinDataGridView1.Rows[e.RowIndex].Cells["Store_Id"].Value);
                model.Gender = skinDataGridView1.Rows[e.RowIndex].Cells["staff_Gender"].Value.ToString();
                if (StoreDAL.FindModel(new Store(model.Store_Id), new List<string>() { "id" }) == null) { MessageBoxEx.Show("修改失败，不存在此门店", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (StaffDAL.AlterByPK(model, "id")) { ShowDataGird(); MessageBoxEx.Show("修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

        }
    }
}
