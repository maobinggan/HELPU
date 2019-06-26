using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190626_基于WinForm的仓库管理系统.Model
{
    class Material
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
        public string Price { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int sum { get; set; }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="sum"></param>
        public Material(string name, string price, int sum)
        {
            this.name = name;
            Price = price;
            this.sum = sum;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Material(int id)
        {
            Id = id;
        }



        /// <summary>
        /// 
        /// </summary>
        public Material()
        {
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="sum"></param>
        public Material(int id, string name, string price, int sum)
        {
            Id = id;
            this.name = name;
            Price = price;
            this.sum = sum;
        }
    }
}
