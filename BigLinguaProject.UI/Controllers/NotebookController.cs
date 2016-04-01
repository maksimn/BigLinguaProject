using System;
using System.Web;
using System.Web.Mvc;

using BigLinguaProject.UI.Attributes;
using BigLinguaProject.UI.Services;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Controllers {
    public class NotebookController : Controller {
        private NotebookService service;

        public NotebookController() {
            service = new NotebookService();
            service.SetStateSource(HttpContext.Cache);
        }

        [AuthorizedUsersOnly]
        public ActionResult Index() {
            String userName = GetUserName();
            NotebookIndexViewModel viewModel = service.GetNotebookIndexViewModel(userName);           
            return View(viewModel);
        }

        [AuthorizedUsersOnly]
        [HttpPost]
        public ActionResult Add(String targetLanguage, String baseLanguage) {
            String userName = GetUserName();
            service.AddNotebook(userName, new NotebookDescription(targetLanguage, baseLanguage));
            return RedirectToAction("index");
        }

        private String GetUserName() {
            return Session["username"] as String;
        }

        protected override void Dispose(Boolean disposing) {
            if (disposing) {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}