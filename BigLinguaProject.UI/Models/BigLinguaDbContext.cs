using System.Data.Entity;

using BigLinguaProject.UI.Models.Entities; 

namespace BigLinguaProject.UI.Models {
    public class BigLinguaDbContext1 : DbContext {
        public BigLinguaDbContext1() : base("DefaultConnection") {
        }
        public DbSet<User> Users { get; set; }
    }
}