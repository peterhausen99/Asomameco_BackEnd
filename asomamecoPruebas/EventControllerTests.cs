using Moq;
using webapi.Controllers;
using webapi.db.connection;
using webapi.model;
using Microsoft.AspNetCore.Mvc;

namespace webapiPruebas
{
    public class EventControllerTests
    {
        private readonly Mock<IDbConnection> _mockDb;
        private readonly EventController _controller;

        public EventControllerTests()
        {
            _mockDb = new Mock<IDbConnection>();
            _controller = new EventController(_mockDb.Object);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        public async Task GetEventTest(int eventId, bool exists)
        {
            Event? eventItem = exists ? new Event { EventId = (ulong)eventId } : null;
            _mockDb.Setup(db => db.GetItem<Event>(It.IsAny<string>())).ReturnsAsync(eventItem);

            ActionResult result = await _controller.GetEvent(eventId);

            if (exists) Assert.IsType<OkObjectResult>(result);
            else Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetEventsTest()
        {
            List<Event> events =
            [
                new() { EventId = 1 },
                new() { EventId = 2 }
            ];
            _mockDb.Setup(db => db.GetItems<Event>()).ReturnsAsync(events);

            ActionResult result = await _controller.GetEvents();

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task AddEventTest(bool success)
        {
            Event eventItem = new Event { EventId = 1 };
            Event? result = success ? eventItem : null;
            _mockDb.Setup(db => db.Insert(It.IsAny<Event>())).ReturnsAsync(result);

            ActionResult<Event> actionResult = await _controller.AddEvent(eventItem);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task UpdateEventTest(bool success)
        {
            Event eventItem = new Event { EventId = 1 };
            _mockDb.Setup(db => db.Update(It.IsAny<Event>())).ReturnsAsync(success);

            ActionResult<Event> actionResult = await _controller.UpdateEvent(eventItem);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task DeleteEventTest(bool success)
        {
            int eventId = 1;
            _mockDb.Setup(db => db.Delete<Event>(It.IsAny<int>())).ReturnsAsync(success);

            ActionResult<Event> actionResult = await _controller.DeleteEvent(eventId);

            if (success) Assert.IsType<OkObjectResult>(actionResult.Result);
            else Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }
    }
}
