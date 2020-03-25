using Rivader.Domain.Collections;
using Rivader.Domain.Models;
using Rivader.Infra.Storage;
using System.Collections.Generic;

namespace Rivader.Infra.Repositories
{
    public class SpaceInvadersRepository : ISpaceInvadersRepository
    {
        private readonly RivaderDbContext _context;

        public SpaceInvadersRepository(RivaderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SpaceInvader> GetAll()
        {
            return _context.SpaceInvaders;
        }
    }
}
