using System.Web.Mvc;

namespace BigLinguaProject.UI.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult SignIn() {
            return View();
        }
        public ActionResult Register() {
            return View();
        }
    }
}