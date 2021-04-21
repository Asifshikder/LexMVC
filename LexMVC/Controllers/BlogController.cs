using LexMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace LexMVC.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public BlogController()
        {
        }
        [HttpGet]
        public ActionResult Index()
        {
            var bloglist = db.BlogPost.ToList();
            return View(bloglist);
        }
        [HttpGet]
        public ActionResult Post(int id)
        {
            var bloglist = db.BlogPost.Where(s=>s.BlogId ==id).FirstOrDefault();
            return View(bloglist);
        }
    }
}
