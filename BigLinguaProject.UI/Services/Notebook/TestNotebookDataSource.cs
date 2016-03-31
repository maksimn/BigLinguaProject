using System;
using System.Collections.Generic;

using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class TestNotebookDataSource : INotebookDataSource {
        private List<NotebookDescription> notebooks = new List<NotebookDescription>();
        public List<NotebookDescription> GetListOfNotebooksForUser(String userName) {
            if (userName == "Maksim") {
                notebooks = new List<NotebookDescription>();
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
            return notebooks;
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

        public void AddNotebook(NotebookDescription notebookToAdd) {
            notebooks.Add(notebookToAdd);
        }
    }
}