using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

using BigLinguaProject.UI.Attributes;
using BigLinguaProject.UI.Services;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class NotebookController : Controller {
        private NotebookService service = new NotebookService();

        [AuthorizedUsersOnly]
        public ActionResult Index() {
            var viewModel = new NotebookIndexViewModel(
                username: Session["username"] as String,
                notebooks: new List<NotebookDescription>());   
           
            return View(viewModel);
        }

        [AuthorizedUsersOnly]
        [HttpPost]
        public ActionResult Add(NotebookIndexViewModel viewModel, String language1, String language2) {
            return RedirectToAction("index");
        }

        protected override void Dispose(Boolean disposing) {
            if (disposing) {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}