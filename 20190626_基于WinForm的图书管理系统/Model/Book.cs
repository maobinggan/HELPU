
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190626_基于WinForm的图书管理系统.Model
{
    class Book
    {
        /// <summary>
        /// 图书名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        public string press { get; set; }
        public int Id { get; internal set; }

        public Book(string name, string author, string press)
        {
            this.name = name;
            this.author = author;
            this.press = press;
        }

        public Book(int id, string name, string author, string press) : this(id)
        {
            this.name = name;
            this.author = author;
            this.press = press;
        }

        public Book(int id)
        {
            this.Id = id;
        }

        public Book()
        {
        }

    }
}
