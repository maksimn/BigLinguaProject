using System.Web.Mvc;

using BigLinguaProject.UI.Attributes;

namespace BigLinguaProject.UI.Controllers {
    public class HomeController : Controller {
        [UnauthorizedUsersOnly]
        public ActionResult Index() {
            return View();
        }
    }
}