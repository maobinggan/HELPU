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
    public partial class HomeForm : Form
    {
        public User user { get; set; }

        public HomeForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Text = string.Format("欢迎登录考勤管理系统", user.userName);
        }

        /// <summary>
        /// 点击‘考勤管理’按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            AttendanceForm newForm = new AttendanceForm();
            splitContainer1.Panel2.Controls.Clear();
            newForm.TopLevel = false;
            newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            newForm.WindowState = FormWindowState.Normal;
            newForm.Dock = DockStyle.Fill;
            newForm.KeyPreview = true;
            newForm.Parent = splitContainer1.Panel2;
            newForm.Show();
        }

        /// <summary>
        /// 点击账户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            AccountForm newForm = new AccountForm(user);
            splitContainer1.Panel2.Controls.Clear();
            newForm.TopLevel = false;
            newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            newForm.WindowState = FormWindowState.Normal;
            newForm.Dock = DockStyle.Fill;
            newForm.KeyPreview = true;
            newForm.Parent = splitContainer1.Panel2;
            newForm.Show();
        }
    }
}
