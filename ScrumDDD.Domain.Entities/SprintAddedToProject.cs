namespace ScrumDDD.Domain.Entities
{
    public class SprintAddedToProject : IDomainEvent
    {
        private  Project _project { get; }
        private  Sprint _sprint { get; }
        public SprintAddedToProject(Project project, Sprint sprint)
        {
            _project = project;
            _sprint = sprint;
        }
    }
}