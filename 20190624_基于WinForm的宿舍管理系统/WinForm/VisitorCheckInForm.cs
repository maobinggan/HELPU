using _20190624_基于WinForm的宿舍管理系统.DAL;
using _20190624_基于WinForm的宿舍管理系统.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190624_基于WinForm的宿舍管理系统.WinForm
{
    public partial class VisitorCheckInForm : Form
    {
        VisitorDAL dal = null;
        public VisitorCheckInForm()
        {
            InitializeComponent();
            dal = new VisitorDAL();
            ShowAccommodation();
        }

        void ShowAccommodation()
        {
            //清除数据源，防止乱序
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            //查
            List<Visitor> list = dal.FindList(new Visitor(), new List<string>());

            //
            if (list == null) return;
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;   //DataGridView1的第一列隐藏:id列
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "来访原因";
            dataGridView1.Columns[3].HeaderText = "日期";
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string reason = textBox2.Text;
            string date = textBox3.Text;
            string dormNo = textBox4.Text;
            if (name == "" || reason == "" || date == "") {
                MessageBox.Show("不允许空值");
                return;
            }

            Visitor visitor = new Visitor(name, dormNo, reason, date);
            if (dal.Add(visitor)) { ShowAccommodation(); MessageBox.Show("登记成功"); }
        }
    }
}
