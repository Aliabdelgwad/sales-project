using Sales.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

       
        public DateTime InvoiceDate { get; set; }
        [Required(ErrorMessageResourceName = "CustomerIDisrequired", ErrorMessageResourceType = typeof(Resource))]

        public int CustomerId { get; set; }

        [Range(0, double.MaxValue, ErrorMessageResourceName = "Invoicediscountmustbeapositivevalue", ErrorMessageResourceType = typeof(Resource))]
        public decimal InvoiceDiscount { get; set; } // خصم على الفاتورة

        // العلاقة مع العميل
        public virtual Customer Customer { get; set; }

        // قائمة تفاصيل الفاتورة المرتبطة بهذه الفاتورة
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public decimal TotalAmount => InvoiceDetails?.Sum(d => d.TotalPrice) * (1 - InvoiceDiscount / 100) ?? 0; // المجموع بعد الخصم
    }
}

