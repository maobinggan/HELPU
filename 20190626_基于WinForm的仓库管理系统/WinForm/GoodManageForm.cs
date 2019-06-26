using _20190626_基于WinForm的仓库管理系统.DAL;
using _20190626_基于WinForm的仓库管理系统.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace _20190626_基于WinForm的仓库管理系统.WinForm
{
    public partial class GoodManageForm : Form
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public GoodManageForm()
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

            List<Goods> list = GoodsHelper.FindList(new Goods(), new List<string>());
            dataGridView1.DataSource = list;

            dataGridView1.Columns["name"].HeaderText = "商品名";
            dataGridView1.Columns["type"].HeaderText = "商品类型";
            dataGridView1.Columns["sum"].HeaderText = "库存数量";

            dataGridView1.Columns["id"].Visible = false;

            DataGridViewButtonColumn col_Btn_alter = new DataGridViewButtonColumn();
            col_Btn_alter.Name = "colBtn_alter";
            col_Btn_alter.HeaderText = "";
            col_Btn_alter.DefaultCellStyle.NullValue = "修改";
            dataGridView1.Columns.Add(col_Btn_alter);

            DataGridViewButtonColumn col_Btn_Drop = new DataGridViewButtonColumn();
            col_Btn_Drop.Name = "colBtn_drop";
            col_Btn_Drop.HeaderText = "";
            col_Btn_Drop.DefaultCellStyle.NullValue = "删除";
            dataGridView1.Columns.Add(col_Btn_Drop);
        }

        /// <summary>
        /// 点击添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") { MessageBox.Show("请填写完整新增商品的信息", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Goods model = new Goods();
            model.name = textBox1.Text;
            model.type = textBox2.Text;
            model.sum = Convert.ToInt32(textBox3.Text);
            if (GoodsHelper.Add(model)) { ShowDataGird(); MessageBox.Show("添加商品成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++) {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++) {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++) {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 点击数据网格控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_drop") {
                Goods model = new Goods();
                model.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                if (GoodsHelper.Drop(model, new List<string>() { "id" })) { ShowDataGird(); MessageBox.Show("删除成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_alter") {
                Goods model = new Goods();
                model.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                model.sum = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["sum"].Value);
                model.name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                model.type = dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString();
                if (GoodsHelper.AlterByPK(model, "id")) { ShowDataGird(); MessageBox.Show("修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
