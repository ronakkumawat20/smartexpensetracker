using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SET.Entity;

namespace SET.Infrastructure
{
    public class SetDbContext : IdentityDbContext<IdentityUser>
    {
        public SetDbContext(DbContextOptions<SetDbContext> options) : base(options) { }   //This receives database configuration from Program.cs.

        public DbSet<Faq> Faq { get; set; }   //Create a table in the database for the Faq class, and allow CRUD operations on it.

        public DbSet<Expense> Expense { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        //Automatically loads all EF Core entity configuration classes from the same assembly(project) where DbContext exists.                                
    }
}
