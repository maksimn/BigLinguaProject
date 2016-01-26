using BigLinguaProject.UI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BigLinguaProject.UI.Models {
    public class AppDbContext : IdentityDbContext<AppUser> {
        public AppDbContext() : base("DefaultConnection") {
        }
    }
}