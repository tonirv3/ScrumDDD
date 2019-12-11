using ScrumDDD.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;

namespace ScrumDDD.Domain.Entities
{
    public class Project
    {
        private readonly List<Sprint> _sprints;
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Sprint> Sprints =>_sprints; 
        public Team Owner { get; set; }

        public Project()
        {
            this._sprints = new List<Sprint>();
        }

        public void AddSprint(Sprint sprint)
        {
            if (SprintsCollide(sprint))
            {
                throw new DomainException("Error");
            }
            _sprints.Add(sprint);

            DomainEvents.AddDomainEvent(new SprintAddedToProject(this, sprint));

        }

        private bool SprintsCollide(Sprint newSprint)
        {
            foreach(var sprint in this.Sprints)
            {

                if (sprint.Overlaps(newSprint))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
