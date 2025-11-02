using practiceproject.Class;
using practiceproject.Customer;
using practiceproject.Order;
using practiceproject.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Order
{
    internal class OrderUI
    {
        OrderService service = new OrderService();
        public void OrderDriver()
        {
            while (true)
            {
                string option = ViewOrdersHistory();
                Console.Clear();
                if (option == "1")
                {
                    ViewAllOrders();
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    ViewOrdersByCustomerName();
                    Console.ReadKey();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
        }
        public void CreateOrderDriver()
        {
            while (true)
            {
                string option = CreateOrderMenu();
                Console.Clear();
                if (option == "1")
                {
                    CreateNewOrder();
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
            }
        }
        public string CreateOrderMenu()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("Create new Sale (Order) ");
            Console.WriteLine("************************************");
            Console.WriteLine("1 Create New Order");
            Console.WriteLine("2 Go back to main menu ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("************************************");
            Console.WriteLine("Enter your choice: ");
            return Console.ReadLine();
        }

        public void CreateNewOrder()
        {
            Console.WriteLine("Enter customer name if customer is present");
            string name = Console.ReadLine();
            //LOAD ALL EXISTING ORDERS
            List<OrderModel> allorders = service.GetAllOrder();
            //CHECK IF THE CUSTOMER ALREADY EXISTS
            OrderModel existingCustomer = null;
            foreach (var order in allorders)
            { 
                if (order.customername == name)
                {
                    existingCustomer = order;
                    break;
                }
        }
            //WHEN CUSTOMER ALREADY EXISTS
            if (existingCustomer != null)
            {
                Console.WriteLine("When customer found!");
                Console.WriteLine($"CustomerName: {existingCustomer.customername}");
                Console.WriteLine($"CustomerName: {existingCustomer.contact}");
                Console.WriteLine($"CustomerName: {existingCustomer.address}");
           if( existingCustomer.ordersList.Count > 0)
                {
                    Console.WriteLine("products that took by the above customer");
                    foreach (var item in existingCustomer.ordersList)
                    {
                        Console.WriteLine($"Products:{item.product}, Quantity:{item.quantity}, Price: {item.quantity * item.salePrice}");
                    }
                }
                else
                {
                    Console.WriteLine("No products found for this customer");
                }
                Console.WriteLine("You cannot add more products for an existing customer");
            }
            //WHEN CUSTOMER NOT FOUND
            else
            {
                Console.WriteLine("If the above customer not found! then please enter  a new customer");
                Console.WriteLine("Enter contact number; ");
                string contact = Console.ReadLine();
                Console.WriteLine("Enter address: ");
                string address = Console.ReadLine();
                //CREATE A NEW CUSTOMER ORDER
                OrderModel currentOrder = new OrderModel(name, contact, address);
                while(true)
                {
                    Console.WriteLine("Enter product name:");
                    string productname = Console.ReadLine();
                    if (productname.ToLower() == "done")
                        break;
                    Console.WriteLine("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter sale price: ");
                    int price = int.Parse(Console.ReadLine());
                    //NOW WE ADD THE ITEM
                    OrderItem item = new OrderItem(productname, quantity, price);
                    currentOrder.AddOrder(item);
                    Console.WriteLine("Congratulations Product Added Successfully!");

                }
                service.SaveOrder(currentOrder);
                Console.WriteLine($"Order saves successfully for new customer: {currentOrder.customername}");
                //now we display all added products after saving
                if(currentOrder.ordersList.Count > 0)
                {
                    Console.WriteLine("Products added for this customer:");
                    foreach(var item in currentOrder.ordersList)
                    {
                        Console.WriteLine($"Product:{item.product}, Quantity:{item.quantity}, Price: {item.quantity * item.salePrice}");
                    }
                }
                else
                {
                    Console.WriteLine("No products were added for this customer");
                }
            }

          
        }
       

        static string ViewOrdersHistory()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("View order history");
            Console.WriteLine("*********************");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. View Orders by Customer Name");
            Console.WriteLine("3. Go Back to Main Menu");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("********************");
            Console.WriteLine("Enter your choice:");
            string option = Console.ReadLine();
            return option;
        }
        public void DisplayAll(List<OrderModel> OrdersList)
        {
            foreach (var order in OrdersList)
            {
                Console.WriteLine(order.ToString());
                foreach (var items in order.ordersList)
                {
                    Console.WriteLine(items.ToString()); //items are stored in order
                }
            }
            Console.WriteLine();
        }
    
public void ViewAllOrders()
        {
            List<OrderModel> orders = service.GetAllOrder();
            DisplayAll(orders);
            Console.ReadKey();
        }
        public void ViewOrdersByCustomerName()
        {
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();
            List<OrderModel> orders = service.GetOrdersByCustomerName(name);
            DisplayAll(orders);
            Console.ReadKey();
        }
    }
}
