using _20190626_基于WinForm的图书管理系统.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _20190626_基于WinForm的图书管理系统.DAL
{
    class UserHelper:BaseHelper<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddById(User model)
        {
            DataTable dataTable = null;
            User t = default(User);

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
        public static bool AddByName(User model)
        {
            DataTable dataTable = null;
            User t = default(User);
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
        public static bool UpdateByName(User model)
        {
            DataTable dataTable = null;
            User t = default(User);

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
        public static bool UpdateByID(User model)
        {
            DataTable dataTable = null;
            User t = default(User);

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
