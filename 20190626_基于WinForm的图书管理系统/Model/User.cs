using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190626_基于WinForm的图书管理系统.Model
{
    class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public User(int id)
        {
            this.id = id;
        }

        public User()
        {
        }

        public User(int id, string userName, string password)
        {
            this.id = id;
            this.userName = userName;
            this.password = password;
        }
    }
}
