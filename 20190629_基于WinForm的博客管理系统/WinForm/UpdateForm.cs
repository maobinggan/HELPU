using _20190629_基于WinForm的博客管理系统.DAL;
using _20190629_基于WinForm的博客管理系统.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190629_基于WinForm的博客管理系统
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            ShowDataGird();
        }

        /// <summary>
        /// 显示数据网格控件
        /// </summary>
        public void ShowDataGird()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();

            List<Blog> list = BlogDAL.FindList(null);
            dataGridView1.DataSource = list;
            dataGridView1.Columns["name"].HeaderText = "博客名";
            dataGridView1.Columns["author"].HeaderText = "作者";
            dataGridView1.Columns["date"].HeaderText = "上传日期";
            dataGridView1.Columns["id"].ReadOnly = true;     //id列设为不可编辑

            //加一列按钮
            DataGridViewButtonColumn col_Btn_alter = new DataGridViewButtonColumn();
            col_Btn_alter.Name = "colBtn_alter";
            col_Btn_alter.HeaderText = "";
            col_Btn_alter.DefaultCellStyle.NullValue = "修改";
            dataGridView1.Columns.Add(col_Btn_alter);

        }

        /// <summary>
        /// 点击数据网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_alter") {
                Blog model = new Blog();
                model.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                model.name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                model.author = dataGridView1.Rows[e.RowIndex].Cells["author"].Value.ToString();
                model.date = dataGridView1.Rows[e.RowIndex].Cells["date"].Value.ToString();
                if (BlogDAL.AlterByPK(model, "Id")) { ShowDataGird(); MessageBox.Show("修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
