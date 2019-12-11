using ScrumDDD.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScrumDDD.Domain.Entities.Tests
{
    
    public class ProjectTests
    {
        [Fact]
        public void GivenProjectAddColliderSprintShouldThrowException()
        {
            Duration duration = Duration.FromDays(15);

            Sprint sprint1 = new Sprint(duration)
            {
                Id = 1,
                StartDate = new DateTime(2019, 12, 1)
            };

            Sprint sprint2 = new Sprint(duration)
            {
                Id = 1,
                StartDate = new DateTime(2019, 12, 1)
            };

            var project = new Project()
            {
                Id = 1,
                Title = "Test Project",
                Owner = null
            };

            project.AddSprint(sprint1);

            Assert.Throws<DomainException>(() =>
            {
                project.AddSprint(sprint2);
            });                        
        }
        }
    }

