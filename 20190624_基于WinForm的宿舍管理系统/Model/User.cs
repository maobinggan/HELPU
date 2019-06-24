using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190624_基于WinForm的宿舍管理系统.Model
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User()
        {

        }

        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public User(int id)
        {
            Id = id;
        }

        public User(int id, string userName, string password) : this(id)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
