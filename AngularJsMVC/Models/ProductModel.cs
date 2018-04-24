using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsMVC.Models
{
    public class ProductModel
    {

        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
        public string  CategoryName { get; set; }
    }
}