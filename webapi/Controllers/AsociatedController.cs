using Microsoft.AspNetCore.Mvc;
using webapi.db.connection;
using webapi.model;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AsociatedController(IDbConnection _db) : ControllerBase
	{

		private readonly IDbConnection db = _db;

		[HttpGet, Route("{AsociatedId}")]
		public async Task<ActionResult> GetAsociated(int asociatedId)
		{
			var result = await db.GetItem<Asociated>($"{asociatedId}");
			return result is null ? NotFound() : Ok(result);
		}

		[HttpGet, Route("")]

		public async Task<ActionResult> GetAsociateds()
		{
			return Ok(await db.GetItems<Asociated>());
		}

		[HttpPost("")]
		public async Task<ActionResult<Asociated>> AddAsociated([FromBody] Asociated asociated)
		{
			var result = await db.Insert(asociated);

			return result is not null
				? Ok(result)
				: BadRequest();
		}

		[HttpPut, Route("")]
		public async Task<ActionResult> UpdateAsociated([FromBody] Asociated asociated)
		{
			var result = await db.Update(asociated);

			return result
				? Ok(result)
				: BadRequest(result);
		}

		[HttpDelete, Route("{AsociatedId}")]
		public async Task<ActionResult> DeleteAsociated(int asociatedId)
		{
			var result = await db.Delete<Asociated>(asociatedId);

			return result
				? Ok(result)
				: BadRequest(result);
		}
	}
}