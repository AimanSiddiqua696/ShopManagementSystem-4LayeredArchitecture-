using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Order
{
    internal class OrderService
    {
        private readonly OrderRepo _repo = new OrderRepo();
       public List<OrderModel> GetAllOrder()
        {
            return _repo.GetAllOrders();
        }
        public List<OrderModel> GetOrdersByCustomerName(string customerName)
        {
            List<OrderModel> orders = _repo.GetAllOrders();
            List<OrderModel> model = new List<OrderModel>();
            foreach (OrderModel order in orders)
            {
                if (order.customername == customerName)
                {
                    model.Add(order);
                }
            }
            return model;
        }
        public bool SaveOrder(OrderModel order) //order save in file
        {
            OrderRepo orderrepo = new OrderRepo();
            orderrepo.Save(order);
            Console.WriteLine("Order saved successfully!");
            return true;
        }
        public List<OrderModel> CheckNameAndCount(string name, int count)
        {
            List<OrderModel> check = _repo.GetAllOrders();
            List<OrderModel> namecount = new List<OrderModel>();
            foreach (OrderModel order in check)
            {
                if (order.customername == name && count > 5)
                {
                    namecount.Add(order);
                }
            }
            return namecount;
        }
        //public List<OrderModel>
    }
}
