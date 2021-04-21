using LexMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace LexMVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ProductController()
        {

        }
        public ActionResult Index()
        {
            var mdoels = db.Product.ToList();
            return View(mdoels);
        }
        public ActionResult Details(int id)
        {
            var models = db.Product.Where(b => b.ProductId == id).FirstOrDefault();
            return View(models);
        }
    }
}
