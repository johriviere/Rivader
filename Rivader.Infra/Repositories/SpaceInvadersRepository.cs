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
            return await _context.SpaceInvaders.ToListAsync();
            //return await _context.Set<SpaceInvader>().ToListAsync();
        }
    }
}
