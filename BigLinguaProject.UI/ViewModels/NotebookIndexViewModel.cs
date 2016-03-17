using System;
using System.Collections.Generic;

namespace BigLinguaProject.UI.ViewModels {
    public class NotebookIndexViewModel {
        public NotebookIndexViewModel(String username, List<NotebookDescription> notebooks, 
            ILangListInitializer langInit = null) {
            UserName = username;
            Notebooks = notebooks;
            if (langInit == null) {
                LangList = new MockLangListInitializer().Initialize();
            } else {
                LangList = langInit.Initialize();
            }
        }
        public String UserName { get; private set; }
        public List<NotebookDescription> Notebooks { get; private set; }
        public IEnumerable<LanguageDescription> LangList { get; private set; }
    }

    public class NotebookDescription {
        public LanguageDescription BaseLanguage { get; set; }
        public LanguageDescription TargetLanguage { get; set; }
    }

    public class LanguageDescription {
        public String Name { get; set; }
        public String EnglishName { get; set; }
    }

    public interface ILangListInitializer {
        IEnumerable<LanguageDescription> Initialize();
    }

    public class MockLangListInitializer : ILangListInitializer {
        public IEnumerable<LanguageDescription> Initialize() {
            return new List<LanguageDescription> {
                new LanguageDescription { Name = "English", EnglishName = "English" },
                new LanguageDescription { Name = "Deutsch", EnglishName = "German" },
                new LanguageDescription { Name = "Français", EnglishName = "French" },
                new LanguageDescription { Name = "Русский", EnglishName = "Russian" }
            };
        }
    }
}