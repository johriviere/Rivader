using Rivader.Domain.Collections;
using Rivader.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Rivader.Domain.Services
{
    public class TranslationsService : ITranslationsService
    {
        private readonly ITranslationsRepository _translationsRepository;

        public TranslationsService(ITranslationsRepository translationsRepository)
        {
            _translationsRepository = translationsRepository ?? throw new ArgumentNullException(nameof(translationsRepository));
        }
        public async Task<Translation> GetById(int id)
        {
            return await _translationsRepository.GetById(id);
        }
    }
}
