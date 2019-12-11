using ScrumDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Commands
{
    public class AddSprintToProjectCommand : IMessage<bool>
    {
        public int ProjectId { get; }
        public Sprint SprintToAdd { get; }


        public AddSprintToProjectCommand(int project, Sprint sprint)
        {
            ProjectId = project;
            SprintToAdd = sprint;
        }
    }
}
