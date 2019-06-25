using _20190625_基于WinForm的门店管理系统.DAL;
using _20190625_基于WinForm的门店管理系统.Model;
using _20190625_基于WinForm的门店管理系统.Properties;
using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190625_基于WinForm的门店管理系统.WinForm
{
    public partial class LoginForm : Skin_DevExpress
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void SkinButton1_Click(object sender, EventArgs e)
        {

        }
        Boolean textboxHasText = false;//判断输入框是否有文本
        //textbox获得焦点
        private void Textbox_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textbox1.Text = "";

            textbox1.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void Textbox_Leave(object sender, EventArgs e)
        {
            if (textbox1.Text == "") {
                textbox1.Text = "!!!";
                textbox1.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            User user = UserDAL.FindModel(new User(textbox1.Text, textbox2.Text), new List<string>() { "username", "password" });
            if (user == null) {
                MessageBoxEx.Show("用户名或密码错误", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new HomeForm().Show();
            this.Hide();
        }
    }
}
