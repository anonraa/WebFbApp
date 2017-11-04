using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFbApp.Models
{

    public class FacebookPictureViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Created_Time")]
        public string CreatedTime { get; set; }

        [Required]
        [Display(Name = "PictureURL")]
        public string PictureURL { get; set; }


    }
}