using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Event : ControllerBase
	{

		[HttpGet, Route("{EventId}")]
		public ActionResult GetEvent(int EventId)
		{
			return new JsonResult(new[] { EventId });
		}

		[HttpGet, Route("")]

		public ActionResult Index()
		{
			return new JsonResult(new { 
				result = "hola mundo" 
			});
		}
	}
}