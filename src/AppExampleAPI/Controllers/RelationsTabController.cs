using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AppExampleAPI.Models;
using AppExampleAPI.Business;
using System.ComponentModel.DataAnnotations;

namespace AppExampleAPI.Controllers
{
    [ApiController]        
    public class RelationsTabController : ControllerBase
    {       
        private readonly IConfiguration _config;

        public RelationsTabController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("[controller]")]     
        [SwaggerOperation("CreateRelationsTab")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> CreateRelation([FromBody] RelationsTab relationsTab)
        {
            var service = new RelationsApiBusiness();
            var rs = await service.CreateRelations(_config, relationsTab);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpPut]
        [Route("[controller]")]
        [SwaggerOperation("UpdateRelations")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> UpdateRelations([FromBody] RelationsTab relationsTab)
        {
            var service = new RelationsApiBusiness();
            var rs = await service.UpdateRelations(_config, relationsTab);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }        

        [HttpPut]
        [Route("RelationsTab/{ID}")]
        [SwaggerOperation("DeleteRelations")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> DeleteRelations([FromRoute][Required] long ID)
        {            
            var service = new RelationsApiBusiness();
            var rs = await service.DeleteRelations(_config, ID);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpGet]
        [Route("AllRelationsTab/")]
        [SwaggerOperation("SelectAllRelationsTab")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectAllRelations()
        {
            var service = new RelationsApiBusiness();
            var rs = await service.GetAllRelations(_config);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpGet]
        [Route("RelationsTabByName/{Name}")]
        [SwaggerOperation("SelectRelationsTabByName")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectRelationsTabByName([FromRoute][Required] string Name)
        {
            var service = new RelationsApiBusiness();
            var rs = await service.GetAllRelationsByName(_config, Name);
            return new ObjectResult(rs) { StatusCode = rs.StatusCode };
        }

        [HttpGet]
        [Route("RelationsTabAutoComplete/{Name}")]
        [SwaggerOperation("SelectRelationsAutoComplete")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObjectTabResponse), description: "Success")]
        [SwaggerResponse(statusCode: 401, type: typeof(ObjectTabResponse), description: "Not Authorized")]
        [SwaggerResponse(statusCode: 404, type: typeof(ObjectTabResponse), description: "Request processing error")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> SelectRelationsAutoComplete([FromRoute][Required] string Name)
        {
            var service = new RelationsApiBusiness();
            var rs = await service.GetRelationsAutoComplete(_config, Name);
            return new ObjectResult(rs);
        }
    }
}