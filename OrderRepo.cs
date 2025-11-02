using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Order
{
    internal class OrderRepo
    {
        private readonly string _file = @"C:\Users\User\Desktop\AimanSiddiqua\order.txt";

        public void Save(OrderModel order)
        {
            using (StreamWriter writer = new StreamWriter(_file, true))
            {
                string customerdata = $"customer,{order.customername},{order.contact},{order.address}";
                writer.WriteLine(customerdata);
                foreach (OrderItem items in order.ordersList)
                {
                    string line = $"item,{items.product},{items.quantity},{items.salePrice},{items.quantity * items.salePrice}";
                    writer.WriteLine(line);
                }
            }
        }
        public List<OrderModel> GetAllOrders()
        {

            List<OrderModel> orders = new List<OrderModel>();
            using (StreamReader reader = new StreamReader(_file))
            {
                string line = "";
                OrderModel temporder = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("customer"))
                    {
                        string[] parts = line.Split(',');
                        string name = parts[1];
                        string contact = parts[2];
                        string address = parts[3];
                        temporder = new OrderModel(name, contact, address);
                        orders.Add(temporder);
                    }
                    else if (line.StartsWith("item"))
                    {
                        string[] parts = line.Split(',');

                        string product = parts[1];
                        int quantity = int.Parse(parts[2]);
                        int price = int.Parse(parts[3]);
                        OrderItem obj = new OrderItem(product, quantity, price);
                        temporder.AddOrder(obj);
                    }
                }
                return orders;
            }
        }
    }
}
