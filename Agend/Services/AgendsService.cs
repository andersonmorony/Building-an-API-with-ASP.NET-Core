using Agend.IRepository;
using Agend.IServices;
using Agend.Models;
using Agend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Agend.Services
{
    public class AgendsService : IAgendService
    {
        private readonly IAgendRepository _agendRepository;
        private readonly IMapper _mapper;

        public AgendsService(IAgendRepository agendRepository, IMapper mapper)
        {
            _agendRepository = agendRepository;
            _mapper = mapper;
        }

        public async Task<(int agendId, bool IsSuccess, string MsgError)> CreateAgend(AgendCreateViewModel model)
        {
            try
            {
                var agendMapped =  _mapper.Map<AgendCreateViewModel, AgendsModel>(model);
                var agendId = await _agendRepository.CreateAgend(agendMapped);

                return (agendId, true, null);
            }
            catch (Exception ex)
            {
                return (0, false, ex.Message);
            }
        }

        public async Task<(AgendViewModel agendModel, bool IsSuccess, string MsgError)> GetAgendAsync(int id)
        {
            try
            {
                var agend = await _agendRepository.GetAgendAsync(id);

                if(agend != null)
                {
                    var result = _mapper.Map<AgendsModel, AgendViewModel>(agend);
                    return (result, true, null);
                }
                return (null, false, "Not found");
            }
            catch (Exception ex)
            {
                return (null, false, ex.Message);
            }
        }

        public async Task<(IEnumerable<AgendViewModel> agendModels, bool IsSuccess, string MsgError)> GetAgendsAsync()
        {
            try
            {
                var agend = await _agendRepository.GetAgendsAsync();

                if (agend != null)
                {
                    var result = _mapper.Map<IEnumerable<AgendsModel>, IEnumerable<AgendViewModel>>(agend);
                    return (result, true, null);
                }
                return (null, false, "Not found");
            }
            catch (Exception ex)
            {
                return (null, false, ex.Message);
            }
        }

        public async Task<(AgendViewModel agend, bool IsSuccess, string MsgError)> PutAgent(int id, AgendViewModel model)
        {
           try
            {
                var newModel = _mapper.Map<AgendViewModel, AgendsModel>(model);

                var agend = await _agendRepository.PutAgent(id, newModel);

                var newAgend = _mapper.Map<AgendsModel, AgendViewModel>(agend);

                return (newAgend, true, null);

            } catch(Exception ex)
            {
                return (null, false, ex.Message);
            }


        }
    }
}
