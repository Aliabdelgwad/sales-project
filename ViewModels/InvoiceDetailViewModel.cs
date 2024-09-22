using Sales.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.Resources;

namespace Sales.ViewModels
{
    public class InvoiceDetailViewModel
    {
        [Required(ErrorMessageResourceName = "ProductIDisrequired", ErrorMessageResourceType = typeof(Resource))]
        public int ProductId { get; set; }

        

        public IEnumerable<SelectListItem> Products { get; set; }

        [Required(ErrorMessageResourceName = "Quantityisrequired", ErrorMessageResourceType = typeof(Resource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Quantitymustbeatleast1", ErrorMessageResourceType = typeof(Resource))]


        public int Quantity { get; set; }

        [Required(ErrorMessageResourceName = "Unitpriceisrequired", ErrorMessageResourceType = typeof(Resource))]

        [Range(0.01, double.MaxValue, ErrorMessageResourceName = "Unitpricemustbegreaterthan0", ErrorMessageResourceType = typeof(Resource))]

       

        public decimal UnitPrice { get; set; }


        [Range(0, double.MaxValue, ErrorMessageResourceName = "Discountmustbeapositivevalue", ErrorMessageResourceType = typeof(Resource))]

       

        public decimal Discount { get; set; } // خصم الصنف
    }
}

