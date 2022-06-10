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
    public class AgendRepository : IAgendRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AgendRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAgend(AgendsModel model)
        {
            await _context.Agends.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;

        }

        public async Task<AgendsModel> GetAgendAsync(int id)
        {
            //return await _context.Agends
            //    .Include(p => p.People)
            //    .Include(a => a.ServiceType)
            //    .Where(w => w.People.Firstname.Contains(name) || w.People.Lastname.Contains(name))
            //    .FirstOrDefaultAsync();

            return await _context.Agends
                .Include(p => p.People)
                .Include(a => a.ServiceType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<AgendsModel>> GetAgendsAsync()
        {
            return await _context.Agends
                .Include(p => p.People)
                .Include(a => a.ServiceType)
                .ToListAsync();
        }

        public async Task<AgendsModel> PutAgent(int id, AgendsModel newModel)
        {
            var model = await _context.Agends
                .Include(p => p.People)
                .Include(a => a.ServiceType)
                .FirstOrDefaultAsync(p => p.Id == id);

            model = _mapper.Map<AgendsModel, AgendsModel>(newModel, model);

            await _context.SaveChangesAsync();

            return model;

        }
    }
}
