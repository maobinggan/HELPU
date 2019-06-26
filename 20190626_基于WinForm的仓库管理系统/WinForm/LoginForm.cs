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
    /// <summary>
    /// 登录界面
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            //合法性检查
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }
            if (UserHelper.FindModel(new User(textBox1.Text, textBox2.Text), new List<string>() { "userName", "password" }) == null) { MessageBox.Show("用户名或密码错误"); return; }

            //进入主界面
            new HomeForm().Show();
            this.Hide();

        }
    }
}
