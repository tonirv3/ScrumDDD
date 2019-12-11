using Microsoft.EntityFrameworkCore;
using ScrumDDD.Domain.Entities;
using ScrumDDD.Domain.Repositories;
using ScrumDDD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrumDDD.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ScrumDbContext _context;
        public ProjectRepository(ScrumDbContext context)
        {
            _context = context;
        }


        public Project GetById(int id)
        {
            return _context.Projects.Include(p=>p.Sprints).SingleOrDefault(p => p.Id == id);
        }


    }
}
