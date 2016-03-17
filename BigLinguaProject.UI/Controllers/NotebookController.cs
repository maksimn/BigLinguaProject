using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using BigLinguaProject.UI.Attributes;
using BigLinguaProject.UI.Services;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class NotebookController : Controller {
        private NotebookService service = new NotebookService();

        [AuthorizedUsersOnly]
        public ActionResult Index() {
            var viewModel = new NotebookIndexViewModel (
                username: Session["username"] as String, 
                notebooks: new List<NotebookDescription>()
            );

            return View(viewModel);
        }

        protected override void Dispose(Boolean disposing) {
            if (disposing) {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}