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
        Task<AgendsModel> GetAgendAsync(string name);
    }
}
