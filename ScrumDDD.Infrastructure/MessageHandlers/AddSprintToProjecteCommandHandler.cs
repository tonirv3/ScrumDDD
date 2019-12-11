using ScrumDDD.Domain;
using ScrumDDD.Domain.Commands;
using ScrumDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Infrastructure.MessageHandlers
{
    public class AddSprintToProjecteCommandHandler :
        IMessageHandler<AddSprintToProjectCommand, bool>
    {

        private readonly IProjectRepository _projectRepository;
        public AddSprintToProjecteCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public bool Handle(AddSprintToProjectCommand message)
        {
            var project = _projectRepository.GetById(message.ProjectId);

            if (project == null)
                return false;

            project.AddSprint(message.SprintToAdd);
            return true;
        }
    }
}
