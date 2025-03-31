using Microsoft.AspNetCore.Mvc;
using webapi.db;
using webapi.model;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AsociatedController(DbConnection _db) : ControllerBase
	{

		private readonly DbConnection db = _db;

		[HttpGet, Route("{AsociatedId}")]
		public async Task<ActionResult> GetAsociated(int AsociatedId)
		{
			var result = await db.GetItem<Asociated>($"{AsociatedId}");
			return result is null ? NotFound() : Ok(result);
		}

		[HttpGet, Route("")]

		public async Task<ActionResult> GetAsociateds()
		{
			return Ok(await db.GetItems<Asociated>());
		}

		[HttpPost("")]
		public async Task<ActionResult<Asociated>> AddAsociated([FromBody] Asociated @Asociated)
		{
			var result = await db.Insert(@Asociated);

			return result is not null
				? Ok(result)
				: BadRequest();
		}

		[HttpPut, Route("")]
		public async Task<ActionResult> UpdateAsociated([FromBody] Asociated @Asociated)
		{
			var result = await db.Update(@Asociated);

			return result
				? Ok(result)
				: BadRequest(result);
		}

		[HttpDelete, Route("")]
		public async Task<ActionResult> DeleteAsociated([FromBody] Asociated @Asociated)
		{
			var result = await db.Delete(@Asociated);

			return result
				? Ok(result)
				: BadRequest(result);
		}
	}
}