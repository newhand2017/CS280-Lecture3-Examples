using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public class Order
    {
        public int Id;
        public Customer Customer;
        public List<Product> ProductList = new List<Product>();
    }
}