using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Rivader.Domain.Core;
using Rivader.Domain.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace Rivader.Infra.Storage
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RivaderDbContext _context;

        public UnitOfWork(RivaderDbContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions
                throw (ex.InnerException?.InnerException) switch
                {
                    ArgumentException ae => ae,
                    SqlException se => se.Number switch
                    {
                        2627 => new TechnicalException(se.Message) as Exception,
                        _ => se,
                    },
                    _ => ex.InnerException ?? ex,
                };
            }
        }
    }
}
