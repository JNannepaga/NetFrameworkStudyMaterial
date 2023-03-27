using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AspNetIdentityOwinIntegration
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext()
            : base("name = AppDBCS", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
