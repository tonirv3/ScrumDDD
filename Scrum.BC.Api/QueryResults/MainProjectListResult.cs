using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrum.BC.Api.QueryResults
{
    public class MainProjectListResult
    {
        public IEnumerable<MainProjectListResultItem> Results { get; set; }

        public MainProjectListResult(IEnumerable<MainProjectListResultItem> data)
        {
            Results = data.ToList();
        }
        public class MainProjectListResultItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int SprintCount { get; set; }
        }
    }
}
