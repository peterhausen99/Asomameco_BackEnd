using Microsoft.AspNetCore.Mvc;
using webapi.db;
using webapi.model;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssistanceController(DbConnection _db) : ControllerBase
	{

		private readonly DbConnection db = _db;

		[HttpGet, Route("{AsitanceId}")]
		public async Task<ActionResult> GetAsistance(int AsitanceId)
		{
			var result = await db.GetItem<Assistance>($"{AsitanceId}");
			return result is null ? NotFound() : Ok(result);
		}

		[HttpGet, Route("")]

		public async Task<ActionResult> GetAsistances()
		{
			return Ok(await db.GetItems<Assistance>());
		}

		[HttpPost("")]
		public async Task<ActionResult<Assistance>> AddAsistance([FromBody] Assistance @event)
		{
			var result = await db.Insert(@event);

			return result.AssistanceId != 0
				? Ok(result)
				: BadRequest();
		}

		[HttpPut, Route("")]
		public async Task<ActionResult> UpdateEvent([FromBody] Assistance @event)
		{
			var result = await db.Update(@event);

			return result
				? Ok(result)
				: BadRequest(result);
		}

		[HttpDelete, Route("")]
		public async Task<ActionResult> DeleteEvent([FromBody] Assistance @event)
		{
			var result = await db.Delete(@event);

			return result
				? Ok(result)
				: BadRequest(result);
		}
	}
}