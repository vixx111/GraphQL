using GraphQL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GraphQL.Entity    
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fee> Fees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Author
            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Author>()
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Author>()
                .Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Author>()
                .HasIndex(a => a.Email)
                .IsUnique();

            //  Article
            modelBuilder.Entity<Article>()
                .Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Article>()
                .HasIndex(a => a.JournalNumber);

            //  Fee
            modelBuilder.Entity<Fee>()
                .Property(f => f.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Fee>()
                .Property(f => f.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Fee)
                .WithMany(f => f.Articles)
                .HasForeignKey(a => a.FeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fee>()
                .HasOne(f => f.Author)
                .WithMany(a => a.Fees)
                .HasForeignKey(f => f.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}