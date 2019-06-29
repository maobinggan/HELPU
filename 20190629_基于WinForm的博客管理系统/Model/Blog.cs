using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190629_基于WinForm的博客管理系统.Model
{
    class Blog
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string date { get; set; }

        public Blog()
        {
        }

        public Blog(int id)
        {
            Id = id;
        }

        public Blog(string name, string author, string date)
        {
            this.name = name;
            this.author = author;
            this.date = date;
        }

        public Blog(int id, string name, string author, string date)
        {
            Id = id;
            this.name = name;
            this.author = author;
            this.date = date;
        }
    }
}
