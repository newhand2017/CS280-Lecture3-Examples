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

        public float GetTotal()
        {
            float total = 0.0f;

            foreach (Product product in this.ProductList)
            {
                total = total + product.Price;
            }
            return total;
        }

        public string GetOrderDetail()
        {
            string orderDetail = string.Empty;
            orderDetail = string.Format("點餐明細 : \n");

            //新增資訊
            foreach (Product product in this.ProductList)
            {
                orderDetail += string.Format("{0} : {1} 元\n", product.Name, product.Price);
            }
            //小計
            orderDetail += string.Format("結帳金額 : {0}\n", GetTotal());
            //
            return orderDetail;
        }
    }
}