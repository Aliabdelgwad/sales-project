using Sales.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class InvoiceDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceDetailId { get; set; }
        [Required(ErrorMessageResourceName = "InvoiceIdRequired", ErrorMessageResourceType = typeof(Resource))]

        public int InvoiceId { get; set; }

        [Required(ErrorMessageResourceName = "ProductIDisrequired", ErrorMessageResourceType = typeof(Resource))]
        public int ProductId { get; set; }

        [Required(ErrorMessageResourceName = "Quantityisrequired", ErrorMessageResourceType = typeof(Resource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Quantitymustbeatleast1", ErrorMessageResourceType = typeof(Resource))]

        public int Quantity { get; set; }
        [Required(ErrorMessageResourceName = "Unitpriceisrequired", ErrorMessageResourceType = typeof(Resource))]

        [Range(0.01, double.MaxValue, ErrorMessageResourceName = "Unitpricemustbegreaterthan0", ErrorMessageResourceType = typeof(Resource))]

        public decimal UnitPrice { get; set; }


        [Range(0, double.MaxValue, ErrorMessageResourceName = "Discountmustbeapositivevalue", ErrorMessageResourceType = typeof(Resource))]
        public decimal Discount { get; set; } // خصم على الصنف

        // العلاقة مع الفاتورة
        public virtual Invoice Invoice { get; set; }

        // العلاقة مع الصنف
        public virtual Product Product { get; set; }

        // السعر بعد الخصم
        public decimal TotalPrice => Quantity * UnitPrice * (1 - Discount / 100);


    }
}