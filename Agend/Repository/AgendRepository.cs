using Agend.Data;
using Agend.IRepository;
using Agend.Models;
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

        public AgendRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AgendsModel> GetAgendAsync(string name)
        {
            return await _context.Agends
                .Include(p => p.People)
                .Include(a => a.ServiceType)
                .Where(w => w.People.Firstname.Contains(name) || w.People.Lastname.Contains(name))
                .FirstOrDefaultAsync();
                
        }

        public async Task<IEnumerable<AgendsModel>> GetAgendsAsync()
        {
            return await _context.Agends
                .Include(p => p.People)
                .Include(a => a.ServiceType)
                .ToListAsync();
        }
    }
}
