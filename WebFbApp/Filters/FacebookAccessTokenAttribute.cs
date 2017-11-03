using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFbApp.Filters
{
    public class FacebookAccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ApplicationUserManager _userManager = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (_userManager != null)
            {
                var claimsforUser = _userManager.GetClaimsAsync(filterContext.HttpContext.User.Identity.GetUserId());
                var access_token = claimsforUser.Result.FirstOrDefault(x => x.Type.Equals("FacebookAccessToken")).Value;
                filterContext.HttpContext.Items.Add("access_token", access_token);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}