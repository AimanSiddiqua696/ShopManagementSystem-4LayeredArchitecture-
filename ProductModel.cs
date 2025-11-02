using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Product
{
    internal class ProductModel
    {
        private string name;
        private string description;
        private float purchaseprice;
        private float saleprice;
        private float discount;
        public ProductModel()
        {

        }
        public ProductModel(string name, string description, float purchaseprice, float saleprice, float discount)
        {
            this.name = name;
            this.description = description;
            this.purchaseprice = purchaseprice;
            this.saleprice = saleprice;
            this.discount = discount;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetDescription()
        {
            return this.description;
        }
        public void SetPurchasePrice(float purchaseprice)
        {
            this.purchaseprice = purchaseprice;
        }
        public float GetPurchasePrice()
        {
            return this.purchaseprice;
        }
        public void SetSalePrice(float saleprice)
        {
            this.saleprice = saleprice;
        }
        public float GetSalePrice()
        {
            return this.saleprice;
        }
        public float GetDiscount()
        {
            return this.discount;
        }
        public override string ToString()
        {
            return $"{name},{description},{purchaseprice},{saleprice},{discount}";
        }
    }
}
