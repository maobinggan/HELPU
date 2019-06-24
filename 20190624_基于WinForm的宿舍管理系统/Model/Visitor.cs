using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190624_基于WinForm的宿舍管理系统.Model
{
    public class Visitor
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string dormNo { get; set; }
        public string reason { get; set; }
        public string date { get; set; }

        public Visitor()
        {
        }

        public Visitor(string name, string dormNo, string reason, string date)
        {
            this.name = name;
            this.dormNo = dormNo;
            this.reason = reason;
            this.date = date;
        }

        public Visitor(int id, string name, string dormNo, string reason, string date) : this(id)
        {
            this.name = name;
            this.dormNo = dormNo;
            this.reason = reason;
            this.date = date;
        }

        public Visitor(int id)
        {
            Id = id;
        }
    }
}
