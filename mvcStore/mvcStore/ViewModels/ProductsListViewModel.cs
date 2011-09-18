using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcStore.Models;

namespace mvcStore.ViewModels
{
    public class ProductsListViewModel
    {
        public List<Product> Products { get; set; }
        public Dictionary<int,string> ProductTypes { get; set; }
    }
}