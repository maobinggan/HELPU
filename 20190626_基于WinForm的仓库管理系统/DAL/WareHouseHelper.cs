using _20190626_基于WinForm的仓库管理系统.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190626_基于WinForm的仓库管理系统.DAL
{
    class WareHouseHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private static SqlConnection conn;


        /// <summary>
        /// 
        /// </summary>
        private static string connStr;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddById(Goods model)
        {
            DataTable dataTable = null;
            Goods t = default(Goods);

            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddByName(Goods model)
        {
            DataTable dataTable = null;
            Goods t = default(Goods);
            String sqlStr = "";
            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateByName(Goods model)
        {
            DataTable dataTable = null;
            Goods t = default(Goods);

            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateByID(Goods model)
        {
            DataTable dataTable = null;
            Goods t = default(Goods);

            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool DeleteID(Goods model)
        {
            DataTable dataTable = null;
            Goods t = default(Goods);

            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
