using Agend.IServices;
using Agend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.Controllers
{
    [Route("api/agend")]
    [ApiController]
    [ApiVersion("2.0")]
    public class Agend2Controller : ControllerBase
    {
        private readonly IAgendService _agendService;
        private readonly LinkGenerator _linkGenerator;

        public Agend2Controller(IAgendService agendService, LinkGenerator linkGenerator)
        {
            _agendService = agendService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAgends()
        {
            try
            {
                var result = await _agendService.GetAgendsAsync();

                if(result.IsSuccess)
                {
                    var newResult = new {
                        items = result.agendModels,
                        count = result.agendModels.Count()
                    };
                    return Ok(newResult);
                }
                return BadRequest(null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AgendViewModel>> GetAgend(int id)
        {
            try
            {
                var result = await _agendService.GetAgendAsync(id);

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
        [HttpPost]
        public async Task<ActionResult<AgendViewModel>> CreateAgend(AgendCreateViewModel model)
        {
            try
            {
                 var result = await _agendService.CreateAgend(model);
                var linkGenerate = _linkGenerator.GetPathByAction("GetAgend", "Agend", new { id = result.agendId });

                if(result.IsSuccess)
                {
                    var agend = await _agendService.GetAgendAsync(result.agendId);
                    return Created(linkGenerate, agend.agendModel);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AgendViewModel>> Put(int id, AgendViewModel model)
        {
            try
            {
                var agend = await _agendService.GetAgendAsync(id);

                if (!agend.IsSuccess) return NotFound();

                if(model.People == null)
                {
                    model.People = agend.agendModel.People;
                }

                if (model.SeriveTypeId == 0)
                {
                    model.SeriveTypeId = agend.agendModel.SeriveTypeId;
                }

                var result = await _agendService.PutAgent(id, model);

                if (result.IsSuccess)
                {
                    return result.agend;
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
