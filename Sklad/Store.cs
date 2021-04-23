using System;
using System.Collections.Generic;
using System.Threading;

namespace Sklad
{
    public class Store
    {
        readonly Boolean enabled = true;
        private readonly object Lock = new object();
        readonly Random rng = new Random();
        List<string> products = new List<string>();
        private int productVolume;
        private int product = 0;
        private int maxProduct;

        public Store(bool enabled, int product, int maxProduct)
        {
            this.enabled = enabled;
            this.product = product;
            this.maxProduct = maxProduct;
        }

        public void PutProduct()
        {
            while (enabled)
            {
                if(product <= maxProduct)
                {
                    for (int i = 0; i < rng.Next(1, 5); i++)
                    {
                        lock (Lock)
                        {
                            productVolume = rng.Next(1, 6);
                            product += productVolume;
                            string productName = "p" + productVolume;
                            products.Add(productName);
                            Console.WriteLine("put" + " Name: " + productName + " Volume: " + productVolume);
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        public void GetProduct()
        {
            while (enabled)
            {
                lock (Lock)
                {
                    for(int i=0; i<rng.Next(1, 5); i++)
                    {
                        productVolume = rng.Next(1, 6);
                        string productName = "p" + productVolume;
                        if (products.Contains(productName) == true)
                        {
                            product -= productVolume;
                            products.Remove(productName);
                            Console.WriteLine("get" + " Name: " + productName + " Volume: " + productVolume);
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        public void GetProductCount()
        {
            while (enabled)
            {
                lock (Lock)
                {
                    Console.WriteLine(product);
                }
                Thread.Sleep(5000);
            }
        }
    }
}
