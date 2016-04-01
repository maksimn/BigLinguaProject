using System;
using System.Collections.Generic;
using System.Web.Caching;

using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class TestNotebookDataSource : INotebookDataSource {
        private Cache cache;
        public List<NotebookDescription> GetListOfNotebooksForUser(String userName) {
            return (List<NotebookDescription>)cache[userName];
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

        public void AddNotebook(String userName, NotebookDescription notebookToAdd) {
            List<NotebookDescription> notebooks = cache[userName] as List<NotebookDescription>;
            notebooks.Add(notebookToAdd);
        }

        public void SetStateSource(Object source) {
            cache = (Cache)source;
        }
    }
}