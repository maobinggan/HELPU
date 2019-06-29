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
    public partial class GuestForm : Form
    {
        public GuestForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }
            User model = new User();
            model.userName = textBox1.Text;
            model.password = textBox2.Text;
            model = UserDAL.FindModel(model, "userName", "password");
            if (model == null) { MessageBox.Show("用户名或密码错误!"); return; }
            new HomeForm().Show();
            this.Hide();
        }

        /// <summary>
        /// 注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }
            User model = new User();
            model.userName = textBox1.Text;
            model.password = textBox2.Text;
            if (UserDAL.FindModel(model, "userName") != null) { MessageBox.Show("注册失败，用户名已存在!"); return; }
            UserDAL.Add(model);
            MessageBox.Show("注册成功");
        }
    }
}
