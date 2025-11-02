using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Order
{
    internal class OrderModel
    {
        public string customername;
        public string contact;
        public string address;
        public List<OrderItem> ordersList = new List<OrderItem>();
        public OrderModel()
        {

        }
        public OrderModel(string customername, string contact, string address)
        {
            this.customername = customername;
            this.contact = contact;
            this.address = address;

        }
        public void AddOrder(OrderItem item)
        {
            ordersList.Add(item);
        }
        public override string ToString()
        {
            return $"{customername},{contact},{address}";
        }

    }
}
    