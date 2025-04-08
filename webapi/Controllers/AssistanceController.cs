using Microsoft.AspNetCore.Mvc;
using webapi.db.connection;
using webapi.model;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssistanceController(IDbConnection _db) : ControllerBase
	{

		private readonly IDbConnection db = _db;

		[HttpGet, Route("{AssitanceId}")]
		public async Task<ActionResult> GetAssistance(int AssitanceId)
		{
			var result = await db.GetItem<Assistance>($"{AssitanceId}");
			return result is null ? NotFound() : Ok(result);
		}

		[HttpGet, Route("")]

		public async Task<ActionResult> GetAssistances()
		{
			return Ok(await db.GetItems<Assistance>());
		}

		[HttpPost("")]
		public async Task<ActionResult<Assistance>> AddAssistance([FromBody] Assistance assistance)
		{
			var result = await db.Insert(assistance);

			return result is not null
				? Ok(result)
				: BadRequest();
		}

		[HttpPut, Route("")]
		public async Task<ActionResult> UpdateEvent([FromBody] Assistance assistance)
		{
			var result = await db.Update(assistance);

			return result
				? Ok(result)
				: BadRequest(result);
		}

		[HttpDelete, Route("{AssitanceId}")]
		public async Task<ActionResult> DeleteEvent(int AssitanceId)
		{
			var result = await db.Delete<Assistance>(AssitanceId);

			return result
				? Ok(result)
				: BadRequest(result);
		}
	}
}