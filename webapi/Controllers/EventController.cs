using Microsoft.AspNetCore.Mvc;
using webapi.dao;
using webapi.db;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController(DbConnection _db) : ControllerBase
	{

		private readonly DbConnection db = _db;

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
		public async Task<ActionResult<Event>> AddEvent([FromBody] Event ev)
		{
			var result = await db.Insert(ev);

			return result.EventId != 0
				? Ok(result)
				: BadRequest();
		}

		[HttpPut, Route("")]
		public async Task<ActionResult> UpdateEvent()
		{
			return Ok(QueryGen<Event>.Update);
		}

		[HttpDelete, Route("")]
		public async Task<ActionResult> DeleteEvent()
		{
			return Ok(QueryGen<Event>.Delete);
		}
	}
}