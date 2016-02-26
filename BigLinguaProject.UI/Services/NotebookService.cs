using System;
using System.Data.Entity;

using BigLinguaProject.UI.Models;
using BigLinguaProject.UI.Models.Entities;

namespace BigLinguaProject.UI.Services {
    public class NotebookService : IDisposable {
        private BigLinguaDbContext dbContext = new BigLinguaDbContext();

        public void CreateAndAddLanguagesToDb() {
            dbContext.Languages.Add(new Language { Id = 1, Name = "English", EnglishName = "English" });
            dbContext.Languages.Add(new Language { Id = 2, Name = "Русский", EnglishName = "Russian" });
            dbContext.Languages.Add(new Language { Id = 3, Name = "Deutsch", EnglishName = "German" });

            dbContext.SaveChanges();
        }

        public void Dispose() {
            dbContext.Dispose();
        }
    }
}