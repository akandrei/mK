using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}