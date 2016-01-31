using System;
using System.ComponentModel.DataAnnotations;

namespace BigLinguaProject.UI.ViewModels {
    public class SignInViewModel {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Password { get; set; }
    }
}