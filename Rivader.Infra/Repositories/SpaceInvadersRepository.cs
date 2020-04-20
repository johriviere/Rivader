using Microsoft.EntityFrameworkCore;
using Rivader.Domain.Collections;
using Rivader.Domain.Models;
using Rivader.Infra.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rivader.Infra.Repositories
{
    public class SpaceInvadersRepository : ISpaceInvadersRepository
    {
        private readonly RivaderDbContext _context;

        public SpaceInvadersRepository(RivaderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpaceInvader>> GetAll()
        {
            return await _context.SpaceInvaders
                            .Include(s => s.Country)
                            .ThenInclude(c => c.Translation)
                            .ThenInclude(t => t.CulturedLabels)
                            .Include(s => s.City)
                            .ThenInclude(c => c.Translation)
                            .ThenInclude(t => t.CulturedLabels)
                            .ToListAsync();
            //return await _context.Set<SpaceInvader>().ToListAsync();
        }
    }
}
