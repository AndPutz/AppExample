using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AppExampleAPI.Models;
using AppExampleAPI.Business;
using System.ComponentModel.DataAnnotations;

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
        [Route("CreateObject")]     
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

        [HttpPut]
        [Route("UpdateObject")]
        [SwaggerOperation("UpdateObjectTab")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> UpdateObject([FromBody] ObjectTab objectTab)
        {
            var service = new ObjectApiBusiness();
            var rs = await service.UpdateObject(_config, objectTab);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }        

        [HttpPut]
        [Route("DeleteObject/{ID}")]
        [SwaggerOperation("DeleteObjectTab")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> DeleteObject([FromRoute][Required] long ID)
        {            

            var service = new ObjectApiBusiness();
            var rs = await service.DeleteObject(_config, ID);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpGet]
        [Route("SelectAllObjects/")]
        [SwaggerOperation("SelectAllObjectTab")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectAllObject()
        {
            var service = new ObjectApiBusiness();
            var rs = await service.GetAllObjects(_config);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpGet]
        [Route("SelectObjectsByName/{Name}")]
        [SwaggerOperation("SelectObjectsTabByName")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectObjectsTabByName([FromRoute][Required] string Name)
        {
            var service = new ObjectApiBusiness();
            var rs = await service.GetAllObjectsByName(_config, Name);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpGet]
        [Route("GetObjectById/{Id}")]
        [SwaggerOperation("SelectObjectsTabById")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectObjectsTabById([FromRoute][Required] long Id)
        {
            var service = new ObjectApiBusiness();
            var rs = await service.GetObjectById(_config, Id);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpGet]
        [Route("AutoCompleteObjects/{Name}")]
        [SwaggerOperation("SelectObjectAutoComplete")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectObjectAutoComplete([FromRoute][Required] string Name)
        {
            var service = new ObjectApiBusiness();
            var rs = await service.GetObjectsAutoComplete(_config, Name);
            return new ObjectResult(rs);
        }
    }
}