using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities
{
    public class Epic
    {
        public int Id { get; set; }
        public ICollection<UserStory> Pbis { get; set; }
        public string Title { get; set; }
        public EpicState State { get; set; }
    }
}
