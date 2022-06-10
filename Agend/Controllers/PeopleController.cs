using Agend.IRepository;
using Agend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.Controllers
{
    [Route("api/agend/{id}/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        [HttpGet]
        public async Task<ActionResult<PeopleViewModel>> Get(int id)
        {
            try
            {
                var result = await _peopleRepository.GetPeopleByAgendId(id);
                if(result.IsSuccess)
                {
                    return result.People;
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
