using _20190626_基于WinForm的图书管理系统.DAL;
using _20190626_基于WinForm的图书管理系统.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190626_基于WinForm的图书管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }
            if (UserHelper.FindModel(new User(textBox1.Text, textBox2.Text), new List<string>() { "userName", "password" }) == null) { MessageBox.Show("用户名或密码错误"); return; }

           
            new HomeForm().Show();
            this.Hide();
        }
    }
}
