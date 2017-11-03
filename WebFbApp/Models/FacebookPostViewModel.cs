using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFbApp.Models
{
    public class FacebookPostViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Created_Time")]
        public string CreatedTime { get; set; }

        [Display(Name = "Story")]
        public string Story { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Picture")]
        public string PictureURL { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Caption")]
        public string Caption { get; set; }
    }
}