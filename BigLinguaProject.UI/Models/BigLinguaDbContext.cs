using System.Data.Entity;

using BigLinguaProject.UI.Models.Entities; 

namespace BigLinguaProject.UI.Models {
    public class BigLinguaDbContext : DbContext {
        public BigLinguaDbContext() : base("DefaultConnection") {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}