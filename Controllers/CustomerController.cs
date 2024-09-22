using Sales.Interface;
using Sales.Models;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using Sales.Resources;

namespace Sales.Controllers
{
    public class CustomerController : Controller
    {

        public IReposCustomer _ReposCustomer { get; }

        public CustomerController(IReposCustomer reposCustomer )
        {
            _ReposCustomer = reposCustomer;
        }
        // GET: Customer
        public ActionResult Index()
        {
           
            return View(_ReposCustomer.GetALL());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //  var customers = _context.Customers.Find(id);
            var customers = _ReposCustomer.Search(id);
            if (customers == null)
                return HttpNotFound();


            var cVM = new CustomerViewModel
            {
                CustomerID= customers.CustomerID,
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                Email = customers.Email,
                Address = customers.Address,
                Phone = customers.Phone,
                Gender = customers.Gender,

                GenderOptions = new List<SelectListItem>
             {
             // الخيار الأول فارغ
            new SelectListItem { Value = "0", Text = "أنثى" },
            new SelectListItem { Value = "1", Text = "ذكر" }
             }
            };


            return View("Create_Edit", cVM);
        }

        public ActionResult Create()
        {
            var model = new CustomerViewModel
            {
                GenderOptions = new List<SelectListItem>
             {
           
            new SelectListItem { Value = "0", Text = "أنثى" },
            new SelectListItem { Value = "1", Text = "ذكر" }
             }
            };

            return View("Create_Edit",model);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(CustomerViewModel viewModels)
        {
            if (!string.IsNullOrEmpty(viewModels.Phone) && !int.TryParse(viewModels.Phone, out _))
            {
                ModelState.AddModelError("Phone", "يرجى إدخال أرقام فقط.");
            }
            if (!ModelState.IsValid)
            {
                
                viewModels.GenderOptions = new List<SelectListItem>
             {
          
            new SelectListItem { Value = "0", Text = "أنثى" },
            new SelectListItem { Value = "1", Text = "ذكر" }
             };
                return View("Create_Edit", viewModels);
                //return View("Create_Edit");

            }

            if (viewModels.CustomerID == 0)
            {
                var customer = new Customer
                {
                    FirstName = viewModels.FirstName,
                    LastName = viewModels.LastName,
                    Email = viewModels.Email,
                    Address = viewModels.Address,
                    Phone = viewModels.Phone,
                    Gender = viewModels.Gender
                };
                _ReposCustomer.Add(customer);
               // _context.Customers.Add(customer);
            }
            else
            {
                var customer = _ReposCustomer.Search(viewModels.CustomerID);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                customer.FirstName = viewModels.FirstName;
                customer.LastName = viewModels.LastName;
                customer.Email = viewModels.Email;
                customer.Address = viewModels.Address;
                customer.Phone = viewModels.Phone;
                customer.Gender = viewModels.Gender;

            }

            _ReposCustomer.Save();
            //_context.SaveChanges();


            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index"); 
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //   var customer = _context.Customers.Find(id);
            var customer = _ReposCustomer.Search(id);

            if (customer == null)
                return HttpNotFound();

            _ReposCustomer.Delete(id);
            //_context.Customers.Remove(customer);
            //_context.SaveChanges();

            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index"); ;
        }


    }
}