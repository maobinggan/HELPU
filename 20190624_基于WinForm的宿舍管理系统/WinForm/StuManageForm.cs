using _20190624_基于WinForm的宿舍管理系统.DAL;
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
    /// 
    /// </summary>
    public partial class StuManageForm : Form
    {


        /// <summary>
        /// 
        /// </summary>
        void ShowAccommodation()
        {
            //清除数据源，防止乱序
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            //查
            AccommodationDAL dal = new AccommodationDAL();
            List<Accommodation> list = dal.FindList(new Accommodation(), new List<string>());

            //
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;   //DataGridView1的第一列隐藏:id列
            dataGridView1.Columns[1].HeaderText = "学号";
            dataGridView1.Columns[2].HeaderText = "姓名";
            dataGridView1.Columns[3].HeaderText = "性别";
            dataGridView1.Columns[4].HeaderText = "宿舍楼";
            dataGridView1.Columns[5].HeaderText = "寝室";

            //
            DataGridViewButtonColumn col_Btn_alter = new DataGridViewButtonColumn();
            col_Btn_alter.Name = "colBtn_alter";
            col_Btn_alter.HeaderText = "";
            col_Btn_alter.DefaultCellStyle.NullValue = "修改";
            dataGridView1.Columns.Add(col_Btn_alter);//在dataGridView末尾追加一列

            DataGridViewButtonColumn col_Btn_drop = new DataGridViewButtonColumn();
            col_Btn_drop.Name = "colBtn_delete";
            col_Btn_drop.HeaderText = "";
            col_Btn_drop.DefaultCellStyle.NullValue = "删除";
            dataGridView1.Columns.Add(col_Btn_drop); //在dataGridView末尾追加一列
        }

        /// <summary>
        /// 
        /// </summary>
        public StuManageForm()
        {
            InitializeComponent();

            ShowAccommodation();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DataGridViewCellContent_Click(object sender, DataGridViewCellEventArgs e)
        {
            //修改
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_alter") {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
                string sCode = dataGridView1.Rows[e.RowIndex].Cells["scode"].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string gender = dataGridView1.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                string dormNo = dataGridView1.Rows[e.RowIndex].Cells["dormNo"].Value.ToString();
                string roomNo = dataGridView1.Rows[e.RowIndex].Cells["roomNo"].Value.ToString();

                Accommodation model = new Accommodation(id, sCode, name, gender, dormNo, roomNo);
                AccommodationDAL dal = new AccommodationDAL();
                if (dal.AlterByPK(model,"id")) {
                    ShowAccommodation();
                    MessageBox.Show("修改成功");
                }
            }

            //删除
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colBtn_delete") {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                Accommodation model = new Accommodation(id);
                AccommodationDAL dal = new AccommodationDAL();
                if (dal.Drop(model, new List<string>() { "id" })) {
                    ShowAccommodation();
                    MessageBox.Show("删除成功");
                }
            }
        }


        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Button1_Click(object sender, EventArgs e)
        {
            string sCode = textBox1.Text;
            string name = textBox2.Text;
            string gender = textBox3.Text;
            string dormNo = textBox4.Text;
            string roomNo = textBox5.Text;
            if (sCode == null
                || name == null
                || gender == null
                || dormNo == null
                || roomNo == null) {

                MessageBox.Show("不允许空值");
            }
            Accommodation model = new Accommodation(sCode, name, gender, dormNo, roomNo);
            AccommodationDAL dal = new AccommodationDAL();
            if (dal.Add(model)) {
                ShowAccommodation();
                MessageBox.Show("添加成功");
            }
        }
    }
}
