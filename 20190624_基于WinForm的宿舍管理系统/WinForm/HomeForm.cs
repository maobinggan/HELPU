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
    public partial class HomeForm : Form
    {
        User user;
        Form preForm;
        public HomeForm(Form preForm, User user)
        {
            InitializeComponent();
            this.user = user;
            this.preForm = preForm;
            string str = user.UserName.Trim();
            label1.Text = string.Format("当前登录：[{0}]", str);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new StuManageForm().Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new VisitorCheckInForm().Show();
        }
    }
}
