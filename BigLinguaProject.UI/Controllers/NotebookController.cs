using System;
using System.Web;
using System.Web.Mvc;

namespace BigLinguaProject.UI.Controllers {
    public class NotebookController : Controller {
        [Authorize]
        public ActionResult Index() {
            return View();
        }
    }
}