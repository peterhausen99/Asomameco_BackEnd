using Moq;
using webapi.Controllers;
using webapi.db.connection;
using webapi.model;
using Microsoft.AspNetCore.Mvc;

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
        [InlineData(1, true)]
        [InlineData(2, false)]
        public async Task GetAsociatedTest(int asociatedId, bool exists)
        {
            Asociated? asociated = exists ? new Asociated { UserIdentity = (ulong)asociatedId } : null;
            _mockDb.Setup(db => db.GetItem<Asociated>(It.IsAny<string>())).ReturnsAsync(asociated);

            ActionResult result = await _controller.GetAsociated(asociatedId);

            if (exists) Assert.IsType<OkObjectResult>(result);
            else Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAsociatedsTest()
        {
            List<Asociated> asociateds =
            [
                new() { UserIdentity = 1 },
                new() { UserIdentity = 2 }
            ];
            _mockDb.Setup(db => db.GetItems<Asociated>()).ReturnsAsync(asociateds);

            ActionResult result = await _controller.GetAsociateds();

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task AddAsociatedTest(bool success)
        {
            Asociated asociated = new Asociated { UserIdentity = 1 };
            Asociated? result = success ? asociated : null;
            _mockDb.Setup(db => db.Insert(It.IsAny<Asociated>())).ReturnsAsync(result);

            ActionResult<Asociated> actionResult = await _controller.AddAsociated(asociated);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task UpdateAsociatedTest(bool success)
        {
            Asociated asociated = new Asociated { UserIdentity = 1 };
            _mockDb.Setup(db => db.Update(It.IsAny<Asociated>())).ReturnsAsync(success);

            ActionResult<Asociated> actionResult = await _controller.UpdateAsociated(asociated);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task DeleteAsociatedTest(bool success)
        {
            int asociatedId = 1;
            _mockDb.Setup(db => db.Delete<Asociated>(It.IsAny<int>())).ReturnsAsync(success);

            ActionResult<Asociated> actionResult = await _controller.DeleteAsociated(asociatedId);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }
    }
}

