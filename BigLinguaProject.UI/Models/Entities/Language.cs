using System;
using System.ComponentModel.DataAnnotations;

namespace BigLinguaProject.UI.Models.Entities {
    public class Language {
        [Key]
        public Byte Id { get; set; }
        public String Name { get; set; }
        public String EnglishName { get; set; }
    }
}