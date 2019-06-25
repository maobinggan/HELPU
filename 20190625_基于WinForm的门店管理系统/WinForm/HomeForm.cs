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
    public partial class HomeForm : Skin_DevExpress
    {
        /// <summary>
        /// 
        /// </summary>
        public HomeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkinButton1_Click(object sender, EventArgs e)
        {
            new StoreForm().Show();
        }

        private void SkinButton2_Click(object sender, EventArgs e)
        {
            new StaffForm().Show();
        }
    }
}
