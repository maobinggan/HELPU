using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 成绩管理系统.Model;

namespace 成绩管理系统.DAL
{
    class UserDAL:BaseDAL<User>
    {
        /// <summary>
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 用现有的数据库连接执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="connection">一个现有的数据库连接</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        ///使用现有的SQL事务执行一个sql命令（不返回数据集）
        /// </summary>
        /// <remarks>
        ///举例:
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个现有的事务</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <remarks>
        /// 举例:
        ///  MySqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            //创建一个MySqlCommand对象
            SqlCommand cmd = new SqlCommand();
            //创建一个MySqlConnection对象
            SqlConnection conn = new SqlConnection(connectionString);

            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //调用 MySqlCommand  的 ExecuteReader 方法
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //清除参数
                cmd.Parameters.Clear();
                return reader;
            }
            catch {
                //关闭连接，抛出异常
                conn.Close();
                throw;
            }
        }
        //llqqsoft
        public static DataTable RT(string cmdText, CommandType cmdType, params SqlParameter[] commandParameters)
        {
            //创建一个MySqlCommand对象
            SqlCommand cmd = new SqlCommand();
            //创建一个MySqlConnection对象
            SqlConnection conn = new SqlConnection("");

            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，

            try {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //调用 MySqlCommand  的 ExecuteReader 方法
                SqlDataAdapter adapter = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                //清除参数
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch (Exception e) {
                throw e;
            }
        }
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        /// 
        public static DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            //创建一个MySqlCommand对象
            SqlCommand cmd = new SqlCommand();
            //创建一个MySqlConnection对象
            SqlConnection conn = new SqlConnection(connectionString);

            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，

            try {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //调用 MySqlCommand  的 ExecuteReader 方法
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                //清除参数
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch (Exception e) {
                throw e;
            }
        }



        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如:
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        ///<param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        /// 例如:
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个存在的数据库连接</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 将参数集合添加到缓存
        /// </summary>
        /// <param name="cacheKey">添加到缓存的变量</param>
        /// <param name="commandParameters">一个将要添加到缓存的sql参数集合</param>
        public static void CacheParameters(string[] cacheKey, params SqlParameter[] commandParameters)
        {
            SqlParameter[] cacheKe = commandParameters;
        }

        /// <summary>
        /// 找回缓存参数集合
        /// </summary>
        /// <param name="cacheKey">用于找回参数的关键字</param>
        /// <returns>缓存的参数集合</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            string cachedParms = cacheKey;

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++) {
                XmlWriteMode xm = new XmlWriteMode();
            }

            return clonedParms;
        }

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">OleDb连接</param>
        /// <param name="trans">OleDb事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如:Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null) {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool FindByID(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool FindByName(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool FindBycol(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool FindByIpi(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool FindBysr(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool FindBydem(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool FindBsw(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool UpdeByID(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool UpdeByGui(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool UpdeBySCode(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool UpdeBySwire(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool UpdeByInteger(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterByInteger(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterBystring(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterByDone(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AddByInteger(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterByName(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterByInteger_Name(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterByInteger_Id(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterByFix(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
        public static bool AlterByShow(string model)
        {
            DataTable dataTable = null;

            string t = default(string);

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
