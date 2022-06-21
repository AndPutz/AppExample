using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AppExampleAPI.Models;
using AppExampleAPI.Business;

namespace AppExampleAPI.Controllers
{
    [ApiController]        
    public class ObjectTabController : ControllerBase
    {       
        private readonly IConfiguration _config;

        public ObjectTabController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("[controller]")]     
        [SwaggerOperation("CreateObjectTab")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> CreateObject([FromBody] ObjectTab objectTab)
        {
            var service = new ObjectApiBusiness();
            var rs = await service.CreateObject(_config, objectTab);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }
    }
}