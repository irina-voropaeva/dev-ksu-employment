using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
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
    public class InvitationsController : ControllerBase
    {
        private IInvitationsService _invitationsService;

        public InvitationsController(IInvitationsService invitationsService)
        {
            _invitationsService = invitationsService;
        }

        // GET: /invitations
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<InvitationDTO>>> Get()
        {
            var dtos = await _invitationsService.GetAllInvitationsAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<InvitationDTO>> GetById(int id)
        {
            var dto = await _invitationsService.GetInvitationByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [AllowAnonymous]
        [HttpGet("employee/{id}")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetInvitationsByEmployeeId(int id, [FromQuery] PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _invitationsService.GetInvitationsByEmployeeIdAsync(id, urlQuery);

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
                    TotalRecords = await _invitationsService.CountAsync(r => r.EmployeeId == id)
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            }

            return Ok(dtos);
        }

        // POST: /invitations
        //[AllowAnonymous]
        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<ActionResult<InvitationDTO>> Create([FromBody] InvitationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _invitationsService.CreateInvitationAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /invitations/:id
        [AllowAnonymous]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]InvitationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invitationsService.UpdateInvitationByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /invitations/:id
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _invitationsService.DeleteInvitationByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

    }
}