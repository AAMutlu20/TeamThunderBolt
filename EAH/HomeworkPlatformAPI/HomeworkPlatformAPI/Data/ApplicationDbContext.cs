using HomeworkPlatformAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeworkPlatformAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Assignment>()
                .HasKey(a => a.Id);

            builder.Entity<Category>()
                .HasKey(c => c.Id);

            builder.Entity<Homework>()
                .HasKey(h => h.Id);

            builder.Entity<Homework>()
                .HasOne(h => h.Assignment)
                .WithMany(a => a.Homeworks)
                .HasForeignKey(h => h.AssignmentId);

            builder.Entity<Assignment>()
                .HasMany(a => a.Categories)
                .WithMany(c => c.Assignments)
                .UsingEntity<AssignmentCategory>(
                    ac => ac.HasOne(ac => ac.Category).WithMany().HasForeignKey(ac => ac.CategoryId),
                    ac => ac.HasOne(ac => ac.Assignment).WithMany().HasForeignKey(ac => ac.AssignmentId),
                    ac =>
                    {
                        ac.HasKey(ac => new { ac.AssignmentId, ac.CategoryId });
                    });
        }
    }
}
