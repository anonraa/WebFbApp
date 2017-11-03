using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebFbApp.Extentions;
using WebFbApp.Filters;
using WebFbApp.Models;

namespace WebFbApp.Controllers
{
    [Authorize]
    [FacebookAccessToken]
    public class FacebookController : Controller
    {

        // GET: Facebook
        public async Task<ActionResult> Index()
        {

            var access_token = HttpContext.Items["access_token"].ToString();
            var appsecret_proof = access_token.GenerateAppSecretProof();

            var facebookClient = new FacebookClient();

            var result = await facebookClient.GetAsync<dynamic>(
                access_token, "me", "fields=first_name,last_name,link,locale,email,birthday,gender,location,age_range");

            // Image overloads FacebookProfileViewModel. IDK why o.O

            //var profileImgResult = await facebookClient.GetAsync<dynamic>(access_token, $"{ result.id}", "/picture?width=200&height=200&redirec=false");



            if (result == null)
            {
                throw new HttpException(400, "Jebem li ga");
            }

            var facebookProfile = new FacebookProfileViewModel
            {
                Id = result.id,
                Email = result.email,
                Name = result.name,
                FirstName = result.first_name,
                LastName = result.last_name,
                Locale = result.locale,
                LinkURL = result.link,
                Gender = result.gender,
                //ImageURL = profileImgResult.data.url.ToString()
            };
            
            return View(facebookProfile);
        }

        public async Task<ActionResult> FB_PostPages()
        {
            var access_token = HttpContext.Items["access_token"].ToString();
            var appsecret_proof = access_token.GenerateAppSecretProof();

            var facebookClient = new FacebookClient();

            var posts = await facebookClient.GetAsync<dynamic>(
                access_token, "me", "fields=posts{description,caption,message,story,link,name,created_time,picture}");

            var postList = new List<FacebookPostViewModel>();
            
            foreach (dynamic post in posts.posts.data)
            {
                var facebookPost = new FacebookPostViewModel
                {
                    Id = post.id,
                    Name = post.name,
                    CreatedTime = post.created_time,
                    Message = post.message,
                    Description = post.description,
                    Story = post.story,
                    Caption = post.caption,
                    Link = post.link,
                    PictureURL = post.picture,
                };
                postList.Add(facebookPost);
            }

            return PartialView(postList);
        }
    }
}