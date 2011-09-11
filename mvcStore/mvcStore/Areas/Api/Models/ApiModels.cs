using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcStore.Areas.Api.Models
{
    public class User
    {
        public int UserId { get; set; }
    }
    public class Card
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
    }
}