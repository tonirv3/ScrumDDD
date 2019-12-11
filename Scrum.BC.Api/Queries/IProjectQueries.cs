using Scrum.BC.Api.QueryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrum.BC.Api.Queries
{
    public interface IProjectQueries
    {
        Task<MainProjectListResult> GetMainProjectList();
    }
}
