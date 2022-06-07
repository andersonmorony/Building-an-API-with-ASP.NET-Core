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
                var agends = await _agendService.GetAgendsAsync();

                if(agends.IsSuccess)
                {
                    return Ok(agends);
                }
                return BadRequest(null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
