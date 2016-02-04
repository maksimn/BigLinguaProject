using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

using BigLinguaProject.UI.Models;
using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class AuthService {
        private BigLinguaDbContext dbContext = new BigLinguaDbContext();

        public Boolean IsRegisterActionViewModelValid(RegisterViewModel viewModel, 
                                                      ModelStateDictionary modelState) {
            if(!modelState.IsValid) {
                return false;
            }
            if (dbContext.Users.Any(u => u.Name == viewModel.Name)) {
                modelState.AddModelError("Name",
                    "A user with this name already exists. Please try again with another name.");
                return false;
            }
            return true;
        }

        public String GetRegisterActionViewModel(RegisterViewModel viewModel) {
            // добавить в базу и авторизовать в системе
            User user = new User {
                Name = viewModel.Name,
                PasswordHash = SHA1Util.SHA1HashStringForUTF8String(viewModel.Password)
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            // Теперь нужно авторизовать данного пользователя
            FormsAuthentication.SetAuthCookie(user.Name, false);
            return user.Name;
        }
    }
}