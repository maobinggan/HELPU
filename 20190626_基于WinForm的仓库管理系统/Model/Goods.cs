using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190626_基于WinForm的仓库管理系统.Model
{
    class Goods
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
        public string type { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int sum { get; set; }



        /// <summary>
        /// 
        /// </summary>

        public Goods()
        {
        }



        /// <summary>
        /// 
        /// </summary>
        public Goods(int id)
        {
            Id = id;
        }


        /// <summary>
        /// 
        /// </summary>
        public Goods(string name, string type, int sum)
        {
            this.name = name;
            this.type = type;
            this.sum = sum;
        }


        /// <summary>
        /// 
        /// </summary>

        public Goods(int id, string name, string type, int sum)
        {
            Id = id;
            this.name = name;
            this.type = type;
            this.sum = sum;
        }
    }
}
