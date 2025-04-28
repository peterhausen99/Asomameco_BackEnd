using Moq;
using webapi.Controllers;
using webapi.db.connection;
using webapi.model;
using Microsoft.AspNetCore.Mvc;

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
        [InlineData(1, true)]
        [InlineData(2, false)]
        public async Task GetAssistanceTest(int assistanceId, bool exists)
        {
            Assistance? assistance = exists ? new Assistance { AssistanceId = (ulong)assistanceId } : null;
            _mockDb.Setup(db => db.GetItem<Assistance>(It.IsAny<string>())).ReturnsAsync(assistance);

            ActionResult result = await _controller.GetAssistance(assistanceId);

            if (exists) Assert.IsType<OkObjectResult>(result);
            else Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAssistancesTest()
        {
            List<Assistance> assistances =
            [
                new() { AssistanceId = 1 },
                new() { AssistanceId = 2 }
            ];
            _mockDb.Setup(db => db.GetItems<Assistance>()).ReturnsAsync(assistances);

            ActionResult result = await _controller.GetAssistances();

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task AddAssistanceTest(bool success)
        {
            Assistance assistance = new Assistance { AssistanceId = 1 };
            Assistance? result = success ? assistance : null;
            _mockDb.Setup(db => db.Insert(It.IsAny<Assistance>())).ReturnsAsync(result);

            ActionResult<Assistance> actionResult = await _controller.AddAssistance(assistance);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task UpdateEventTest(bool success)
        {
            Assistance assistance = new Assistance { AssistanceId = 1 };
            _mockDb.Setup(db => db.Update(It.IsAny<Assistance>())).ReturnsAsync(success);

            ActionResult<Assistance> actionResult = await _controller.UpdateEvent(assistance);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task DeleteEventTest(bool success)
        {
            int assistanceId = 1;
            _mockDb.Setup(db => db.Delete<Assistance>(It.IsAny<int>())).ReturnsAsync(success);

            ActionResult<Assistance> actionResult = await _controller.DeleteEvent(assistanceId);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }
    }
}

