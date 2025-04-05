using Microsoft.AspNetCore.Mvc;
using webapi.db.connection;
using webapi.model;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController(IDbConnection _db) : ControllerBase
	{

		private readonly IDbConnection db = _db;

		[HttpGet, Route("{EventId}")]
		public async Task<ActionResult> GetEvent(int EventId)
		{
			var result = await db.GetItem<Event>($"{EventId}");
			return result is null ? NotFound() : Ok(result);
		}

		[HttpGet, Route("")]

		public async Task<ActionResult> GetEvents()
		{
			return Ok(await db.GetItems<Event>());
		}

		[HttpPost("")]
		public async Task<ActionResult<Event>> AddEvent([FromBody] Event @event)
		{
			var result = await db.Insert(@event);

			return result?.EventId  != 0
				? Ok(result)
				: BadRequest();
		}

		[HttpPut, Route("")]
		public async Task<ActionResult> UpdateEvent([FromBody] Event @event)
		{
			var result = await db.Update(@event);

			return result
				? Ok(result)
				: BadRequest(result);
		}

		[HttpDelete, Route("")]
		public async Task<ActionResult> DeleteEvent([FromBody] Event @event)
		{
			var result = await db.Delete(@event);

			return result
				? Ok(result)
				: BadRequest(result);
		}
	}
}