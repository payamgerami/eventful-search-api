using Eventful.Api.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace EventfulTest.Api.Controllers
{
    public class VersionControllerTests
    {
        [Fact]
        public async Task CurrentVersion()
        {
            // Arrange
            var controller = new VersionController();

            // Act
            var result = await controller.Get();

            // Assert
            Assert.Equal("V1", result);
        }
    }
}
