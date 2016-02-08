using System;
using System.Web;
using System.Web.Mvc;

using BigLinguaProject.UI.Attributes;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class NotebookController : Controller {
        [AuthorizedUsersOnly]
        public ActionResult Index() {
            var viewModel = new NotebookIndexViewModel { 
                UserName = Session["username"] as String
            };
            return View(viewModel);
        }
    }
}