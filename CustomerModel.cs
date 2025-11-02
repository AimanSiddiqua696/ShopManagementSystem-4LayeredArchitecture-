using practiceproject.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Class
{
    internal class CustomerModel
    {
        private string cname;
        private string phonenumber;
        private int age;
        private string address;
        public List<ProductModel> products = new List<ProductModel>();

        public CustomerModel()
        {

        }
        public CustomerModel(string cname, string phonenumber, int age, string address)
        {
            this.cname = cname;
            this.phonenumber = phonenumber;
            this.age = age;
            this.address = address;
        }
        public void SetName(string cname)
        {
            this.cname = cname;
        }
        public string GetName()
        {
            return this.cname;
        }
        public void SetPhoneNumber(string phonenumber)
        {
            this.phonenumber = phonenumber;
        }
        public string GetPhoneNumber()
        {

            return this.phonenumber;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
        public int GetAge()
        {
            return this.age;
        }
        public void SetAddress(string address)
        {
            this.address = address;

        }
        public string GetAddress()
        {
            return this.address;

        }


        public override string ToString()
        {

            return $"{cname},{phonenumber},{age},{address}";
        }

    }


}

