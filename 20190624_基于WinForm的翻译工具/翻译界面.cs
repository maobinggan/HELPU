using _20190624_基于WinForm的翻译工具.百度翻译;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190624_基于WinForm的翻译工具
{
    public partial class 翻译界面 : Form
    {
        /// <summary>
        /// 用户名
        /// </summary>
        string userName;

        Form preForm;
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="preForm">前一个窗体对象</param>
        /// <param name="name">用户名</param>
        public 翻译界面(Form preForm, string name)
        {
            InitializeComponent();
            this.userName = name;
            this.preForm = preForm;
        }


        /// <summary>
        /// 点击显示日期菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 在状态栏显示日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前日期：" + DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// 点击查看用户名菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 查看个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("当前登录的用户名为[" + userName + "]");
        }

        /// <summary>
        /// 点击修改用户名菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string newName = Interaction.InputBox("输入新的用户名：", "设置用户名");
            if (newName != "") { this.userName = newName; }
        }

        /// <summary>
        /// 点击返回菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 返回ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.preForm.Show();
        }

        /// <summary>
        /// 点击翻译按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") { return; }

            if (comboBox1.SelectedItem.ToString() == "汉语->英语") {
                richTextBox2.Text = Engine.translation_Zh_En(richTextBox1.Text);
            }
            else if (comboBox1.SelectedItem.ToString() == "英语->汉语") {
                richTextBox2.Text = Engine.translation_En_Ch(richTextBox1.Text);
            }

           
        }
    }
}
