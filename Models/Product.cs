using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sales.Resources;

namespace Sales.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required(ErrorMessageResourceName = "Productnameisrequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceName = "Productnamecannotexceed100characters", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Name")] 

        public string FullName { get; set; }


        [Required(ErrorMessageResourceName = "PriceRequired", ErrorMessageResourceType = typeof(Resource))]
        [Range(0.01, double.MaxValue, ErrorMessageResourceName = "PriceProductMustGreaterthan0", ErrorMessageResourceType = typeof(Resource))]

        public decimal Price { get; set; }

        public DateTime AddedOn { get; set; }

        public Product()
        {
            AddedOn = DateTime.Now;
        }

        public int CategoryId { get; set; }

        //// العلاقة مع الفئة
        public Category Category { get; set; }

    }
}