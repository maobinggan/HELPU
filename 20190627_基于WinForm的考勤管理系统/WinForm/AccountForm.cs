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
    public partial class AccountForm : Form
    {
        private User user;
        public AccountForm(User user)
        {
            InitializeComponent();
            this.user = user;
            textBox1.Text = user.userName;
        }

        /// <summary>
        /// 点击确定修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }

            user.userName = textBox1.Text;
            user.password = textBox2.Text;
            UserDAL.AlterByPK(user, "id");
            MessageBox.Show("修改成功");
        }
    }
}
