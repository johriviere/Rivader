using Rivader.Domain.Collections;
using Rivader.Domain.Core;
using Rivader.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Rivader.Domain.Services
{
    public class TranslationsService : ITranslationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITranslationsRepository _translationsRepository;

        public TranslationsService(IUnitOfWork unitOfWork, ITranslationsRepository translationsRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _translationsRepository = translationsRepository ?? throw new ArgumentNullException(nameof(translationsRepository));
        }

        public async Task<Translation> Create(Translation translation)
        {
            var result = await _translationsRepository.Insert(translation);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task Delete(int id)
        {
            await _translationsRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Translation> Get(int id)
        {
            return await _translationsRepository.Get(id);
        }
    }
}
