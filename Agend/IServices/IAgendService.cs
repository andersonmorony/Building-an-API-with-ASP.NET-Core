using Agend.Models;
using Agend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.IServices
{
    public interface IAgendService
    {
        Task<(IEnumerable<AgendViewModel> agendModels, bool IsSuccess, string MsgError)> GetAgendsAsync();
        Task<(AgendViewModel agendModel, bool IsSuccess, string MsgError)> GetAgendAsync(string name);
    }
}
