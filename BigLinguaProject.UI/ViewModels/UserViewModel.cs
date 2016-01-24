using System;
using System.ComponentModel.DataAnnotations;

namespace BigLinguaProject.UI.ViewModels {
    public class UserViewModel {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage="Both password fields must have the same value.")]
        public String Password2 { get; set; }
    }
}