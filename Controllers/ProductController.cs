using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Sales.ViewModels;
using System.Net;
using Sales.Interface;

namespace Sales.Controllers
{
    public class ProductController : Controller
    {
     
        private readonly IReposProduct _ProductRepos;

        private readonly AppDbContext _context;

        public ProductController(IReposProduct ProductRepos)
        {
            _ProductRepos = ProductRepos;
            _context = new AppDbContext();
        }

        public ActionResult Index()
        {
            return View(_ProductRepos.GetALL());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            var products = _ProductRepos.Details(id);
            if (products == null)
                return HttpNotFound();


            return View(products);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

           
            var products = _ProductRepos.Search(id);
            
            if (products == null)
                return HttpNotFound();

            var vModel = new ProductViewModels
            {
                ProductId = products.ProductId,
                FullName = products.FullName,
                Price = products.Price,
                CategoryId = products.CategoryId,
                Categories = _context.Categories.ToList()
            };


            return View("Add_Edit", vModel);
        }

        public ActionResult Create()
        {
            var ViewModelProduct = new ProductViewModels
            {
                Categories = _context.Categories.ToList()
            };

            return View("Add_Edit", ViewModelProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(ProductViewModels viewModels)
        {
            if (!ModelState.IsValid)
            {
                viewModels.Categories = _context.Categories.ToList();
                return View("Add_Edit");

            }

            if (viewModels.ProductId == 0)
            {
                var product = new Product
                {
                    FullName = viewModels.FullName,
                    Price = viewModels.Price,
                    CategoryId = viewModels.CategoryId
                };
              
                _ProductRepos.Add(product);
            }
            else
            {
                var product = _ProductRepos.Search(viewModels.ProductId);
                if (product == null)
                {
                    return HttpNotFound();
                }
                product.FullName = viewModels.FullName;
                product.Price = viewModels.Price;
                product.CategoryId = viewModels.CategoryId;

            }

            _ProductRepos.Save();
      

            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index"); ;
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

          
            var customer = _ProductRepos.Search(id);

            if (customer == null)
                return HttpNotFound();

            _ProductRepos.Delete(id);
         

            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index"); ;
        }


    }
}