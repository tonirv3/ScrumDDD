using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScrumDDD.Domain;
using ScrumDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var entries = this.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);
            var entries = this.ChangeTracker.Entries<Project>().Where(e => e.State != EntityState.Unchanged);

            foreach(var item in entries)
            {
                foreach(var evt in item.Entity.DomainEvents.Events)
                {
                    //TODO:Publish Event
                }

                item.Entity.DomainEvents.Clear();
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Ignore(p => p.DomainEvents);

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
