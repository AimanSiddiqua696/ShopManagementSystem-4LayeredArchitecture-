using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Order
{
    internal class OrderItem
    {
        public string product;

        public int quantity;
        public int salePrice;
        public OrderItem()
        {

        }
        public OrderItem(string product, int quantity, int salePrice)
        {
            this.product = product;

            this.quantity = quantity;
            this.salePrice = salePrice;

        }
        public override string ToString()
        {
            return $"{product},{quantity},{salePrice}";
        }
    }
}

