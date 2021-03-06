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
using KsuEmployment.Common.Errors;
using KsuEmployment.Common.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KsuEmployment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitersController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IRecruitersService _recruitersService;

        public RecruitersController(IRecruitersService recruitersService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _recruitersService = recruitersService;
        }

        // GET: /recruiters
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> Get()
        {
            var dtos = await _recruitersService.GetAllRecruitersAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> Get([FromQuery]SearchingUrlQuery searchingUrlQuery = null, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _recruitersService.GetFilteredRecruitersAsync(searchingUrlQuery, sortingUrlQuery, paginationUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _recruitersService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("company/{id}")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetRecruitersByCompanyId(int id, [FromQuery] PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _recruitersService.GetRecruitersByCompanyIdAsync(id, urlQuery);

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
                    TotalRecords = await _recruitersService.CountAsync(r => r.CompanyId == id)
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("company/{id}/filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> GetFilteredRecruiters(int id, string searchString, [FromQuery]PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _recruitersService.GetFilteredRecruitersAsync(id, searchString, null, urlQuery);

            if (dtos == null)
            {
                return NotFound();
            }


            if (urlQuery != null)
            {
                var pageInfo = new PageInfo()
                {
                    PageNumber = urlQuery.PageNumber,
                    PageSize = urlQuery.PageSize,
                    TotalRecords = await _recruitersService.CountAsync(r => r.CompanyId == id && r.FirstName == searchString)
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            }

            return Ok(dtos);
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<RecruiterDTO>> GetById(int id)
        {
            var dto = await _recruitersService.GetRecruiterByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /recruiters
        [AllowAnonymous]
        [HttpPost("register")]
        public virtual async Task<ActionResult<RecruiterDTO>> Register([FromBody] RecruiterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dtos = await _recruitersService.CreateRecruiterAsync(request);

                if (dtos == null)
                {
                    return StatusCode(500);
                }

                return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: /recruiters/:id
        [AllowAnonymous]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]RecruiterUpdateRequest request)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, request.CompanyId, UserOperations.Update);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _recruitersService.UpdateRecruiterByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /recruiters/:id
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var entity = await _recruitersService.GetRecruiterByIdAsync(id);

            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, entity.Company.Id, UserOperations.Update);


            var result = await _recruitersService.DeleteRecruiterByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPut("{id}/reset")]
        public virtual async Task<ActionResult> ResetPassword([FromRoute]int id, [FromBody]RecruierResetPasswordRequest request)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, id, UserOperations.Update);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _recruitersService.ResetEntityByIdAsync(request, id);
                if (!result)
                {
                    return StatusCode(500);
                }

                return NoContent();
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
