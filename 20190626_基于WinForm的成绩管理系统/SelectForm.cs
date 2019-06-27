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
    public partial class SelectForm : Form
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
            dataGridView1.Columns["name"].HeaderText = "学生姓名";
            dataGridView1.Columns["kemu"].HeaderText = "科目";
            dataGridView1.Columns["score"].HeaderText = "成绩";

        }
        public SelectForm()
        {
            InitializeComponent();

            ShowDataGird();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Score model = new Score();
            model.kemu = textBox1.Text;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            List<Score> list = ScoreDAL.FindList(model, "kemu");
            dataGridView1.DataSource = list;
            dataGridView1.Columns["sCode"].HeaderText = "学号";
            dataGridView1.Columns["name"].HeaderText = "学生姓名";
            dataGridView1.Columns["kemu"].HeaderText = "科目";
            dataGridView1.Columns["score"].HeaderText = "成绩";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Score model = new Score();
            model.name = textBox2.Text;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            List<Score> list = ScoreDAL.FindList(model, "name");
            dataGridView1.DataSource = list;
            dataGridView1.Columns["sCode"].HeaderText = "学号";
            dataGridView1.Columns["name"].HeaderText = "学生姓名";
            dataGridView1.Columns["kemu"].HeaderText = "科目";
            dataGridView1.Columns["score"].HeaderText = "成绩";
        }
    }
}
