using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190626_基于WinForm的仓库管理系统.Model
{
    class User
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }


        /// <summary>
        /// 构造器
        /// </summary>
        public User()
        {
        }

        public User(int id)
        {
            Id = id;
        }


        /// <summary>
        /// 
        /// </summary>
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }


        /// <summary>
        /// 
        /// </summary>
        public User(int id, string userName, string password)
        {
            Id = id;
            this.userName = userName;
            this.password = password;
        }
    }
}
