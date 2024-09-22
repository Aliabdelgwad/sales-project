using Sales.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "FirstNameLength", ErrorMessageResourceType = typeof(Resource))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "LastNameLength", ErrorMessageResourceType = typeof(Resource))]
        public string LastName { get; set; }


        [Required(ErrorMessageResourceName = "GenderRequired", ErrorMessageResourceType = typeof(Resource))]
        [Range(0, 1, ErrorMessageResourceName = "GenderRange", ErrorMessageResourceType = typeof(Resource))]
        public int Gender { get; set; }

        public string Address { get; set; }
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Resource))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(Resource))]
        [Phone(ErrorMessageResourceName = "InvalidPhone", ErrorMessageResourceType = typeof(Resource))]
        public string Phone { get; set; }

        //// قائمة الفواتير التي تخص هذا العميل
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}