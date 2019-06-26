using _20190626_基于WinForm的仓库管理系统.DAL;
using _20190626_基于WinForm的仓库管理系统.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190626_基于WinForm的仓库管理系统.WinForm
{
    public partial class WorkShopManageForm : Form
    {
        /// <summary>
        /// 显示数据网格控件
        /// </summary>
        public void ShowDataGird()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();

            List<WorkShop> list = WorkShopHelper.FindList(new WorkShop(), new List<string>());
            dataGridView1.DataSource = list;

            dataGridView1.Columns["name"].HeaderText = "车间名";
            dataGridView1.Columns["master"].HeaderText = "车间负责人";
            dataGridView1.Columns["sum"].HeaderText = "车间员工数";

            dataGridView1.Columns["id"].Visible = false;

            DataGridViewButtonColumn col_Btn_alter = new DataGridViewButtonColumn();
            col_Btn_alter.Name = "colBtn_alter";
            col_Btn_alter.HeaderText = "";
            col_Btn_alter.DefaultCellStyle.NullValue = "修改";
            dataGridView1.Columns.Add(col_Btn_alter);

            DataGridViewButtonColumn col_Btn_Drop = new DataGridViewButtonColumn();
            col_Btn_Drop.Name = "colBtn_drop";
            col_Btn_Drop.HeaderText = "";
            col_Btn_Drop.DefaultCellStyle.NullValue = "删除";
            dataGridView1.Columns.Add(col_Btn_Drop);
        }

        public WorkShopManageForm()
        {
            InitializeComponent();

            ShowDataGird();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") { MessageBox.Show("请填写完整的新增信息", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            WorkShop model = new WorkShop();
            model.name = textBox1.Text;
            model.master = textBox2.Text;
            model.sum = Convert.ToInt32(textBox3.Text);
            if (WorkShopHelper.Add(model)) { ShowDataGird(); MessageBox.Show("添加成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_drop") {
                WorkShop model = new WorkShop();
                model.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                if (WorkShopHelper.Drop(model, new List<string>() { "id" })) { ShowDataGird(); MessageBox.Show("删除成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_alter") {
                WorkShop model = new WorkShop();
                model.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                model.master = dataGridView1.Rows[e.RowIndex].Cells["master"].Value.ToString();
                model.name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                model.sum = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["sum"].Value);
                if (WorkShopHelper.AlterByPK(model, "id")) { ShowDataGird(); MessageBox.Show("修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
