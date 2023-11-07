using Microsoft.EntityFrameworkCore;
using Movies.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api 
            modelBuilder.Entity<Movie>()
                .Property(p => p.Title)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(p => p.Director)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(p => p.Year)
                .IsRequired();

            // data seed 

            modelBuilder.Entity<Movie>().HasData(MovieSeeder.GenerateProductData());
        }
    }
}
