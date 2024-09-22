using Sales.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Usernamerequired")]
        [StringLength(100, ErrorMessageResourceName = "Usernamecannotexceed100characters", ErrorMessageResourceType = typeof(Resource))]
        public string Username { get; set; }

        [Required(ErrorMessage = "Passwordrequired")]
        [StringLength(100, ErrorMessageResourceName = "Passwordcannotexceed256characters", ErrorMessageResourceType = typeof(Resource))]

        public string Password { get; set; }

        public DateTime? SessionExpiry { get; set; } 
    }
}