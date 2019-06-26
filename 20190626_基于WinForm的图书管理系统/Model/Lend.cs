using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190626_基于WinForm的图书管理系统.Model
{
    class Lend
    {
        public int id { get; set; }
        public string name { get; set; }
        public string bookname { get; set; }
        public string date { get; set; }

        public Lend()
        {
        }

        public Lend(int id)
        {
            this.id = id;
        }

        public Lend(string name, string bookname, string date)
        {
            this.name = name;
            this.bookname = bookname;
            this.date = date;
        }

        public Lend(int id, string name, string bookname, string date)
        {
            this.id = id;
            this.name = name;
            this.bookname = bookname;
            this.date = date;
        }
    }
}
