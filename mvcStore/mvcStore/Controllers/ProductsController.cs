using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStore.Models;
using mvcStore.ViewModels;

namespace mvcStore.Controllers
{ 
    public class ProductsController : Controller
    {
        private StoreEntities db = new StoreEntities();
        private BlobEntities blobs = new BlobEntities();
        //
        // GET: /Products/

        public ViewResult Index()
        {
            var viewModel = new ProductsListViewModel
            {
                Products = db.Products.ToList(),
                ProductTypes = db.ProductTypes.ToDictionary(k => k.ProductTypeId, v => v.Name)
            };
            return View(viewModel);
        }

        //
        // GET: /Products/Details/5

        public /*ViewResult*/JsonResult Details(int id)
        {
            Product product = db.Products.Find(id);
            //return View(product);
            return this.Json(product, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            var viewModel = new NewProductViewModel();
            viewModel.ProductTypes = db.ProductTypes.Select(x => new SelectListItem { Value = x.Name, Text = x.Name }).ToList();
            viewModel.SelectedTypeId = "Good";
            return View(viewModel);
        } 

        //
        // POST: /Products/Create

        [HttpPost]
        public ActionResult Create(NewProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength > 0) productViewModel.Product.ImageURI = blobs.Upload(hpf);
                    // TODO: stop the loop once one image has been added
                }
                productViewModel.Product.ProductTypeId = db.ProductTypes.Where(pt => pt.Name == productViewModel.SelectedTypeId).FirstOrDefault().ProductTypeId;
                db.Products.Add(productViewModel.Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productViewModel);
        }
        
        //
        // GET: /Products/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Products/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}