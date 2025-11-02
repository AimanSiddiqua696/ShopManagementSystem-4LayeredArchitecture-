using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceproject.Product
{
    internal class ProductUI
    {
         ProductService service = new ProductService();
        public void ProductDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = ProductMenu();
                if (option == "1")
                {
                    ProductModel p = TakeInput();
                    service.SaveProduct(p);
                }
                else if (option == "2")
                {
                    UpdateProduct();
                }
                else if (option == "3")
                {
                    DeleteProduct();
                }
                else if (option == "4")
                {
                    DisplayAll();
                }

                else if (option == "5")
                {
                    SearchProductByNames();
                }

                else if (option == "6")
                {
                    while (true)
                    {
                        Console.Clear();
                        string Option = AdvanceOption();
                        if (Option == "1")
                        {
                            SearchProductByNames();
                        }
                        else  if (Option == "2")
                        {
                            SearchProductPrice();
                        }
                        else if (Option == "3")
                        {
                            DisplayPriceRange();
                        }
                        else if (Option == "4")
                        {
                            PriceDiff();
                        }
                        else if (Option == "5")
                        {
                            SubStringChar();
                        }
                        else if (Option == "6")
                        {
                            break;
                        }
                        //}
                        //}
                        else if (option == "7")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("INVALID OPTION!");
                        }
                    }
                }
            }
        }
        
        public void SearchByName()
        {
            Console.WriteLine("Enter product name ");
            string name = Console.ReadLine();
          

            ProductModel product = service.SearchByName(name);
            if (product == null)
            {
                Console.WriteLine("Product is not found!");

            }
            else
            {
                Console.WriteLine(product.ToString());
                Console.ReadKey();
            }
        }
        public void UpdateProduct()
        {
            Console.WriteLine("Enter your product name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price ");
            float price = float.Parse(Console.ReadLine());
            service.UpdateProductPrice(name, price);

        }
        public void DeleteProduct()
        {
            Console.WriteLine("Enter product name ");
            string name = Console.ReadLine();
            service.DeleteProduct(name);

        }
        public void DisplayAll()
        {
            List<ProductModel> products = service.GetAllData();
            foreach (ProductModel product in products)
            {
                Console.WriteLine(product.ToString());
            }
                Console.ReadKey();
        }
        public void SearchProductByNames()
        {
            
            Console.WriteLine("Enter product name");
            string name = Console.ReadLine();

            List<ProductModel> filter = service.SearchProductByName(name);
            if (filter.Count > 0)
            {
                foreach (var product in filter)
                {
                    Console.WriteLine(product.ToString());
                }
            }
            else
            {
                Console.WriteLine("Invalid name!");
            }
                Console.ReadKey();
            
        }
        public void SearchProductPrice()
        {
            Console.WriteLine("Enter Product price");
            float saleprice = float.Parse(Console.ReadLine());
            List<ProductModel> filter = service.SearchProductByPrice(saleprice);
            if(filter.Count > 0)
            {
                foreach (ProductModel price in filter)
                {
                    Console.WriteLine(price.ToString());
                }
            }
            else
            {
                Console.WriteLine("Invalid price!");
            }
            Console.ReadKey();
        }
        public void DisplayPriceRange()
        {
            Console.WriteLine("Enter minimum price");
            float minprice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter maximum price");
            float maxprice = float.Parse(Console.ReadLine());
            List<ProductModel> filter = service.PriceRange(minprice, maxprice);
            if(filter.Count > 0)
            {
                foreach (ProductModel price in filter)
                {
                    Console.WriteLine(price);
                }
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
            Console.ReadKey();

        }
        public void PriceDiff()
        {
            //Console.WriteLine("Enter sale price");
            //int saleprice = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter purchase price");
            //int purchaseprice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price difference");
            int price = int.Parse(Console.ReadLine());
            List<ProductModel> filter = service.PriceDifference( price);
            if(filter.Count > 0)
            {
                foreach (ProductModel diff in filter)
                {
                    Console.WriteLine(diff.ToString());
                }
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
            Console.ReadKey();

        }
        public void SubStringChar()
        {
            Console.WriteLine("Enter the character in string");
            char c = char.Parse(Console.ReadLine());
            List<ProductModel> filter = service.SubString(c);
            if(filter.Count > 0)
            {
                foreach(ProductModel sub in filter)
                {
                    Console.WriteLine(sub.GetName());
                }
                
            }
            else
            {
                Console.WriteLine("Invalid character ");
            }
            Console.ReadKey();
        }

        public ProductModel TakeInput()
        {
            Console.WriteLine("Enter product name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product description ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter purchase price ");
            float purchaseprice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter sale price ");
            float saleprice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter discount price ");
            float discount = float.Parse(Console.ReadLine());
            ProductModel p = new ProductModel(name, description, purchaseprice, saleprice, discount);
            return p;
            
        }
        public string ProductMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("         Product Management"          );
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1 Add");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("2 Update");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("3 Delete All");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4 Display All");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("5 Find by name");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("6 Advance Option");
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("7 Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }
        public string AdvanceOption()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 Search product by name ");
            //string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("2 Search all products by price ");
            //float price = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("3 Find products between a given price range");
            //float range = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("4 Find products by price difference ");
            //float difference = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("5 Find products by substring ");
            //float substring = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6 Back");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string Option = Console.ReadLine();
            return Option;

        }
           
    }
}
