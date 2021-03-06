using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.UrlQuery;
using KsuEmployment.Api.Authorization;
using KsuEmployment.BusinessLogic.Interfaces;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Errors;
using KsuEmployment.Common.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KsuEmployment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IResumesService _resumesService;

        public ResumesController(IResumesService resumesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _resumesService = resumesService;
        }

        // GET: /resumes
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<ResumeDTO>>> Get([FromQuery] PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _resumesService.GetRangeOfEntitiesAsync(urlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = urlQuery.PageNumber,
                PageSize = urlQuery.PageSize,
                TotalRecords = await _resumesService.CountAsync()
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get([FromQuery]ResumeUrlQuery resumeUrlQuery, [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
       {
            var dtos = await _resumesService.GetFilteredEntitiesAsync(resumeUrlQuery, paginationUrlQuery);

            if (dtos == null)
            {
                return NotFound();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _resumesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }
 

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ResumeDTO>> GetById(int id)
        {
            try
            {
                var dto = await _resumesService.GetEntityByIdAsync(id);
                if (dto == null)
                {
                    return NotFound();
                }
                return Ok(dto);
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: /resumes
        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<ActionResult<ResumeDTO>> Create([FromBody] ResumeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _resumesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /resumes/:id
        [AllowAnonymous]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]ResumeRequest request)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, id, UserOperations.Update);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _resumesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /resumes/:id
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, id, UserOperations.Delete);

            var result = await _resumesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
