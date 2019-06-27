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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            User model = new User();
            model.userName = textBox1.Text;
            model.password = textBox2.Text;

            if (UserDAL.FindModel(model, "username", "password") == null) {
                MessageBox.Show("用户名或密码错误");
                return;
            }

            new HomeForm().Show();
            this.Hide();
        }
    }
}
