using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sales.Models;
using Sales.Resources;

namespace Sales.Models
{
    public class Category
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessageResourceName = "Categorynameisrequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceName = "Categorynamecannotexceed20characters", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; set; }

        [StringLength(100, ErrorMessageResourceName = "Descriptioncannotexceed200characters", ErrorMessageResourceType = typeof(Resource))]

        public string Description { get; set; }

        // قائمة الأصناف التي تنتمي لهذه الفئة
        public virtual ICollection<Product> Products { get; set; }
    }

}




