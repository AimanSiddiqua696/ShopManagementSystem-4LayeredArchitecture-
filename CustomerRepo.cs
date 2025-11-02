using practiceproject.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Customer
{
    internal class CustomerRepo
    {
        private readonly string file = @"C:\Users\User\Desktop\AimanSiddiqua\customers.txt";
        public CustomerRepo()
        {

        }
        public void SaveInFile(CustomerModel customer) //save the data for a single object in a file
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(customer.ToString());

            }

        }
        public void SaveAllDataIntoFile(List<CustomerModel> customers)
        {
            //this code of lines also delete all the data from the file
            //means empty the file first and then foreach loop will run
            //using (StreamWriter stream = new StreamWriter(file, false))
            //{
            //    stream.Write(file, "");
            //        }
            //or instead of writing above code to empty the file we can only write a single line of code which is more good
            File.WriteAllText(file, ""); //this line delete all the data from the file
            foreach (CustomerModel customer in customers)
            {
                SaveInFile(customer);
            }
        }

        public List<CustomerModel> GetCustomersFromFile() //read the all data from the file and load into the list and return the list
                                                          //when we need all the data from the file , we call the function it will
                                                          //create a list load  all the data from the file into a list and return you a list 
        {
            List<CustomerModel> customersLists = new List<CustomerModel>();
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    if (line.Length > 5)
                    {
                        string[] parts = line.Split(',');
                        string customerName = parts[0];
                        string phonenumber = parts[1];
                        int age = int.Parse(parts[2]);
                        string address = parts[3];


                        //now we will create an object and then you will add this object to this list 
                        CustomerModel customerModel = new CustomerModel(customerName, phonenumber, age, address);
                        customersLists.Add(customerModel);
                    }


                }
            }
            return customersLists;
        }
    }
}
