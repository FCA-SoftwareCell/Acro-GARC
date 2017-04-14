using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AcroGARC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<ClassStructure> ClassStucture { get; set; }

        public DbSet<BatchRecord> BatchRecords { get; set; }

        public ApplicationDbContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}