using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scrum.BC.Api.Extensions;
using ScrumDDD.Domain.Entities;
using ScrumDDD.Infrastructure.Data;

namespace Scrum.BC.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDbContext<ScrumDbContext>(SeedDataBase).Run();
        }

        private static void SeedDataBase(ScrumDbContext db, IServiceProvider sp)
        {
            if (db.Users.Any()) return;

            db.Users.Add(new User()
            {
                Name = "Toni Requero",
                Email = "toni.requero@csccsl.com",
            });

            db.SaveChanges();

            db.Teams.Add(new Team()
            {
                Name = "Equipo A",
                Users = db.Users.ToList()
            });

            db.SaveChanges();

            var project = new Project()
            {
                Title = "Proyecto MOJO",
                Owner = db.Teams.First()
            };

            project.AddSprint(new Sprint(Duration.FromDays(10)) { StartDate = DateTime.Now});

            db.Projects.Add(project);

            db.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
