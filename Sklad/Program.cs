using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sklad
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxProduct = 100;
            List<Product> products = new List<Product>();
            //products.Add(new Product{ productName = "milk", productVolume = 1 });
            //products.Add(new Product { productName = "sugar", productVolume = 2 });
            //products.Add(new Product { productName = "salt", productVolume = 3 });
            //products.Add(new Product { productName = "pig", productVolume = 4 });
            //products.Add(new Product { productName = "beef", productVolume = 5 });
            Store store = new Store(true, 0, maxProduct);
            Thread thPutProduct = new Thread(new ThreadStart(store.PutProduct));
            Thread thGetProduct = new Thread(new ThreadStart(store.GetProduct));
            Thread thGetProductCount = new Thread(new ThreadStart(store.GetProductCount));
            thGetProduct.Start();
            thPutProduct.Start();
            thGetProductCount.Start();
        }
    }

    public class Product : IEquatable<Product>
    {
        public string productName { get; set; }

        public int productVolume { get; set; }

        public override string ToString()
        {
            return "Name: " + productName +  "    Volume: " + productVolume;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Product objAsPart = obj as Product;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public int getProductVolume()
        {
            return productVolume;
        }
        public bool Equals(Product other)
        {
            if (other == null) return false;
            return (this.productName.Equals(other.productName));
        }
    }
}
