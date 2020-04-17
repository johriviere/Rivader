using Rivader.Domain.Collections;
using Rivader.Domain.Core.Exceptions;
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

        public async Task<Translation> Create(Translation translation)
        {
            return await _translationsRepository.Insert(translation);
        }

        public async Task Delete(int id)
        {
            await _translationsRepository.Delete(id);
        }

        public async Task<Translation> Get(int id)
        {
            return await _translationsRepository.Get(id);
        }

        public async Task Update(int id, Translation newTranslation)
        {
            Translation existingTranslation = await _translationsRepository.Get(id);
            if (existingTranslation == null)
            {
                throw new NotFoundException($"translation {id} does not exist.");
            }
            await _translationsRepository.Update(id, newTranslation);
        }
    }
}
