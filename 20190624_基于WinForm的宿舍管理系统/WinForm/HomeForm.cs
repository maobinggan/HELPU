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
    /// /
    /// </summary>
    public partial class HomeForm : Form
    {

        /// <summary>
        /// 
        /// </summary>
        User user;


        /// <summary>
        /// 
        /// </summary>
        Form preForm;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="preForm"></param>
        /// <param name="user"></param>
        public HomeForm(Form preForm, User user)
        {
            InitializeComponent();
            this.user = user;
            this.preForm = preForm;
            string str = user.UserName.Trim();
            label1.Text = string.Format("当前登录：[{0}]", str);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            new StuManageForm().Show();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            new VisitorCheckInForm().Show();
        }
    }
}
