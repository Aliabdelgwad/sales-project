using Sales.Interface;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class CategoryController : Controller
    {
        public IReposCategory _ReposCategory { get; }

        public CategoryController(IReposCategory ReposCategory)
        {
            this._ReposCategory = ReposCategory;
            
        }
        public ActionResult Index()
        {
           
            return View(_ReposCategory.GetALL());
        }

        public ActionResult Create()
        {
            var category = new Category();

            return View("Create_Edit", category);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // var category = _context.Categories.Find(id);
            var category = _ReposCategory.Search(id);

            if (category == null)
                return HttpNotFound();


            var vModel = new Category
            {
                Name = category.Name,
                Description = category.Description

            };


            return View("Create_Edit", category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category models)
        {

            if (!ModelState.IsValid)
                return View("Create_Edit");


            if (models.CategoryId == 0)
            {
                _ReposCategory.Add(models);
                //_context.Categories.Add(models);
            }
            else
            {
                // var category = _context.Categories.Find(models.CategoryId);

                var category = _ReposCategory.Search(models.CategoryId);
                if (category == null)
                {
                    return HttpNotFound();
                }
                category.Name = models.Name;
                category.Description = models.Description;
            }

            _ReposCategory.Save();
            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index"); ;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //   var customer = _context.Customers.Find(id);
            var customer = _ReposCategory.Search(id);

            if (customer == null)
                return HttpNotFound();

            _ReposCategory.Delete(id);
            //_context.Customers.Remove(customer);
            //_context.SaveChanges();

            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index"); ;
        }
    }
}