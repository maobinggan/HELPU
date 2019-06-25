using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190625_基于WinForm的门店管理系统.Model
{
    class View_Staff_Store
    {
        public int Staff_Id { get; set; }
        public string Staff_Name { get; set; }
        public string Staff_Gender { get; set; }
        public int Store_Id { get; set; }
        public string Store_Name { get; set; }

        public View_Staff_Store()
        {
        }

        public View_Staff_Store(int Staff_Id, string staff_Name, string staff_Gender, int store_Id, string store_Name)
        {
            Staff_Id = Staff_Id;
            Staff_Name = staff_Name;
            Staff_Gender = staff_Gender;
            Store_Id = store_Id;
            Store_Name = store_Name;
        }
    }
}
