﻿using System;
using System.Collections.Generic;

using BigLinguaProject.UI.ViewModels;

namespace BigLinguaProject.UI.Services {
    public class NotebookService : IDisposable {
        private INotebookDataSource dataSource = new TestNotebookDataSource();

        public void Dispose() {
            dataSource.Dispose();
        }

        public void SetStateSource(Object source) {
            dataSource.SetStateSource(source);
        }

        public NotebookIndexViewModel GetNotebookIndexViewModel(String userName) {
            // Здесь для модели представления список тетрадей и языков должен браться из источника данных,
            // т.е. базы данных (список тетрадей, принадлежащих данному пользователю и общий список языков) 
            // или поддельного источника данных.
            // Результат должен быть закэширован.
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