﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成绩管理系统.Model
{
    class User
    {
        public string userName { get; set; }
        public string password { get; set; }

        public User()
        {
        }

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
