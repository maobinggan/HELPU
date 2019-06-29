using _20190629_基于WinForm的博客管理系统.DAL;
using _20190629_基于WinForm的博客管理系统.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190629_基于WinForm的博客管理系统
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
            ShowDataGird();
        }
        /// <summary>
        /// 显示数据网格控件
        /// </summary>
        public void ShowDataGird()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();

            List<Blog> list = BlogDAL.FindList(null);
            dataGridView1.DataSource = list;
            dataGridView1.Columns["name"].HeaderText = "博客名";
            dataGridView1.Columns["author"].HeaderText = "作者";
            dataGridView1.Columns["date"].HeaderText = "上传日期";

        }

        /// <summary>
        /// 点击‘按博客名查询’
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            Blog model = new Blog();
            model.name = textBox1.Text;
            this.dataGridView1.DataSource = null;   //清理数据网格
            this.dataGridView1.Columns.Clear();     //清理数据网格
            List<Blog> list = BlogDAL.FindList(model, "name");
            dataGridView1.DataSource = list;
            dataGridView1.Columns["name"].HeaderText = "博客名";
            dataGridView1.Columns["author"].HeaderText = "作者";
            dataGridView1.Columns["date"].HeaderText = "上传日期";
        }

        /// <summary>
        /// 按作者查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            Blog model = new Blog();
            model.author = textBox1.Text;
            this.dataGridView1.DataSource = null;   //清理数据网格
            this.dataGridView1.Columns.Clear();     //清理数据网格
            List<Blog> list = BlogDAL.FindList(model, "author");
            dataGridView1.DataSource = list;
            dataGridView1.Columns["name"].HeaderText = "博客名";
            dataGridView1.Columns["author"].HeaderText = "作者";
            dataGridView1.Columns["date"].HeaderText = "上传日期";
        }
    }
}
