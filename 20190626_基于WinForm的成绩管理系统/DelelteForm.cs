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
    public partial class DelelteForm : Form
    {
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
        public DelelteForm()
        {
            InitializeComponent();

            ShowDataGird();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Score model = new Score();
            model.sCode = textBox1.Text;
            ScoreDAL.Drop(model,"scode");
            ShowDataGird();
        }
    }
}
