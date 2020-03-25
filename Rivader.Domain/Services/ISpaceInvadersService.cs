using Rivader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rivader.Domain.Services
{
    public interface ISpaceInvadersService
    {
        Task<IEnumerable<SpaceInvader>> GetAll();
    }
}
