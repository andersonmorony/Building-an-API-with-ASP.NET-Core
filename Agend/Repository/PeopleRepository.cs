using Agend.Data;
using Agend.IRepository;
using Agend.Models;
using Agend.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper mapper;

        public PeopleRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<(PeopleViewModel People, bool IsSuccess, string MsgError)> GetPeopleByAgendId(int id)
        {

            var result = await _dbContext.Agends.Include(p => p.People).FirstOrDefaultAsync(e => e.Id == id);

            if(result != null)
            {
                var people = mapper.Map<AgendsModel, PeopleViewModel>(result);
                return (people, true, null);
            }
            return (null, false, "Not Found");

        }
    }
}
