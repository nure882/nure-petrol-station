using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AppContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Pump> Pumps { get; set; }
        public DbSet<GasType> GasTypes { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        public AppContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GasStation;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
            .HasOne(a => a.Station)
            .WithMany()
            .HasForeignKey(a => a.StationId)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Station>()
         .HasMany(c => c.Workers)
         .WithOne(c => c.Station)
         .HasForeignKey(c => c.StationId)
         .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Station>()
                .HasMany(c => c.Admins)
                .WithOne(c => c.Station)
                .HasForeignKey(c => c.StationId)
                .OnDelete(DeleteBehavior.SetNull);


            base.OnModelCreating(modelBuilder);
        }
    }
}
