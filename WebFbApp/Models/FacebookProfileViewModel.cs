using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFbApp.Models
{
    public class FacebookProfileViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "ImageURL")]
        public string ImageURL { get; set; }

        [Display(Name = "Link")]
        public string LinkURL { get; set; }

        [Display(Name = "Locale")]
        public string Locale { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}