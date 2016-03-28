using System;
using System.Collections.Generic;

using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class TestNotebookDataSource : INotebookDataSource {
        public List<NotebookDescription> GetListOfNotebooksForUser(String userName) {
            if (userName == "Maksim") {
                var notebooks = new List<NotebookDescription>();
                notebooks.Add(new NotebookDescription {
                    BaseLanguage = new LanguageDescription { Name = "Русский", EnglishName = "Russian" },
                    TargetLanguage = new LanguageDescription { Name = "English", EnglishName = "English" }
                });
                notebooks.Add(new NotebookDescription {
                    BaseLanguage = new LanguageDescription { Name = "Русский", EnglishName = "Russian" },
                    TargetLanguage = new LanguageDescription { Name = "Deutsch", EnglishName = "German" }
                });
                return notebooks;
            }
            return new List<NotebookDescription>();
        }
        public IEnumerable<LanguageDescription> GetListOfLanguages() {
            return new List<LanguageDescription> {
                new LanguageDescription { Name = "English", EnglishName = "English" },
                new LanguageDescription { Name = "Deutsch", EnglishName = "German" },
                new LanguageDescription { Name = "Français", EnglishName = "French" },
                new LanguageDescription { Name = "Русский", EnglishName = "Russian" }
            };
        }
        public void Dispose() {
        }
    }
}