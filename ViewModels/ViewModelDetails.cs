using Sales.Models;
using Sales.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sales.Resources;
namespace Sales.ViewModels
{
    public class ViewModelDetails
    {

        public Invoice invoice { get; set; }
        [Required(ErrorMessageResourceName = "CustomerIDisrequired", ErrorMessageResourceType = typeof(Resource))]

        public int CustomerId { get; set; }

        public Customer customer { get; set; }
        [Required(ErrorMessageResourceName = "Customernameisrequired", ErrorMessageResourceType = typeof(Resource))]

        [StringLength(100, ErrorMessageResourceName = "Customernamecannotexceed100characters", ErrorMessageResourceType = typeof(Resource))]
        public string CustomerName { get; set; }

        [Range(0, double.MaxValue, ErrorMessageResourceName = "Invoicediscountmustbeapositivevalue", ErrorMessageResourceType = typeof(Resource))]

        public decimal InvoiceDiscount0 { get; set; }
        public List<InvoiceDetail> InvoiceDetail0 { get; set; }=new List<InvoiceDetail>();


    }
}