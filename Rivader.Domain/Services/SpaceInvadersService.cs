using Rivader.Domain.Collections;
using Rivader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rivader.Domain.Services
{
    public class SpaceInvadersService : ISpaceInvadersService
    {
        private readonly ISpaceInvadersRepository _spaceInvadersRepository;

        public SpaceInvadersService(ISpaceInvadersRepository spaceInvadersRepository)
        {
            _spaceInvadersRepository = spaceInvadersRepository;
        }

        public async Task<IEnumerable<SpaceInvader>> GetAll()
        {
            return _spaceInvadersRepository.GetAll();
        }
    }
}
