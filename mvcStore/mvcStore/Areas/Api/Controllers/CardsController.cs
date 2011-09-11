using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStore.Areas.Api.Models;
using mvcStore.Models;

namespace mvcStore.Areas.Api.Controllers
{
    public class CardsController : Controller
    {
        private StoreEntities db = new StoreEntities();

        //
        // GET: /Api/Cards/

        public JsonResult Index()
        {
            return this.Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Api/Cards/5

        public JsonResult Details(int id)
        {
            return this.Json(db.Products.Find(id), JsonRequestBehavior.AllowGet);
        }
    }
}
