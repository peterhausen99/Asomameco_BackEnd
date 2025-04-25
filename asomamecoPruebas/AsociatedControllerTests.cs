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
    public class AsociatedControllerTests
    {
        private readonly Mock<IDbConnection> _mockDb;
        private readonly AsociatedController _controller;

        public AsociatedControllerTests()
        {
            _mockDb = new Mock<IDbConnection>();
            _controller = new AsociatedController(_mockDb.Object);
        }

        [Theory]
        [InlineData(1, true)] // Asociated found
        [InlineData(2, false)] // Asociated not found
        public async Task GetAsociatedTest(int asociatedId, bool exists)
        {
            // Arrange
            Asociated? asociated = exists ? new Asociated { UserIdentity = (ulong)asociatedId } : null;
            _mockDb.Setup(db => db.GetItem<Asociated>(It.IsAny<string>())).ReturnsAsync(asociated);

            // Act
            ActionResult result = await _controller.GetAsociated(asociatedId);

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
        public async Task GetAsociatedsTest()
        {
            // Arrange
            List<Asociated> asociateds = new List<Asociated>
            {
                new Asociated { UserIdentity = 1 },
                new Asociated { UserIdentity = 2 }
            };
            _mockDb.Setup(db => db.GetItems<Asociated>()).ReturnsAsync(asociateds);

            // Act
            ActionResult result = await _controller.GetAsociateds();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(true)] // Asociated added successfully
        [InlineData(false)] // Asociated addition failed
        public async Task AddAsociatedTest(bool success)
        {
            // Arrange
            Asociated asociated = new Asociated { UserIdentity = 1 };
            Asociated? result = success ? asociated : null;
            _mockDb.Setup(db => db.Insert(It.IsAny<Asociated>())).ReturnsAsync(result);

            // Act
            ActionResult<Asociated> actionResult = await _controller.AddAsociated(asociated);

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
        [InlineData(true)] // Asociated updated successfully
        [InlineData(false)] // Asociated update failed
        public async Task UpdateAsociatedTest(bool success)
        {
            // Arrange
            Asociated asociated = new Asociated { UserIdentity = 1 };
            _mockDb.Setup(db => db.Update(It.IsAny<Asociated>())).ReturnsAsync(success);

            // Act
            ActionResult<Asociated> actionResult = await _controller.UpdateAsociated(asociated);

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
        [InlineData(true)] // Asociated deleted successfully
        [InlineData(false)] // Asociated deletion failed
        public async Task DeleteAsociatedTest(bool success)
        {
            // Arrange
            int asociatedId = 1;
            _mockDb.Setup(db => db.Delete<Asociated>(It.IsAny<int>())).ReturnsAsync(success);

            // Act
            ActionResult<Asociated> actionResult = await _controller.DeleteAsociated(asociatedId);

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

