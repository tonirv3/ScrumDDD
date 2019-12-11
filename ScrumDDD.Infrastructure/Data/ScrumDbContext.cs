using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScrumDDD.Domain;
using ScrumDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Infrastructure.Data
{
    public class ScrumDbContext : DbContext , IUnitOfWork
    {
        public ScrumDbContext(DbContextOptions<ScrumDbContext> options) : base(options)
        {
                
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        public void Commit()
        {
            this.SaveChanges();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprint>()
                .Property(p => p.Duration)
                .HasConversion(new ValueConverter<Duration, int>(
                        d => d.Days,
                        i => Duration.FromDays(i)
                        
                    ));
            base.OnModelCreating(modelBuilder);
        }
    }
}
