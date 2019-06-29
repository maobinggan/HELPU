using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190629_基于WinForm的博客管理系统.Model
{
    class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public User()
        {
        }

        public User(int id)
        {
            Id = id;
        }

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public User(int id, string userName, string password)
        {
            Id = id;
            this.userName = userName;
            this.password = password;
        }
    }
}
