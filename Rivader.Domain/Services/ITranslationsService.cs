using Rivader.Domain.Models;
using System.Threading.Tasks;

namespace Rivader.Domain.Services
{
    public interface ITranslationsService
    {
        Task<Translation> Get(int id);
        Task Delete (int id);
    }
}
