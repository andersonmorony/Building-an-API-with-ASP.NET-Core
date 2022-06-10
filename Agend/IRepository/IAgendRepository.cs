using Agend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.IRepository
{
    public interface IAgendRepository
    {
        Task<IEnumerable<AgendsModel>> GetAgendsAsync();
        Task<AgendsModel> GetAgendAsync(int id);
        Task<int> CreateAgend(AgendsModel model);
        Task<AgendsModel> PutAgent(int id, AgendsModel newModel);
    }
}
