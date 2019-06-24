using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190624_基于WinForm的宿舍管理系统.Model
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string SCode { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DormNo { get; set; }
        public string RoomNo { get; set; }

        public Accommodation()
        {
        }

        public Accommodation(int id)
        {
            Id = id;
        }

        public Accommodation(string sCode, string name, string gender, string dormNo, string roomNo)
        {
            SCode = sCode;
            Name = name;
            Gender = gender;
            DormNo = dormNo;
            RoomNo = roomNo;
        }

        public Accommodation(int id, string sCode, string name, string gender, string dormNo, string roomNo) : this(id)
        {
            SCode = sCode;
            Name = name;
            Gender = gender;
            DormNo = dormNo;
            RoomNo = roomNo;
        }
    }
}
