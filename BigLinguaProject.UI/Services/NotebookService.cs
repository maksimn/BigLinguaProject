using System;
using System.Data.Entity;

using BigLinguaProject.UI.Models;
using BigLinguaProject.UI.Models.Entities;

namespace BigLinguaProject.UI.Services {
    public class NotebookService : IDisposable {
        private BigLinguaDbContext1 dbContext = new BigLinguaDbContext1();
        
        public void Dispose() {
            dbContext.Dispose();
        }
    }
}