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
    /// <summary>
    /// 
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public LoginForm()
        {
            ///
            InitializeComponent();

            //UserDAL userDal = new UserDAL();



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" && textBox2.Text == "") {
                MessageBox.Show("用户名或密码不可为空!");
                return;
            }


            User inputUser = new User(textBox1.Text, textBox2.Text);
            UserDAL userDAL = new UserDAL();

            User user = userDAL.FindModel(inputUser, new List<string>() { "username","password" });
            if (user == null) {
                MessageBox.Show("用户名或密码错误");
                return;
            }


            new HomeForm(this, user).Show();

        }
    }
}
