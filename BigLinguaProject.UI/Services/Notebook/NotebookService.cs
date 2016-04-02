using System;
using System.Collections.Generic;

using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class NotebookService : IDisposable {
        private INotebookDataSource dataSource = new TestNotebookDataSource();

        public void Dispose() {
            dataSource.Dispose();
        }
        
        public NotebookIndexViewModel GetNotebookIndexViewModel(String userName) {
            var viewModel = new NotebookIndexViewModel(
                username: userName,
                notebooks: dataSource.GetListOfNotebooksForUser(userName),
                langs: dataSource.GetListOfLanguages()
            );
            return viewModel;
        }

        public IEnumerable<LanguageDescription> GetListOfLanguages() {
            return dataSource.GetListOfLanguages();
        }

        public void AddNotebook(String userName, NotebookDescription notebookToAdd) {
            dataSource.AddNotebook(userName, notebookToAdd);
        }
    }
}