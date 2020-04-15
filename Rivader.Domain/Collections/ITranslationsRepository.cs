using Rivader.Domain.Models;
using System.Threading.Tasks;

namespace Rivader.Domain.Collections
{
    public interface ITranslationsRepository
    {
        Task<Translation> GetById(int id);
    }
}
