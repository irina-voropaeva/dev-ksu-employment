using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Api.Authorization;
using KsuEmployment.BusinessLogic.Interfaces;
using KsuEmployment.Common.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KsuEmployment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationPeriodsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IEducationPeriodsService _educationPeriodsService;

        public EducationPeriodsController(IEducationPeriodsService educationPeriodsService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _educationPeriodsService = educationPeriodsService;
        }

        // GET: /educationPeriods
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<EducationPeriodDTO>>> Get()
        {
            var dtos = await _educationPeriodsService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<EducationPeriodDTO>> GetById(int id)
        {
            var dto = await _educationPeriodsService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /educationPeriods
        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<ActionResult<EducationPeriodDTO>> Create([FromBody] EducationPeriodRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _educationPeriodsService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /educationPeriods/:id
        [AllowAnonymous]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]EducationPeriodRequest request)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, request.ResumeId, UserOperations.Update);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _educationPeriodsService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }


        // DELETE: /educationPeriods/:id
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var entity = await _educationPeriodsService.GetEntityByIdAsync(id);

            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, entity.ResumeId, UserOperations.Delete);

            var result = await _educationPeriodsService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
