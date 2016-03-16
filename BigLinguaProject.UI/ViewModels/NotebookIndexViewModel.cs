using System;
using System.Collections.Generic;

namespace BigLinguaProject.UI.ViewModels {
    public class NotebookIndexViewModel {
        public NotebookIndexViewModel(String username, List<NotebookDescription> notebooks) {
            UserName = username;
            Notebooks = notebooks;
        }
        public String UserName { get; private set; }
        public List<NotebookDescription> Notebooks { get; private set; }
    }

    public class NotebookDescription {
        public LanguageDescription BaseLanguage { get; set; }
        public LanguageDescription TargetLanguage { get; set; }
    }

    public class LanguageDescription {
        public String Name { get; set; }
        public String EnglishName { get; set; }
    }
}