using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class Piano : IProduct
    {
        public Piano(int customID)
        {
            Count = 0;
            ID = customID;
            Price = 0;
            Weight = 0;
            KeysNumber = 0;
        }
        public int Count { get; set; }
        public int ID { get; set; }
        public int Price { get; set; }

        public string ProductType
        {
            get
            {
                return "Piano";
            }
        }

        public int Weight { get; set; }
        public int KeysNumber { get; set; }

        public int getPrice()
        {
            return Price * Count;
        }
    }
}
