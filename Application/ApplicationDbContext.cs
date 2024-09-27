using Domains.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define a DbSet for each entity you want to include in your database
        public DbSet<User> Users { get; set; }

        // If you need to configure models (like relationships, constraints, etc.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity (optional)
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);  // Primary Key

                entity.Property(u => u.Username)
                      .IsRequired()        // Make Username required
                      .HasMaxLength(100);   // Max length for Username

                entity.Property(u => u.Password)
                      .IsRequired()
                      .HasMaxLength(256);   // Max length for Password (after hashing)

                entity.Property(u => u.Firstname)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Lastname)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.CreatedAt).IsRequired(false);
                // SQL default value for CreatedAt
            });

            // Add any other configurations here for other entities
        }
    }
}
