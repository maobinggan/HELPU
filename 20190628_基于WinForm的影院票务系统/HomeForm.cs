using ADO.CUSTOM;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190628_影院票务系统
{
    public partial class HomeForm : Form
    {
        /// <summary>
        /// 填充数据网格
        /// </summary>
        void FillDataGirdView()
        {
            //清理数据源、清理列（防止列按钮不断增加）
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = TicketDAL.FindList(null);
            dataGridView1.Columns["movieName"].HeaderText = "电影名";
            dataGridView1.Columns["date"].HeaderText = "上映日期";
            dataGridView1.Columns["price"].HeaderText = "票价";
        }

        public HomeForm()
        {
            InitializeComponent();
            FillDataGirdView();

        }

        /// <summary>
        /// 点击关键字查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            //清理数据源、清理列（防止列按钮不断增加）
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = TicketDAL.FindDataTable(string.Format("SELECT * FROM [ticket] WHERE [movieName] LIKE '%{0}%'", textBox1.Text));
            dataGridView1.Columns["movieName"].HeaderText = "电影名";
            dataGridView1.Columns["date"].HeaderText = "上映日期";
            dataGridView1.Columns["price"].HeaderText = "票价";
        }

        /// <summary>
        /// 点击新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            Ticket model = new Ticket();
            model.movieName = textBox2.Text;
            model.date = dateTimePicker1.Value.Date.ToString();
            model.price = textBox4.Text;
            TicketDAL.Add(model);

            //显示数据网格
            FillDataGirdView();
        }

        /// <summary>
        /// 点击加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            Ticket model = TicketDAL.FindModel(new Ticket(Convert.ToInt32(textBox3.Text)), "id");

            if (model != null) {
                textBox6.Text = model.movieName;
                textBox7.Text = model.date;
                textBox5.Text = model.price;
            }
        }

        /// <summary>
        /// 点击修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "") { MessageBox.Show("ID不可为空"); return; }
            Ticket model = new Ticket();
            model.Id = Convert.ToInt32(textBox3.Text);
            model.movieName = textBox6.Text;
            model.date = textBox7.Text;
            model.price = textBox5.Text;
            if (TicketDAL.FindModel(new Ticket(model.Id), "id") == null) { MessageBox.Show("不存在此ID"); return; }
            if (TicketDAL.AlterByPK(model, "id")) { FillDataGirdView(); MessageBox.Show("修改成功"); return; }

        }

        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "") { MessageBox.Show("ID不可为空"); return; }
            Ticket model = new Ticket();
            model.Id = Convert.ToInt32(textBox8.Text);
            if (TicketDAL.FindModel(new Ticket(model.Id), "id") == null) { MessageBox.Show("不存在此ID"); return; }
            if (TicketDAL.Drop(model, "id")) { FillDataGirdView(); MessageBox.Show("删除成功"); return; }
        }
    }
}
