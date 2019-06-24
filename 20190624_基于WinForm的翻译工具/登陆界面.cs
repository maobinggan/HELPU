using _20190624_基于WinForm的翻译工具.百度翻译;
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
    public partial class 登陆界面 : Form
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public 登陆界面()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 点击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") {
                MessageBox.Show("必须输入用户名");
                return;
            }
            if (!checkBox1.Checked) {
                MessageBox.Show("请先阅读许可协议");
                return;
            }

            new 翻译界面(this,this.textBox1.Text).Show();
            this.Hide();
            return;


        }

        /// <summary>
        /// 点击添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            //判断所有选中项集合大于0
            if (this.listBox1.SelectedItems.Count > 0) {
                //获取选中的值
                string item = this.listBox1.SelectedItem.ToString();
                this.listBox2.Items.Add(item);
                this.listBox1.Items.Remove(item);
            }
        }

        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            //判断所有选中项集合大于0
            if (this.listBox2.SelectedItems.Count > 0) {
                //获取选中的值
                string item = this.listBox2.SelectedItem.ToString();
                this.listBox1.Items.Add(item);
                this.listBox2.Items.Remove(item);
            }
        }

        /// <summary>
        /// 点击查看许可协议按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string str = "特此授权，任何人都可免费获得这个软件以及相关文档的拷贝，可以无限制的使用这个软件，包括无限制的权利去使用、复制、修改、合并、发布、附加从属协议，以及/或者出售软件的拷贝， 同时，为了让软件的提供者有权利做到这些，下面的条件必须遵守：上面的拷贝权声明和许可声明必须包含在所有的这个软件拷贝里和实际分署部分里。";
            MessageBox.Show(str);
        }
    }
}
