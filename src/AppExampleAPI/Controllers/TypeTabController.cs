using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AppExampleAPI.Models;
using AppExampleAPI.Business;
using System.ComponentModel.DataAnnotations;

namespace AppExampleAPI.Controllers
{
    [ApiController]        
    public class TypeTabController : ControllerBase
    {       
        private readonly IConfiguration _config;

        public TypeTabController(IConfiguration config)
        {
            _config = config;
        }

        
        [HttpGet]
        [Route("SelectAllTypes/")]
        [SwaggerOperation("SelectAllTypes")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectAllTypes()
        {
            var service = new TypeApiBusiness();
            var rs = await service.GetAll(_config);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

    }
}