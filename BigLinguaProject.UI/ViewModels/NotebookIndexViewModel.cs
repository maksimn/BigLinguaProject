using System;
using System.Collections.Generic;

namespace BigLinguaProject.UI.ViewModels {
    public class NotebookIndexViewModel {
        public NotebookIndexViewModel() {
        }
        public NotebookIndexViewModel(String username, 
                                      List<NotebookDescription> notebooks, 
                                      IEnumerable<LanguageDescription> langs) {
            UserName = username;
            Notebooks = notebooks;
            LangList = langs;
        }
        public String UserName { get; set; }
        public List<NotebookDescription> Notebooks { get; set; }
        public IEnumerable<LanguageDescription> LangList { get; set; }
    }

    public class NotebookDescription {
        public LanguageDescription BaseLanguage { get; set; }
        public LanguageDescription TargetLanguage { get; set; }
    }

    public class LanguageDescription {
        public String Name { get; set; }
        public String EnglishName { get; set; }
        public override String ToString() {
            return String.Format("{0} / {1}", Name, EnglishName);
        }
    }
}