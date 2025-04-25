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
        [InlineData(1, true)] // Event found
        [InlineData(2, false)] // Event not found
        public async Task GetEventTest(int eventId, bool exists)
        {
            // Arrange
            Event? eventItem = exists ? new Event { EventId = (ulong)eventId } : null;
            _mockDb.Setup(db => db.GetItem<Event>(It.IsAny<string>())).ReturnsAsync(eventItem);

            // Act
            ActionResult result = await _controller.GetEvent(eventId);

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
        public async Task GetEventsTest()
        {
            // Arrange
            List<Event> events = new List<Event>
            {
                new Event { EventId = 1 },
                new Event { EventId = 2 }
            };
            _mockDb.Setup(db => db.GetItems<Event>()).ReturnsAsync(events);

            // Act
            ActionResult result = await _controller.GetEvents();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(true)] // Event added successfully
        [InlineData(false)] // Event addition failed
        public async Task AddEventTest(bool success)
        {
            // Arrange
            Event eventItem = new Event { EventId = 1 };
            Event? result = success ? eventItem : null;
            _mockDb.Setup(db => db.Insert(It.IsAny<Event>())).ReturnsAsync(result);

            // Act
            ActionResult<Event> actionResult = await _controller.AddEvent(eventItem);

            // Assert
            if (success)
            {
                Assert.IsType<OkObjectResult>(actionResult.Result);
            }
            else
            {
                Assert.IsType<BadRequestResult>(actionResult.Result);
            }
        }

        [Theory]
        [InlineData(true)] // Event updated successfully
        [InlineData(false)] // Event update failed
        public async Task UpdateEventTest(bool success)
        {
            // Arrange
            Event eventItem = new Event { EventId = 1 };
            _mockDb.Setup(db => db.Update(It.IsAny<Event>())).ReturnsAsync(success);

            // Act
            ActionResult<Event> actionResult = await _controller.UpdateEvent(eventItem);

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
        [InlineData(true)] // Event deleted successfully
        [InlineData(false)] // Event deletion failed
        public async Task DeleteEventTest(bool success)
        {
            // Arrange
            int eventId = 1;
            _mockDb.Setup(db => db.Delete<Event>(It.IsAny<int>())).ReturnsAsync(success);

            // Act
            ActionResult<Event> actionResult = await _controller.DeleteEvent(eventId);

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
