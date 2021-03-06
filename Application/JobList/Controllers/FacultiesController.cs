using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.BusinessLogic.Interfaces;
using KsuEmployment.Common.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KsuEmployment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : Controller
    {
        private IFacultiesService _facultiesService;

        public FacultiesController(IFacultiesService facultiesService)
        {
            _facultiesService = facultiesService;
        }

        // GET: /faculties
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<FacultyDTO>>> Get()
        {
            var dtos = await _facultiesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<FacultyDTO>> GetById(int id)
        {
            var dto = await _facultiesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /faculties
        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<ActionResult<FacultyDTO>> Create([FromBody] FacultyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _facultiesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /faculties/:id
        [AllowAnonymous]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]FacultyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _facultiesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /faculties/:id
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _facultiesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
