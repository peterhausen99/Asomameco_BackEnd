using Xunit;
using Moq;
using webapi.Controllers;
using webapi.db.connection;
using webapi.model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webapiPruebas
{
    public class AssistanceControllerTests
    {
        private readonly Mock<IDbConnection> _mockDb;
        private readonly AssistanceController _controller;

        public AssistanceControllerTests()
        {
            _mockDb = new Mock<IDbConnection>();
            _controller = new AssistanceController(_mockDb.Object);
        }

        [Theory]
        [InlineData(1, true)] // Assistance found
        [InlineData(2, false)] // Assistance not found
        public async Task GetAssistanceTest(int assistanceId, bool exists)
        {
            // Arrange
            Assistance? assistance = exists ? new Assistance { AssistanceId = (ulong)assistanceId } : null;
            _mockDb.Setup(db => db.GetItem<Assistance>(It.IsAny<string>())).ReturnsAsync(assistance);

            // Act
            ActionResult result = await _controller.GetAssistance(assistanceId);

            // Assert
            if (exists)
            {
                Assert.IsType<OkObjectResult>(result);
            }
            else
            {
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task GetAssistancesTest()
        {
            // Arrange
            List<Assistance> assistances = new List<Assistance>
            {
                new Assistance { AssistanceId = 1 },
                new Assistance { AssistanceId = 2 }
            };
            _mockDb.Setup(db => db.GetItems<Assistance>()).ReturnsAsync(assistances);

            // Act
            ActionResult result = await _controller.GetAssistances();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(true)] // Assistance added successfully
        [InlineData(false)] // Assistance addition failed
        public async Task AddAssistanceTest(bool success)
        {
            // Arrange
            Assistance assistance = new Assistance { AssistanceId = 1 };
            Assistance? result = success ? assistance : null;
            _mockDb.Setup(db => db.Insert(It.IsAny<Assistance>())).ReturnsAsync(result);

            // Act
            ActionResult<Assistance> actionResult = await _controller.AddAssistance(assistance);

            // Assert
            if (success)
            {
                Assert.IsType<OkObjectResult>(actionResult.Result); // Fixed: Check the inner result
            }
            else
            {
                Assert.IsType<BadRequestResult>(actionResult.Result); // Fixed: Check the inner result
            }
        }

        [Theory]
        [InlineData(true)] // Assistance updated successfully
        [InlineData(false)] // Assistance update failed
        public async Task UpdateEventTest(bool success)
        {
            // Arrange
            Assistance assistance = new Assistance { AssistanceId = 1 };
            _mockDb.Setup(db => db.Update(It.IsAny<Assistance>())).ReturnsAsync(success);

            // Act
            ActionResult<Assistance> actionResult = await _controller.UpdateEvent(assistance);

            // Assert
            if (success)
            {
                Assert.IsType<OkObjectResult>(actionResult.Result);
            }
            else
            {
                Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            }
        }

        [Theory]
        [InlineData(true)] // Assistance deleted successfully
        [InlineData(false)] // Assistance deletion failed
        public async Task DeleteEventTest(bool success)
        {
            // Arrange
            int assistanceId = 1;
            _mockDb.Setup(db => db.Delete<Assistance>(It.IsAny<int>())).ReturnsAsync(success);

            // Act
            ActionResult<Assistance> actionResult = await _controller.DeleteEvent(assistanceId);

            // Assert
            if (success)
            {
                Assert.IsType<OkObjectResult>(actionResult.Result);
            }
            else
            {
                Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            }
        }
    }
}

