using System;
using Xunit;
using FluentAssertions;

namespace ScrumDDD.Domain.Entities.Tests
{
    public class SprintTests
    {
        [Fact]
        public void GivenTwoSprintsThatHaveStartDateTheyShouldCollide()
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

            sprint1.Overlaps(sprint2).Should().BeTrue();
            
        }
    }
}
