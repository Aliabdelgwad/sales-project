using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.Resources;

namespace Sales.ViewModels
{
    public class InvoiceViewModel
    {
        [Required(ErrorMessageResourceName = "SelectedCustomerIDisrequired", ErrorMessageResourceType = typeof(Resource))]

        public int SelectedCustomerId { get; set; }

        [Range(0, double.MaxValue, ErrorMessageResourceName = "Invoicediscountmustbeapositivevalue", ErrorMessageResourceType = typeof(Resource))]

        public decimal InvoiceDiscount { get; set; } // خصم الفاتورة

        public IEnumerable<SelectListItem> Customers { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
        public List<InvoiceDetailViewModel> InvoiceDetails { get; set; } = new List<InvoiceDetailViewModel>();
    }

  
}

