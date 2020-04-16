using System.Threading.Tasks;

namespace Rivader.Domain.Core
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
