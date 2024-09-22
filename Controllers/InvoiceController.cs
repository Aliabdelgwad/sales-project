using Sales.Interface;
using Sales.Models;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IReposInvoice _InvoiceRepos;

        public InvoiceController( IReposInvoice InvoiceRepos)
        {
          
            _InvoiceRepos = InvoiceRepos;
            _context = new AppDbContext();
        }
        // GET: Invoice
        public ActionResult Index()
        {
  
            return View(_InvoiceRepos.GetALL());
        }
        public ActionResult Create()
        {
            var model = new InvoiceViewModel
            {
                Customers = _context.Customers.ToList().Select(c => new SelectListItem
                {
                    Value = c.CustomerID.ToString(),
                    Text = $"{c.FirstName} {c.LastName}"
                }),
                Products = _context.Products.ToList().Select(p => new SelectListItem
                {
                    Value = p.ProductId.ToString(),
                    Text = p.FullName
                })
            };

            return View(model);
        }

        // POST: Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceViewModel model)
        {
            if (model.InvoiceDetails.Count == 0)
            {
                ModelState.AddModelError("", "يجب إضافة صنف واحد على الأقل.");
               /* return View(model)*/; // أعد تحميل الصفحة مع الرسالة
            }


            if (ModelState.IsValid)
            {

                var invoice = new Invoice
                {
                    InvoiceDate = DateTime.Now,
                    CustomerId = model.SelectedCustomerId,
                    InvoiceDiscount = model.InvoiceDiscount,
                    InvoiceDetails = model.InvoiceDetails.Select(d => new InvoiceDetail
                    {
                        ProductId = d.ProductId,
                        Quantity = d.Quantity,
                        UnitPrice = d.UnitPrice,
                        Discount = d.Discount
                    }).ToList()
                };
                _InvoiceRepos.Add(invoice);
                _InvoiceRepos.Save();
                //_context.Invoices.Add(invoice);
                //_context.SaveChanges();

                return RedirectToAction("Index");
            }

            // إعادة تحميل بيانات العملاء والمنتجات إذا لم يكن النموذج صالحًا
            model.Customers = _context.Customers.ToList().Select(c => new SelectListItem
            {
                Value = c.CustomerID.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            });

            model.Products = _context.Products.ToList().Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.FullName
            });

            return View(model);
        }


        // GET: Invoices/GetProductPrice
        public JsonResult GetProductPrice(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                return Json(new { price = product.Price }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { price = 0 }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(int? id)
        {


            var invoice1 = _InvoiceRepos.Search(id);
            var custmer1 = _context.Customers.Find(invoice1.CustomerId);
            List<InvoiceDetail> iv_details1 = (_context.InvoiceDetails.ToList().
                Where(m => m.InvoiceId == invoice1.InvoiceId)).ToList();


            var VMode = new ViewModelDetails
            {
                invoice = invoice1,

                CustomerId = custmer1.CustomerID,

                customer = custmer1,

                CustomerName = custmer1.FirstName +" "+custmer1.LastName,

                InvoiceDetail0 = iv_details1,

                InvoiceDiscount0 = invoice1.InvoiceDiscount
            };

            return View(VMode);

        }


    }



}



