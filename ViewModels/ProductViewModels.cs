using Sales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Sales.Resources;
namespace Sales.ViewModels
{
    public class ProductViewModels
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

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
      
    }
}