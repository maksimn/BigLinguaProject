using System;
using System.Collections.Generic;

using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public interface INotebookDataSource : IDisposable {
        List<NotebookDescription> GetListOfNotebooksForUser(String userName);
        IEnumerable<LanguageDescription> GetListOfLanguages();
        void AddNotebook(String userName, NotebookDescription notebookToAdd);
    }
}