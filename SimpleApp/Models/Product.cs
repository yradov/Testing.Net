﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public static Product[] GetProducts()
        {
            Product kayak = new() { Name = "Kayak", Price = 275M };

            Product lifejacket = new() { Name = "Lifejacket", Price = 48.95M };

            return new Product[] { kayak, lifejacket };
        }
    } 
}
