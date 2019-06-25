using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190625_基于WinForm的门店管理系统.Model
{
    class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreAddr { get; set; }
        public string StoreMaster { get; set; }

        public Store()
        {
        }

        public Store(int id)
        {
            Id = id;
        }

        public Store(int id, string storeName, string storeAddr, string storeMaster) : this(id)
        {
            StoreName = storeName;
            StoreAddr = storeAddr;
            StoreMaster = storeMaster;
        }

        public Store(string storeName, string storeAddr, string storeMaster)
        {
            StoreName = storeName;
            StoreAddr = storeAddr;
            StoreMaster = storeMaster;
        }

    }
}
