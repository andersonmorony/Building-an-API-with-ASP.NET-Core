using Agend.IServices;
using Agend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendController : ControllerBase
    {
        private readonly IAgendService _agendService;

        public AgendController(IAgendService agendService)
        {
            _agendService = agendService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendViewModel>>> GetAgends()
        {
            try
            {
                var result = await _agendService.GetAgendsAsync();

                if(result.IsSuccess)
                {
                    return Ok(result.agendModels);
                }
                return BadRequest(null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{peopleName}")]
        public async Task<ActionResult<AgendViewModel>> GetAgend(string peopleName)
        {
            try
            {
                var result = await _agendService.GetAgendAsync(peopleName);

                if(result.IsSuccess)
                {
                    return result.agendModel;
                }
                return NotFound();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
        }

    }
}
