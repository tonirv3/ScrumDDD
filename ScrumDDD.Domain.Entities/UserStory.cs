using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities
{
    public class UserStory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StoryPoints { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
