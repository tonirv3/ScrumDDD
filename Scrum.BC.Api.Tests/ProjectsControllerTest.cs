using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Scrum.BC.Api.Tests
{
    public class ProjectsControllerTest : IClassFixture<WebApplicationFactory<Scrum.BC.Api.Startup>>
    {
        private readonly WebApplicationFactory<Scrum.BC.Api.Startup> _factory;

        public ProjectsControllerTest(WebApplicationFactory<Scrum.BC.Api.Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task GetNonExistentProjectShouldReturn404()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/projects/2");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
