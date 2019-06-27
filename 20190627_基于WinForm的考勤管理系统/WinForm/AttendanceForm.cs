using _20190627_基于WinForm的考勤管理系统.DAL;
using _20190627_基于WinForm的考勤管理系统.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190627_基于WinForm的考勤管理系统.WinForm
{
    public partial class AttendanceForm : Form
    {
        /// <summary>
        /// 填充数据网格
        /// </summary>
        void LoadDataGridView()
        {
            //清理数据源、清理列（防止列按钮不断增加）
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = AttendanceDAL.FindList(null);

            dataGridView1.Columns["name"].HeaderText = "员工姓名";
            dataGridView1.Columns["gender"].HeaderText = "性别";
            dataGridView1.Columns["date"].HeaderText = "考勤日期";
            dataGridView1.Columns["Id"].HeaderText = "考勤ID";

        }

        public AttendanceForm()
        {
            InitializeComponent();

            //加载DataGridView
            LoadDataGridView();
        }

        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            string condition = "";
            string value = textBox1.Text;
            if (comboBox1.Text == "员工姓名") { condition = "name"; }
            if (comboBox1.Text == "性别") { condition = "gender"; }

            //模糊查询关键字
            string sql = string.Format("SELECT [Id],[name],[gender],[date] FROM [Attendance] WHERE [{0}] LIKE '%{1}%'", condition, value);
            DataTable dt = AttendanceDAL.FindDataTable(sql);
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["name"].HeaderText = "员工姓名";
            dataGridView1.Columns["gender"].HeaderText = "性别";
            dataGridView1.Columns["date"].HeaderText = "考勤日期";
            dataGridView1.Columns["Id"].HeaderText = "考勤ID";


        }

        /// <summary>
        /// 点击添加考勤信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buttonadd_Click(object sender, EventArgs e)
        {

            Attendance model = new Attendance();
            model.name = textBox2.Text;
            model.gender = comboBox2.Text;
            model.date = dateTimePicker1.Text;

            //
            if (AttendanceDAL.Add(model)) { LoadDataGridView(); MessageBox.Show("添加成功"); }

        }

        /// <summary>
        /// 点击加载数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {

            Attendance model = new Attendance();

            try {
                model.Id = Convert.ToInt32(textBox17.Text);
                model = AttendanceDAL.FindModel(model, "id");
                textBox11.Text = model.name;
                textBox3.Text = model.gender;
                textBox10.Text = model.date;
            }
            catch (Exception ex) {
                MessageBox.Show("请输入数字");
            }


        }

        /// <summary>
        /// 点击提交修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            Attendance model = new Attendance();
            try {
                model.Id = Convert.ToInt32(textBox17.Text);
                model.name = textBox11.Text;
                model.gender = textBox3.Text;
                model.date = textBox10.Text;
                if (AttendanceDAL.AlterByPK(model, "id")) { LoadDataGridView(); MessageBox.Show("修改成功"); }
            }
            catch (Exception ex) {
                MessageBox.Show("ID必须是数字");
            }
        }

        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            Attendance model = new Attendance();
            try {
                model.Id = Convert.ToInt32(textBox18.Text);
                if (AttendanceDAL.Drop(model, "id")) { LoadDataGridView();  }
            }
            catch (Exception ex) {
                MessageBox.Show("ID必须是数字");
            }
        }
    }
}
