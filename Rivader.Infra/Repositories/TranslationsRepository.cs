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
        public async Task<Translation> GetById(int id)
        {
            return await _context.Translations
                .Include(t => t.CulturedLabels)
                .FirstOrDefaultAsync(t => t.Id == 1);
        }
    }
}
