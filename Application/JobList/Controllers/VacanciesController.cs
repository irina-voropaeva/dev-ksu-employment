using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.Sorting;
using KsuEmployment.Common.UrlQuery;
using KsuEmployment.Api.Authorization;
using KsuEmployment.BusinessLogic.Interfaces;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KsuEmployment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IVacanciesService _vacanciesService;

        public VacanciesController(IVacanciesService vacanciesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _vacanciesService = vacanciesService;
        }

        // GET: /vacancies
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get([FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _vacanciesService.GetRangeOfEntitiesAsync(paginationUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _vacanciesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get(
            [FromQuery]VacancyUrlQuery vacancyUrlQuery = null, 
            [FromQuery]SearchingUrlQuery searchingUrlQuery = null, 
            [FromQuery]SortingUrlQuery sortingUrlQuery = null, 
            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _vacanciesService.GetFilteredEntitiesAsync(vacancyUrlQuery, searchingUrlQuery, sortingUrlQuery, paginationUrlQuery);

            if (dtos == null)
            {
                return NotFound();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _vacanciesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("recruiter/{id}/filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get(int id, string searchString, [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _vacanciesService.GetFilteredEntitiesAsync(id, searchString, paginationUrlQuery);

            if (dtos == null)
            {
                return NotFound();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _vacanciesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);

        }

        [AllowAnonymous]
        [HttpGet("recruiter/{id}")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetRecruitersByCompanyId(int id, [FromQuery] PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _vacanciesService.GetVacanciesByRecruiterIdAsync(id, urlQuery);


            if (!dtos.Any())
            {
                return NoContent();
            }

            if (urlQuery != null)
            {
                var pageInfo = new PageInfo()
                {
                    PageNumber = urlQuery.PageNumber,
                    PageSize = urlQuery.PageSize,
                    TotalRecords = await _vacanciesService.CountAsync(r => r.RecruiterId == id)
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<VacancyDTO>> GetById(int id)
        {
            var dto = await _vacanciesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /vacancies
        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<ActionResult<VacancyDTO>> Create([FromBody] VacancyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _vacanciesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /vacancies/:id
        [AllowAnonymous]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]VacancyRequest request)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, request.RecruiterId, UserOperations.Update);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _vacanciesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /vacancies/:id
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var entity = await _vacanciesService.GetEntityByIdAsync(id);

            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, entity.Recruiter.Id, UserOperations.Delete);

            var result = await _vacanciesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }

}
