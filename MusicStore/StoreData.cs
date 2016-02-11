using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;


namespace MusicStore
{
    [Serializable]
    class StoreData
    {
        public StoreData()
        {
            products = new List<IProduct>();
            pianos = new List<Piano>();
            guitars = new List<Guitar>();
        }
        public List<IProduct> products { get; set; }
        public List<Piano> pianos { get; set; }
        public List<Guitar> guitars { get; set; }
    }
}
