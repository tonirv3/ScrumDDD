using ScrumDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumDDD.Infrastructure.Data
{
    public static class GlobalData
    {
        private static readonly List<User> _users;
        private static readonly List<Team> _teams;
        private static readonly List<Project> _projects;
        public static List<User> Users { get =>_users; }
        public static List<Team> Teams { get=>_teams;}
        public static List<Project> Projects { get => _projects; }

        static GlobalData()
        {
            _users = new List<User>() {

                new User()
                {
                    Id = 1,
                    Name = "Toni Requero",
                    Email = "toni.requero@csccsl.com",
                }
            };

            _teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "Equipo A",
                    Users = new List<User>(_users)
                }
            };

            _projects = new List<Project>()
            {
               new Project()
               {
                   Id = 1,
                   Title = "Proyecto MOJO",
                   Owner = _teams.FirstOrDefault(),                   
               }

            };
        }
    }
}
