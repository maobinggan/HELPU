using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190625_基于WinForm的门店管理系统.Model
{
    class Staff
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string Gender { get; set; }
        public int Store_Id { get; set; }

        public Staff()
        {
        }

        public Staff(string staffName, string gender, int store_Id)
        {
            StaffName = staffName;
            Gender = gender;
            Store_Id = store_Id;
        }

        public Staff(int id, string staffName, string gender, int store_Id) : this(id)
        {
            StaffName = staffName;
            Gender = gender;
            Store_Id = store_Id;
        }

        public Staff(int id)
        {
            Id = id;
        }
    }
}
