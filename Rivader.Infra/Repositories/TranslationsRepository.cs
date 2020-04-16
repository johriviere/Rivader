using Microsoft.EntityFrameworkCore;
using Rivader.Domain.Collections;
using Rivader.Domain.Models;
using Rivader.Infra.Storage;
using System;
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

            await _context.SaveChangesAsync();
        }

        public async Task<Translation> Get(int id)
        {
            return await _context.Translations
                .Include(t => t.CulturedLabels)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Translation> Insert(Translation entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
