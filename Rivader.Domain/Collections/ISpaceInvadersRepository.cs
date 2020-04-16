using Rivader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rivader.Domain.Collections
{
    public interface ISpaceInvadersRepository
    {
        Task<IEnumerable<SpaceInvader>> GetAll();
    }
}
