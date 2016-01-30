using System.Data.Entity;

namespace BigLinguaProject.UI.Models {
    public class BigLinguaDbContext : DbContext {
        public BigLinguaDbContext() : base("DefaultConnection") {
        }
        public DbSet<User> Users { get; set; }
    }
}