using Microsoft.EntityFrameworkCore;
using Scrum.BC.Api.QueryResults;
using ScrumDDD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrum.BC.Api.Queries
{
    public class ProjectQueries : IProjectQueries
    {
        private readonly ScrumDbContext _db;
        public ProjectQueries(ScrumDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<MainProjectListResult> GetMainProjectList() 
        { 
         
            var data = await _db.Projects.Select(p => new MainProjectListResult.MainProjectListResultItem 
            { 
                Id = p.Id,
                Name = p.Title,
                SprintCount = p.Sprints.Count()
            }).ToListAsync();

            return new MainProjectListResult(data);
        }
    }
}
