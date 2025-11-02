using practiceproject.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace practiceproject.Customer
{
    internal class CustomerUI
    {
        CustomerService service = new CustomerService();
        public void CustomerDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = CustomerMenu();
                if (option == "1")
                {
                    CustomerModel customer = TakeInput();
                    service.SaveCustomer(customer);
                }
                else if (option == "2")
                {
                    UpdateCustomer();
                }
                else if (option == "3")
                {
                    DeleteCustomer();
                }
                else if (option == "4")
                {
                    DisplayAll();
                }
                else if (option == "5")
                {
                    while (true)
                    {
                        Console.Clear();
                        string Option = AdvanceSearch();
                        if (Option == "1")
                        {
                            SearchByNameCustomer();
                        }
                        if (Option == "2")
                        {
                            SearchBYFirstCharacter();
                        }
                        if (Option == "3")
                        {
                            SearchBYNumber();
                        }
                        if (Option == "4")
                        {
                            SearchByAddress();
                        }
                        if (Option == "5")
                        {
                            
                        }
                        if (Option == "6")
                        {
                            break;
                        }
                    }
                }
                //else if (option == "6")
                //{
                //    break;
                //}
                else
                {
                    Console.WriteLine("Wrong option selected!");
                }
            }
        }
        public void UpdateCustomer()
        {
            Console.WriteLine("Enter customer name");
            string cname = Console.ReadLine();
            Console.WriteLine("Enter customer phonenumber");
            string phonenumber = Console.ReadLine();
            service.UpdateCustomer(cname, phonenumber);
        }
        public void DeleteCustomer()
        {
            Console.WriteLine("Enter customer name");
            string cname = Console.ReadLine();

            service.DeleteCustomer(cname);
        }
        public void DisplayAll()
        {
            List<CustomerModel> customers = service.GetAllData();
            foreach (CustomerModel c in customers)
            {
                Console.WriteLine(c.ToString());
            }
            Console.ReadKey();
        }
        public void SearchByNameCustomer()
        {
            Console.WriteLine("Enter customer name ");
            string name = Console.ReadLine();
            List<CustomerModel> filter = service.SearchCustomerByName(name);
            if(filter.Count > 0)
            {
                foreach (CustomerModel c in filter)
                {
                    Console.WriteLine(c.ToString());
                }
                
            }
            else
            {
                Console.WriteLine("Customer Not Found!");
            }
            Console.ReadKey();

        }
        public void SearchBYFirstCharacter()
        {
            Console.WriteLine("Enter customer first character ");
                char letter = char.Parse(Console.ReadLine());
            List<CustomerModel> filter = service.SearchCutomerByFirstName(letter);
            if( filter.Count > 0)
            {
                foreach(CustomerModel c in filter)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else
            {
                Console.WriteLine("Customer Not Found!");
            }
            Console.ReadKey();

        }
        public void SearchBYNumber()
        {
            Console.WriteLine("Enter customer phone number ");
                string number = Console.ReadLine();
            List<CustomerModel> filter = service.SearchCutomerByPhoneNumber(number);
            if( filter.Count > 0)
            {
                foreach(CustomerModel c in filter)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else
            {
                Console.WriteLine("Phone Number Not Found!");
            }
            Console.ReadKey();

        }
        public void SearchByAddress()
        {
            Console.WriteLine("Enter customer address ");
            string address = Console.ReadLine();
            List<CustomerModel> adrs = service.SearchCustomerByAddress(address);
            if( adrs.Count > 0)
            {
                foreach(CustomerModel ad in adrs)
                {
                    Console.WriteLine(ad.ToString());
                }
            }
            else
            {
                Console.WriteLine("Invalid Address!");
            }
            Console.ReadKey();
        }
        public CustomerModel TakeInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter customer name");
            string cname = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter customer phonenumber");
            string phonenumber = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter customer age");
            int age = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter customer address");
            string address = Console.ReadLine();

            //to make the process fast first we create the object and store the data
            //in the object and then we return the object
            CustomerModel customer = new CustomerModel(cname, phonenumber, age, address);
            return customer;
        }
        public string CustomerMenu()

        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("       Customer Management     ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1 Add ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("2 Update ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("3 Delete ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4 View All ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("5 Advance Search ");
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("6 Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;

        }
        public string AdvanceSearch()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 Find Customer by name ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2 Find Customer by First Character  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3 Find Customer by PhoneNumber ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("4 Find Customer by Address ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("5 Find Customer by Age ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6 Back ");
            Console.WriteLine("Enter your option ");
            string Option = Console.ReadLine();
            return Option;
           
        }

    }
}
