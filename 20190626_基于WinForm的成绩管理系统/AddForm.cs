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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            ShowDataGird();
        }

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

        private void Button2_Click(object sender, EventArgs e)
        {
            Score model = new Score();
            model.sCode = textBox1.Text;
            model.name = textBox2.Text;
            model.kemu = textBox4.Text;
            model.score = textBox3.Text;
            ScoreDAL.Add(model);
            ShowDataGird();
        }
    }
}
