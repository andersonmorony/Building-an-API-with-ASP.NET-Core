using Agend.Models;
using Agend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.IRepository
{
    public interface IPeopleRepository
    {
        Task<(PeopleViewModel People, bool IsSuccess, string MsgError)> GetPeopleByAgendId(int id);
    }
}
