using Rivader.Domain.Models;
using System.Collections.Generic;

namespace Rivader.Domain.Collections
{
    public interface ISpaceInvadersRepository
    {
        IEnumerable<SpaceInvader> GetAll();
    }
}
