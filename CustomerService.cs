using practiceproject.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Customer
{
    internal class CustomerService
    {
        private CustomerRepo _repo = new CustomerRepo();
        public CustomerService()
        {
            //_repo = new CustomerRepo();
        }
        public List<CustomerModel> GetAllData() //when we call this service's function then this
                                                //function will ask repo to load the data from the  file
        {
            return _repo.GetCustomersFromFile();
        }
        public void SaveCustomer(CustomerModel customer)
        {
            //check if customer already exists
            _repo.SaveInFile(customer);
        }
        public CustomerModel SearchByName(string cname)
        {
            foreach (CustomerModel customer in _repo.GetCustomersFromFile())
            {
                if (customer.GetName() == cname)
                {
                    return customer;
                }
            }
            return null;
        }
        public bool UpdateCustomer(string cname, string phonenumber)
        {
            List<CustomerModel> customers = _repo.GetCustomersFromFile();
            foreach (CustomerModel customer in customers)
            {
                if (customer.GetName() == cname)
                {
                    customer.SetPhoneNumber(phonenumber);
                    _repo.SaveAllDataIntoFile(customers); //this function update the file
                    return true;
                }
            }
            return false;
        }
        public bool DeleteCustomer(string cname)
        {
            List<CustomerModel> customers = _repo.GetCustomersFromFile();
            int count = 0;
            foreach (CustomerModel customer in customers)
            {
                if (customer.GetName() == cname)
                {
                    customers.RemoveAt(count);
                    _repo.SaveAllDataIntoFile(customers);
                    return true;
                }
                count++;
            }
            return false;
        }
        public List<CustomerModel> SearchCustomerByName(string name)
        {
            List<CustomerModel> customer = _repo.GetCustomersFromFile();
            List<CustomerModel> Name = new List<CustomerModel>();

            foreach (CustomerModel n in customer)
            {
                if (n.GetName() == name)
                {
                    Name.Add(n);
                }

            }
            return Name;
        }
        //Find Customer by First Character
        //public List<CustomerModel> SearchCutomerByFirstName(char first)
        //{
        //    List<CustomerModel> Customer = _repo.GetCustomersFromFile();
        //    List<CustomerModel> Cust = new List<CustomerModel>();
        //    foreach(CustomerModel f in Customer)
        //    {
        //        string name = f.GetName();
        //        if(f.GetName() == name)
        //        {
        //            for(int i = 0; i < name.Length ; i++)

        //                {
        //                if (name[i] == first)
        //                {
        //                    Cust.Add(f);
        //                }
        //            }
        //            Cust.Add(f);
        //        }
        //    }
        //    return Cust;
        //}
        //Find Customer by First Character
        public List<CustomerModel> SearchCutomerByFirstName(char first)
        {
            List<CustomerModel> Customer = _repo.GetCustomersFromFile();
            List<CustomerModel> Cust = new List<CustomerModel>();
            foreach (CustomerModel f in Customer)
            {
                string name = f.GetName();
                if (name.Length > 0 && name[0] == first)

                {

                    Cust.Add(f);
                }
            }
            return Cust;
        }
        // Find Customer by Phone Number
        public List<CustomerModel> SearchCutomerByPhoneNumber(string number)
        {
            List<CustomerModel> Customer = _repo.GetCustomersFromFile();
            List<CustomerModel> Cust = new List<CustomerModel>();
            foreach (CustomerModel p in Customer)
            {
                if (p.GetPhoneNumber() == number)

                {

                    Cust.Add(p);
                }
            }
            return Cust;
        }
        //Find Customer by Address
        public List<CustomerModel> SearchCustomerByAddress(string address)
        {
            List<CustomerModel> Address = _repo.GetCustomersFromFile();
            List<CustomerModel> Customers = new List<CustomerModel>();
            foreach(CustomerModel a in Address)
            {
                if(a.GetAddress() == address)
                {
                    Customers.Add(a);
                }
            }
            return Customers;
        }
    }
}

