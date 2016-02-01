using System;
using System.ComponentModel.DataAnnotations;

namespace BigLinguaProject.UI.ViewModels {
    public class RegisterViewModel : SignInViewModel {
        [Required]
        [Compare("Password", ErrorMessage="Both password fields must have the same value.")]
        public String Password2 { get; set; }
    }
}