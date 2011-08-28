using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public ProductKind Kind { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }

    public enum ProductKind
    {
        Good,
        Service
    }
}