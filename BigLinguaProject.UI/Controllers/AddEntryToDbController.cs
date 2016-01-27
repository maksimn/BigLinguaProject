using System;
using System.Web.Mvc;
using BigLinguaProject.UI.Models;

namespace BigLinguaProject.UI.Controllers {
    public class AddEntryToDbController : Controller {
        public ActionResult Index() {
            AppUser user = new AppUser();
            user.UserName = "Abc";
            user.PasswordHash = SHA1Util.SHA1HashStringForUTF8String("1234");

            AppDbContext context = new AppDbContext();
            context.Users.Add(user);
            context.SaveChanges();

            return View();
        }
    }
}
