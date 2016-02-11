using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class Guitar : IProduct
    {
        public Guitar(int customID)
        {
            Count = 0;
            ID = customID;
            Price = 0;
            type = GuitarType.Acoustic;

        }
        public enum GuitarType { Acoustic, Bass, Electric }       
        

        public int Count { get; set; }
        public int ID { get; set; }
        public int Price { get; set; }

        public string ProductType
        {
            get
            {
                return "Guitar";
            }
        }

        public string Color { get; set; }


        public GuitarType type { get; set; }
          


        public int getPrice()
        {
            return Price * Count;
        }
    }
}
