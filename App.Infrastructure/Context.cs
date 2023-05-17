using App.ApplicationCore.Domain;
using App.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace App.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donator> Donators { get; set; }
        public DbSet<Kafala> Kafalas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KafalaConfiguration());
            modelBuilder.Entity<Donator>().OwnsOne(e => e.Contact);
            modelBuilder.Entity<Beneficiary>().OwnsOne(e => e.Contact);

            base.OnModelCreating(modelBuilder);
        }
    }
}
