using Microsoft.EntityFrameworkCore;
using Rivader.Domain.Collections;
using Rivader.Domain.Models;
using Rivader.Infra.Storage;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Rivader.Infra.Repositories
{
    public class TranslationsRepository : ITranslationsRepository
    {
        private readonly RivaderDbContext _context;

        public TranslationsRepository(RivaderDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Delete(int id)
        {
            var translation = await _context.Translations
                .Include(t => t.CulturedLabels)
                .FirstOrDefaultAsync(t => t.Id == id);

            _context.RemoveRange(translation.CulturedLabels);
            _context.Remove(translation);
        }

        public async Task<Translation> Get(int id)
        {
            return await _context.Translations
                .Include(t => t.CulturedLabels)
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Translation> Insert(Translation translation)
        {
            await _context.AddAsync(translation);
            return translation;
        }

        public async Task Update(int id, Translation newTranslation)
        {
            var existingTranslation = await _context.Translations
                .Include(t => t.CulturedLabels)
                .SingleAsync(t => t.Id == id);

            foreach (CulturedLabel newCulturedLabel in newTranslation.CulturedLabels)
            {
                var existingCulturedLabel = existingTranslation.CulturedLabels.SingleOrDefault(x => x.Id == newCulturedLabel.Id);
                if (existingCulturedLabel != null)
                {
                    existingCulturedLabel.Value = newCulturedLabel.Value;
                    existingCulturedLabel.Lcid = newCulturedLabel.Lcid;
                }
            }
        }
    }
}
