using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFbApp.Models
{
    public class FacebookWebhookViewModel
    {
        [Required]
        [Display(Name = "Challenge ")]
        public string Challenge { get; set; }
    }
}