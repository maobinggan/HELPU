using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 成绩管理系统.DAL;
using 成绩管理系统.Model;

namespace 成绩管理系统
{
    public partial class UpdateForm : Form
    {
        /// <summary>
        /// 显示数据网格控件
        /// </summary>
        public void ShowDataGird()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();

            List<Score> list = ScoreDAL.FindList(new Score());
            dataGridView1.DataSource = list;

            dataGridView1.Columns["sCode"].HeaderText = "学号";
            dataGridView1.Columns["sCode"].ReadOnly = true;
            dataGridView1.Columns["name"].HeaderText = "学生姓名";
            dataGridView1.Columns["kemu"].HeaderText = "科目";
            dataGridView1.Columns["score"].HeaderText = "成绩";

            DataGridViewButtonColumn col_Btn_alter = new DataGridViewButtonColumn();
            col_Btn_alter.Name = "colBtn_alter";
            col_Btn_alter.HeaderText = "";
            col_Btn_alter.DefaultCellStyle.NullValue = "修改";
            dataGridView1.Columns.Add(col_Btn_alter);
        }
        public UpdateForm()
        {
            InitializeComponent();
            ShowDataGird();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_alter") {
                Score model = new Score();
                model.sCode = dataGridView1.Rows[e.RowIndex].Cells["sCode"].Value.ToString();
                model.name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                model.kemu = dataGridView1.Rows[e.RowIndex].Cells["kemu"].Value.ToString();
                model.score = dataGridView1.Rows[e.RowIndex].Cells["score"].Value.ToString();
                if (ScoreDAL.AlterByPK(model, "sCode")) { ShowDataGird(); MessageBox.Show("修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
