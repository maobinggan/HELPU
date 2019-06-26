using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190626_基于WinForm的仓库管理系统.WinForm
{
    public partial class HomeForm : Form
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public HomeForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }


        /// <summary>
        /// 进入商品管理页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 产品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodManageForm newForm = new GoodManageForm();
            newForm.MdiParent = this;
            newForm.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 产品出库入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialManageForm newForm = new MaterialManageForm();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void 查询商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkShopManageForm newForm = new WorkShopManageForm();
            newForm.MdiParent = this;
            newForm.Show();
        }
    }
}
