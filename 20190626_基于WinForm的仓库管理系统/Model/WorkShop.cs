using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190626_基于WinForm的仓库管理系统.Model
{
    class WorkShop
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string master { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int sum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public WorkShop(int id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="sum"></param>
        public WorkShop(string name, string master, int sum)
        {
            this.name = name;
            this.master = master;
            this.sum = sum;
        }

        /// <summary>
        /// 
        /// </summary>
        public WorkShop()
        {
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// 
        /// <param name="type"></param>
        /// <param name="sum"></param>
        public WorkShop(int id, string name, string master, int sum)
        {
            Id = id;
            this.name = name;
            this.master = master;
            this.sum = sum;
        }
    }
}
