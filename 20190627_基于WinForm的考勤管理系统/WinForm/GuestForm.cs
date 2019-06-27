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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || usertextBox.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }
            User model = new User();
            model.userName = usertextBox.Text;
            model.password = textBox1.Text;
            model = UserDAL.FindModel(model, "userName", "password");
            if (model == null) { MessageBox.Show("用户名或密码错误!"); return; }
            new HomeForm(model).Show();
            this.Hide();

        }

        /// <summary>
        /// 点击注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || usertextBox.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }
            User model = new User();
            model.userName = usertextBox.Text;
            model.password = textBox1.Text;
            if (UserDAL.FindModel(model, "userName") != null) { MessageBox.Show("注册失败,用户名已存在"); return; }
            if (UserDAL.Add(model)) { MessageBox.Show("注册成功！"); }
        }
    }
}
