using System;
using System.Collections.Generic;

namespace BigLinguaProject.UI.ViewModels {
    public class NotebookIndexViewModel {
        public NotebookIndexViewModel() : 
            this(null, new List<NotebookDescription>(), new List<LanguageDescription>()) {
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
        public LanguageDescription() {}
        public LanguageDescription(String initStr) {
            FromString(initStr);
        }
        public override String ToString() {
            return String.Format("{0} / {1}", Name, EnglishName);
        }
        public void FromString(String str) {
            String[] a = str.Split(new String[] { " / " }, StringSplitOptions.None);
            Name = a[0];
            EnglishName = a[1];
        }
    }
}