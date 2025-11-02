using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace practiceproject.Product
{
    internal class ProductRepo
    {
        private readonly string file = @"C:\Users\User\Desktop\pro.txt";
        public ProductRepo()
        {

        }
        public void SaveInFile(ProductModel product)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(product.ToString());
            }
        }
        public void SaveAllDataIntoFile(List<ProductModel> Products)
        {
            File.WriteAllText(file, "");
            foreach(ProductModel product in Products)
            {
                SaveInFile(product);
            }
        }
        public List<ProductModel> GetProductsFromFile()
        {
            List<ProductModel> productlist = new List<ProductModel>();
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    if (line.Length > 5)
                    {
                        string[] parts = line.Split(',');

                        string productname = parts[0];
                        string desc = parts[1];
                        float purchaseprice = float.Parse(parts[2]);
                        float saleprice = float.Parse(parts[3]);
                        float discount = float.Parse(parts[4]);

                        ProductModel product = new ProductModel(productname, desc, purchaseprice, saleprice, discount);
                        productlist.Add(product);
                    }
                }
            }
                //Console.WriteLine("Total products are "+productlist.Count);
            return productlist;

            }
        }
    }

