using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BTSession03.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Clother> Clothers { get; set; }
        public DbSet<Electronic> Electronics { get; set; }
        public DbSet<CategoryClother> CategoryClothers { get; set; }
        public DbSet<CategoryElectronic> CategoryElectronics { get; set; }
    }
}