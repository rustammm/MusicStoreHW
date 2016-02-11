using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IProduct
    {
        string ProductType { get; }

        int Price { get; set; }

        int Count { get; set; }
        
        int ID { get; set; }

        int getPrice();


    }

}
