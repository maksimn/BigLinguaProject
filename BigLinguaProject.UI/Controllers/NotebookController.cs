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
            String userName = Session["username"] as String;
            NotebookIndexViewModel viewModel = service.GetNotebookIndexViewModel(userName);           
            return View(viewModel);
        }

        [AuthorizedUsersOnly]
        [HttpPost]
        public ActionResult Add(String targetLanguage, String baseLanguage) {
            LanguageDescription targetLang = new LanguageDescription(targetLanguage), 
                                baseLang = new LanguageDescription(baseLanguage);
            var notebookToAdd = new NotebookDescription { BaseLanguage = baseLang, TargetLanguage = targetLang };
            
            service.AddNotebook(notebookToAdd);

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