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
    abstract class BaseHelper<T> where T : new()
    {
        protected static String connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        protected static SqlConnection conn = null;

        public static bool Add(T model)
        {
            DataTable dataTable = null;
            T t = default(T);
            String sqlStr = GenerateSql_Insert(model);

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

        public static bool Drop(T bean, List<string> conditions)
        {

            DataTable dataTable = null;
            T t = default(T);


            String sqlStr = GenerateSql_Delete(bean, conditions);

            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                t = ConvertToModel(dataTable);

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

        public static bool AlterByPK(T model, string PKName)
        {
            DataTable dataTable = null;
            T t = default(T);
            Type type = typeof(T);
            String sqlStr = GenerateSql_UpdateByPK(model, PKName);
            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                t = ConvertToModel(dataTable);
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
        public static T FindModel(T bean, List<string> conditions)
        {
            DataTable dataTable = null;
            T t = default(T);
            String sqlStr = GenerateSql_Select(bean, conditions);

            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                t = ConvertToModel(dataTable);
                return t;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return t;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }
        public static List<T> FindList(T model, List<string> conditions)
        {
            DataTable dataTable = null;
            List<T> ts = new List<T>();
            String sqlStr = GenerateSql_Select(model, conditions);
            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                ts = ConvertToList(dataTable);
                return ts;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return ts;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }
        protected static DataTable FindDataTable(String sqlStr)
        {
            DataTable dataTable = null;
            try {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return dataTable;
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }

        protected static string GenerateSql_Insert(T model)
        {
            Type type = typeof(T);
            PropertyInfo[] propertys = type.GetProperties();

            StringBuilder sql_cols = new StringBuilder();
            StringBuilder sql_vals = new StringBuilder();
            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name;
                object objValue = pi.GetValue(model);
                if (objValue == null) { continue; }
                string propValue = objValue.ToString();
                if (propName.ToUpper().Equals("ID")) { continue; }
                sql_cols.Append(string.Format(",[{0}]", propName));
                sql_vals.Append(string.Format(",'{0}'", propValue));
            }
            Regex regex = new Regex(",");
            string res = string.Format("INSERT INTO [{0}]( {1} ) VALUES ( {2} )",
                type.Name,
                regex.Replace(sql_cols.ToString(), "", 1),
                regex.Replace(sql_vals.ToString(), "", 1));

            return res;
        }
        protected static string GenerateSql_Delete(T bean, List<string> conditions)
        {
            Type type = typeof(T);
            PropertyInfo[] propertys = type.GetProperties();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM [{0}]", type.Name);
            if (conditions.Count == 0) {
                return sql.ToString();
            }
            sql.Append(" WHERE ");

            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name;
                foreach (string con in conditions) {
                    if (con.ToUpper().Equals(propName.ToUpper())) {
                        string propValue = pi.GetValue(bean).ToString();
                        sql.Append(string.Format("AND [{0}] = '{1}' ", propName, propValue));
                    }
                }
            }
            Regex regex = new Regex("AND");
            string res = regex.Replace(sql.ToString(), "", 1);

            return res;
        }
        protected static string GenerateSql_UpdateByPK(T model, string PKName)
        {
            Type type = typeof(T);
            PropertyInfo[] propertys = type.GetProperties();
            StringBuilder sql_dest = new StringBuilder(string.Format("UPDATE [{0}] SET ", type.Name));
            StringBuilder sql_condition = new StringBuilder();
            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name;
                object objValue = pi.GetValue(model);
                if (objValue == null) { continue; }
                string propValue = objValue.ToString();
                if (propName.ToUpper().Equals(PKName.ToUpper())) {
                    sql_condition.Append(string.Format("WHERE [{0}] = '{1}'", propName, propValue));
                    continue;
                }
                sql_dest.Append(string.Format(",[{0}] = '{1}' ", propName, propValue));
            }

            string res = sql_dest.Append(sql_condition).ToString();

            Regex regex = new Regex(",");
            res = regex.Replace(res.ToString(), "", 1);

            return res;


        }
        protected static string GenerateSql_UpdateNoWhere(T model)
        {
            Type type = typeof(T);
            PropertyInfo[] propertys = type.GetProperties();
            StringBuilder sql = new StringBuilder(string.Format("UPDATE [{0}] SET ", type.Name));

            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name;
                object objValue = pi.GetValue(model);
                if (objValue == null) { continue; }
                string propValue = objValue.ToString();
                if (propName.ToUpper().Equals("ID")) { continue; }
                sql.Append(string.Format(",[{0}] = '{1}' ", propName, propValue));
            }
            Regex regex = new Regex(",");
            string res = regex.Replace(sql.ToString(), "", 1);
            return res;
        }
        protected static string GenerateSql_Select(T bean, List<string> conditions)
        {
            Type type = typeof(T);
            PropertyInfo[] propertys = type.GetProperties();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT * FROM [{0}] ", type.Name);
            if (conditions.Count == 0) {
                return sql.ToString();
            }
            sql.Append(" WHERE ");
            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name;
                foreach (string con in conditions) {
                    if (con.ToUpper().Equals(propName.ToUpper())) {
                        string propValue = pi.GetValue(bean).ToString();
                        sql.Append(string.Format("AND [{0}] = '{1}' ", propName, propValue));
                    }
                }
            }
            Regex regex = new Regex("AND");
            string res = regex.Replace(sql.ToString(), "", 1);
            return res;
        }
        protected static T ConvertToModel(DataTable dt)
        {
            T t = default(T);

            if (dt != null && dt.Rows.Count != 0) {
                t = new T();
                Type type = typeof(T);
                string tempName = "";
                DataRow dr = dt.Rows[0];
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys) {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName)) {
                        if (pi.CanWrite) {
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }

                    }
                }
            }
            return t;
        }
        public static List<T> ConvertToList(DataTable dt)
        {
            List<T> ts = null;
            if (dt != null) {
                ts = new List<T>();
                Type type = typeof(T);
                string tempName = "";
                foreach (DataRow dr in dt.Rows) {
                    T t = new T();
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys) {
                        tempName = pi.Name;
                        if (dt.Columns.Contains(tempName)) {
                            if (pi.CanWrite) {
                                object value = dr[tempName];
                                if (value != DBNull.Value)
                                    pi.SetValue(t, value, null);
                            }

                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
            return ts;
        }
    }
}

