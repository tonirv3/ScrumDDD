using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrum.BC.Api.Dtos
{
    public class SprintDto
    {

        public DateTime Start { get; set; }
        /// <summary>
        /// MUST BE GREATHER THAN 0 AND LOWER THAN 30
        /// </summary>
        public int Days { get; set; }
    }
}
