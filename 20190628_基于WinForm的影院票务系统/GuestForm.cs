using _20190628_影院票务系统.Model;
using ADO.CUSTOM;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190628_影院票务系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            AdoCustomManager.Setting(true);
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("用户名或密码不可为空"); return; }
            User model = new User();
            model.userName = textBox1.Text;
            model.password = textBox2.Text;
            model = UserDAL.FindModel(model, "userName", "password");
            if (model == null) { MessageBox.Show("用户名或密码错误!"); return; }
            new HomeForm().Show();
            this.Hide();

        }

        private void Button2_Click(object sender, EventArgs e)
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
