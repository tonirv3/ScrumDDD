using Microsoft.AspNetCore.Mvc;
using Scrum.BC.Api.Dtos;
using ScrumDDD.Domain;
using ScrumDDD.Domain.Commands;
using ScrumDDD.Domain.Entities;
using ScrumDDD.Domain.Repositories;
using ScrumDDD.Infrastructure.Data;
using ScrumDDD.Infrastructure.Repositories;
using System.Linq;

namespace Scrum.BC.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBus _messageBus;

        public ProjectsController(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IMessageBus messageBus)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _messageBus = messageBus;
        }



        //Se indica que projectId es de tipo integer

        [HttpPost("{projectId:int}/sprints")]
        public IActionResult AddSprintToProject(int projectId, SprintDto sprint)
        {

            var sprintToAdd = new Sprint(Duration.FromDays(sprint.Days))
            {
                StartDate = sprint.Start
            };

            var cmd = new AddSprintToProjectCommand(projectId, sprintToAdd);

            var ok =_messageBus.Publish<AddSprintToProjectCommand, bool>(cmd);

            if (!ok)
            {
                return NotFound();
            }

            _unitOfWork.Commit();

            return Ok();
        }

        [HttpGet("{projectId}")]
        public IActionResult GetProject(int projectId)
        {
            var project = _projectRepository.GetById(projectId);

            if (project == null)
                return NotFound();

            return Ok(project);
        }
    }
}
