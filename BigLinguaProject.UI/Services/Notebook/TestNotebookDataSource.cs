using System;
using System.Collections.Generic;
using System.Web.Caching;

using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class TestNotebookDataSource : INotebookDataSource {
        private Dictionary<String, List<NotebookDescription>> userNotebooks;

        public List<NotebookDescription> GetListOfNotebooksForUser(String userName) {
            // Считать userNotebook из текстового файла App_Data/TextFile.txt
            // (Десериализовать из входного файлового потока)

            // Вернуть данные для заданного пользователя
            return userNotebooks[userName];
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
            // 1. Считать userNotebook из текстового файла App_Data/TextFile.txt
            // (Десериализовать из входного файлового потока)
            
            // ... выполнение шага

            userNotebooks[userName].Add(notebookToAdd);
            // 3. Сериализовать в файловый поток коллекцию userNotebooks
        }
    }
}