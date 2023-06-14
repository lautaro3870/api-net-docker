using CloudCustomrs.API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomrs.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly Request _request;

        public RequestController(Request request)
        {
            _request = request;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _request.MakeRequest();

            return Ok(response);
        }
    }
}
