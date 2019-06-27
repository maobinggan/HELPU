using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190627_基于WinForm的考勤管理系统.DAL
{
    /*
    /// <summary>
    /// 定义抽象类，以泛型为参数。即当实例化或继承此抽象类时，必须指明该泛型的具体类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /*
    * <T> where T :new ()  表示A类接受某一种类型，泛型类型为T，需要运行时传入。
    * where表明了对类型变量T的约束关系。where T：new()指明了创建T的实例时应该具有构造函数。
    * 一般情况下，是无法创建一个泛型类型参数的实例。然而，new()约束改变了这种情况，要求类型参数必须提供一个无参数的构造函数。
    */
    abstract class BaseDAL<T> where T : new()
    {
        //从app.config文件中读取连接字符串："server=127.0.0.1;uid=sa;pwd=123456;database=DormManagement";
        protected static String connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        protected static SqlConnection conn = null;

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="model"></param>
        public static bool Add(T model)
        {
            //初始化
            DataTable dataTable = null;
            T t = default(T);

            //生成sql语句
            String sqlStr = GenerateSql_Insert(model);

            try {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                //dataTable = new DataTable();
                //new SqlDataAdapter(cmd).Fill(dataTable);
                //t = ConvertToModel(dataTable);//dataTable转模型

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                //无论是否异常都关闭连接
                conn.Close();
                conn.Dispose();
            }

        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static bool Drop(T model, params string[] conditions)
        {
            //初始化
            DataTable dataTable = null;
            T t = default(T);        //在泛型类型中，引用类型的default将泛型类型初始化null，值类型的default将泛型类型初始化为0

            //生成sql语句
            String sqlStr = GenerateSql_Delete(model, conditions);

            try {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                //dataTable = new DataTable();
                //new SqlDataAdapter(cmd).Fill(dataTable);
                //t = ConvertToModel(dataTable);//dataTable转模型

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                //无论是否异常都关闭连接
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 改：根据Id
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static bool AlterByPK(T model, string PKName)
        {
            //初始化
            DataTable dataTable = null;
            T t = default(T);        //在泛型类型中，引用类型的default将泛型类型初始化null，值类型的default将泛型类型初始化为0

            //生成sql语句
            String sqlStr = GenerateSql_UpdateByPK(model, PKName);

            try {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                //dataTable = new DataTable();
                //new SqlDataAdapter(cmd).Fill(dataTable);
                //t = ConvertToModel(dataTable);//dataTable转模型

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally {
                //无论是否异常都关闭连接
                conn.Close();
                conn.Dispose();
            }

        }

        /// <summary>
        /// 查询：得到模型对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conditions">为空时表示无条件查询</param>
        /// <returns></returns>
        public static T FindModel(T model, params string[] conditions)
        {
            //初始化
            DataTable dataTable = null;
            T t = default(T);        //在泛型类型中，引用类型的default将泛型类型初始化null，值类型的default将泛型类型初始化为0

            //生成sql语句
            String sqlStr = GenerateSql_Select(model, conditions);

            try {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                //dataTable转模型
                t = ConvertToModel(dataTable);
                return t;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return t;
            }
            finally {
                //无论是否异常都关闭连接
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 查询：得到模型对象的集合
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static List<T> FindList(T model, params string[] conditions)
        {
            //初始化
            DataTable dataTable = null;
            List<T> ts = new List<T>();


            //生成sql语句
            String sqlStr = GenerateSql_Select(model, conditions);

            try {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                //dataTable转模型
                ts = ConvertToList(dataTable);
                return ts;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return ts;
            }
            finally {
                //无论是否异常都关闭连接
                conn.Close();
                conn.Dispose();
            }
        }


        /// <summary>
        /// 自写SQL语句查询：得到DataTable
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public static DataTable FindDataTable(String sqlStr)
        {
            DataTable dataTable = null;
            try {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
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
                //无论是否异常都关闭连接
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 构造SQL语句：Insert
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        protected static string GenerateSql_Insert(T model)
        {

            // 获取泛型的具体类型
            Type type = typeof(T);

            //获取泛型的各个属性
            PropertyInfo[] propertys = type.GetProperties();

            //构造SQL字符串
            StringBuilder sql_cols = new StringBuilder(); //插入的字段
            StringBuilder sql_vals = new StringBuilder(); //插入的值

            //遍历所有公共属性的名字，查找与conditions中字符串相同的属性
            foreach (PropertyInfo pi in propertys) {
                //获取属性名
                string propName = pi.Name;

                //获取字段的值
                object objValue = pi.GetValue(model);

                //根据属性名，得到Model对象的属性值
                if (objValue == null) { continue; }     //如果该字段值为空，不能转为string，跳出循环，不构造SQL语句。
                string propValue = objValue.ToString(); //转为string

                //如果该字段为ID，不构造SQL语句。因为若ID作为自增标识/主键，则不可手动写入。
                if (propName.ToUpper().Equals("ID")) { continue; }

                //构造SQL语句             
                sql_cols.Append(string.Format(",[{0}]", propName)); //插入的字段
                sql_vals.Append(string.Format(",'{0}'", propValue));//插入的值，注意数字int同样可以加单引号
            }

            //构造SQL字符串：替换掉字符串中第1个逗号
            Regex regex = new Regex(",");
            string res = string.Format("INSERT INTO [{0}]( {1} ) VALUES ( {2} )",
                type.Name,
                regex.Replace(sql_cols.ToString(), "", 1),
                regex.Replace(sql_vals.ToString(), "", 1));

            return res;
        }

        /// <summary>
        /// 构造SQL语句：Delete
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        protected static string GenerateSql_Delete(T model, params string[] conditions)
        {
            // 获取泛型的具体类型
            Type type = typeof(T);

            //获取泛型的各个属性
            PropertyInfo[] propertys = type.GetProperties();

            //构造SQL字符串：无条件查询
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM [{0}]", type.Name);

            //如果传入的conditions长度为零，则认为是一个无条件删除语句
            if (conditions.Length == 0) {
                return sql.ToString();
            }

            //构造SQL字符串：追加WHERE关键字
            sql.Append(" WHERE ");

            //遍历所有公共属性
            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name;  //获取属性名
                //遍历conditions，查找与属性同名的项
                foreach (string con in conditions) {
                    if (con.ToUpper().Equals(propName.ToUpper()))//判断是否同名(都转为大写字母比较)
                    {
                        //构造SQL字符串
                        string propValue = pi.GetValue(model).ToString();//根据属性名，得到model对象的属性值
                        sql.Append(string.Format("AND [{0}] = '{1}' ", propName, propValue)); //注意数字int同样可以加单引号
                    }
                }
            }

            //构造SQL字符串：替换掉字符串中第1个'AND'
            Regex regex = new Regex("AND");
            string res = regex.Replace(sql.ToString(), "", 1);

            return res;
        }

        /// <summary>
        /// 构造SQL语句：Update(根据主键，更新[所有]其他字段 )
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected static string GenerateSql_UpdateByPK(T model, string PKName)
        {
            //得到泛型的具体类型和类属性集合
            Type type = typeof(T);
            PropertyInfo[] propertys = type.GetProperties();

            //构造SQL语句：修改内容、修改条件
            StringBuilder sql_dest = new StringBuilder(string.Format("UPDATE [{0}] SET ", type.Name));
            StringBuilder sql_condition = new StringBuilder();

            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name;
                object objValue = pi.GetValue(model);
                if (objValue == null) { continue; }
                string propValue = objValue.ToString();
                //当遇到指定主键时，写入‘修改条件’
                if (propName.ToUpper().Equals(PKName.ToUpper())) {
                    sql_condition.Append(string.Format("WHERE [{0}] = '{1}'", propName, propValue));
                    continue;
                }
                //当遇到普通字段时，写入‘修改内容’
                sql_dest.Append(string.Format(",[{0}] = '{1}' ", propName, propValue));
            }

            //拼接SQL语句
            string res = sql_dest.Append(sql_condition).ToString();

            //替换掉第一个逗号
            Regex regex = new Regex(",");
            res = regex.Replace(res.ToString(), "", 1);

            return res;
        }
        /// <summary>
        /// 构造SQL语句：Select
        /// </summary>
        /// <param name="conditions">条件查询参数</param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected static string GenerateSql_Select(T model, params string[] conditions)
        {
            // 获取泛型的具体类型
            Type type = typeof(T);

            //获取泛型的各个属性
            PropertyInfo[] propertys = type.GetProperties();

            //构造SQL字符串：无条件查询
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT * FROM [{0}] ", type.Name); //Model类名必须与表名相同；MSSQL数据库中表名加'[]'符号

            //如果传入的conditions长度为零或为null，则认为是一个无条件查询语句
            if (conditions.Length == 0 || conditions == null) {
                return sql.ToString();
            }

            //构造SQL字符串：追加WHERE关键字
            sql.Append(" WHERE ");

            //遍历所有公共属性的名字，查找与conditions中字符串相同的属性
            foreach (PropertyInfo pi in propertys) {
                string propName = pi.Name; //获取属性名
                foreach (string con in conditions) {
                    //检查conditions是否包含该属性名    
                    if (con.ToUpper().Equals(propName.ToUpper()))//全部转为大写字母进行比较
                    {
                        //构造SQL字符串：追加条件查询参数
                        string propValue = pi.GetValue(model).ToString();//根据属性名，得到model对象的属性值
                        sql.Append(string.Format("AND [{0}] = '{1}' ", propName, propValue)); //注意数字int同样可以加单引号
                    }
                }
            }

            //构造SQL字符串：替换掉字符串中第1个'AND'
            Regex regex = new Regex("AND");
            string res = regex.Replace(sql.ToString(), "", 1);
            return res;
        }

        /// <summary>
        /// 将DataTable转换成T模型
        /// 注意，T模型的各属性必须有{get;set;}函数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected static T ConvertToModel(DataTable dt)
        {
            //初始化为空
            T t = default(T);

            if (dt != null && dt.Rows.Count != 0) {
                //实例化泛型对象
                t = new T();

                // 获取泛型的具体类型   
                Type type = typeof(T);
                string tempName = "";
                //只反射第一行的结果
                DataRow dr = dt.Rows[0];
                // 获得泛型的所有公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历所有公共属性的名字，查找与DataTable列名相同的属性
                foreach (PropertyInfo pi in propertys) {
                    tempName = pi.Name;//获取属性名
                    if (dt.Columns.Contains(tempName))// 检查DataTable是否包含该属性名    
                    {
                        //如果该属性可写(有setter方法)，则把列的值赋值给该属性
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
        /// <summary>
        /// 转为List
        /// 注意，T模型的各属性必须有{get;set;}函数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertToList(DataTable dt)
        {
            //初始化为空
            List<T> ts = null;

            //实际上，如果查询结果为空，dataTable也有一行，存储了字段名
            if (dt != null) {

                //实例化集合
                ts = new List<T>();

                // 获取泛型的具体类型   
                Type type = typeof(T);
                string tempName = "";
                foreach (DataRow dr in dt.Rows) {
                    //实例化泛型对象
                    T t = new T();
                    // 获得泛型的所有公共属性      
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    //遍历所有公共属性的名字，查找与DataTable列名相同的属性
                    foreach (PropertyInfo pi in propertys) {
                        tempName = pi.Name;//获取属性名
                        if (dt.Columns.Contains(tempName))// 检查DataTable是否包含该属性名    
                        {
                            //如果该属性可写(有setter方法)，则把列的值赋值给该属性
                            if (pi.CanWrite) {
                                object value = dr[tempName];
                                if (value != DBNull.Value)
                                    pi.SetValue(t, value, null);
                            }

                        }
                    }
                    //遍历一次后，将泛型的Bean对象添加至集合
                    ts.Add(t);
                }
                return ts;
            }
            return ts;
        }
    }
}


