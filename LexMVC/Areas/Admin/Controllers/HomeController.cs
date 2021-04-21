using LexMVC.Models;
using LexMVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexMVC.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            DashboadViewModel model = new DashboadViewModel();
            model.SubscribtionCount = db.Warranty.Count();
            model.TotalProduct = db.Product.Count();
            model.FeaturedProduct = db.Product.Where(s => s.IsFeature == true).Count();
            var siteset = db.SiteSetting.FirstOrDefault();
            if (siteset != null)
            {
                model.BlogInfomation = siteset.IsBlogEnabled == true ? "Blog is enable" : "Blog is hidden from the client site";
                model.FooterInformation = siteset.UseSmallFooter == true ? "Site is using small footer" : "Site is using big footer";

            }
            return View(model);
        }
    }
}