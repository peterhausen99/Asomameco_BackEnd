using Microsoft.AspNetCore.Mvc;
using webapi.dao;
using webapi.db;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController(IConfiguration configuration) : ControllerBase
	{

		private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";

		[HttpGet, Route("{EventId}")]
		public async Task<ActionResult> GetEvent(int EventId)
		{
			var result = await new DbConnection(_connectionString).GetItem<Event>($"{EventId}");
			return result is null ? NotFound() : Ok(result);
		}

		[HttpGet, Route("")]

		public async Task<ActionResult> GetEvents()
		{
			return Ok(await new DbConnection(_connectionString).GetItems<Event>());
		}

		[HttpPut, Route("")]
		public async Task<ActionResult> AddEvent(){
			return Ok();
		}
	}
}