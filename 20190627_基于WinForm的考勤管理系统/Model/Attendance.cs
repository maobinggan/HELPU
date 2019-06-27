using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190627_基于WinForm的考勤管理系统.Model
{
    class Attendance
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string date { get; set; }

        public Attendance()
        {
        }

        public Attendance(int id)
        {
            Id = id;
        }

        public Attendance(string name, string gender, string date)
        {
            this.name = name;
            this.gender = gender;
            this.date = date;
        }

        public Attendance(int id, string name, string gender, string date)
        {
            Id = id;
            this.name = name;
            this.gender = gender;
            this.date = date;
        }
    }
}
