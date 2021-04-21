using LexMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LexMVC.Controllers
{
    public class AjaxController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public AjaxController()
        {  
        }

        [Route("/ajax/navbar")]
        public JsonResult Navbar()
        {
            var info = context.SiteSetting.FirstOrDefault();
            var navpr = context.NavlinkSetup.FirstOrDefault();
            GlobSetVM glob = new GlobSetVM();
            if (info != null)
            {
                glob.SettingsId = info.SettingsId;
                glob.IsBlogEnabled = info.IsBlogEnabled;
                glob.UseSmallFooter = info.UseSmallFooter;
            }
            if (navpr != null)
            {
                glob.BasicProductId = navpr.BasicProductId;
                glob.AdvanceProductId = navpr.AdvanceProductId;
                glob.UltimateProductId = navpr.UltimateProductId;
            }

            return Json(glob, JsonRequestBehavior.AllowGet);
        }


    }
}