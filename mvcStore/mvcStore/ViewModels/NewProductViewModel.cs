using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStore.Models;

namespace mvcStore.ViewModels
{
    public class NewProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> ProductTypes { get; set; }
        public string SelectedTypeId { get; set; }
    }
}