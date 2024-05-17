using DesignPatterns.ChainOfResponsibility.contexts;
using DesignPatterns.ChainOfResponsibility.models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ChainOfResponsibility.repositories
{
    internal class ReceiptRepository(PizzeriaContext context)
    {
        private readonly PizzeriaContext _context = context;

        public async Task<IReadOnlyList<Receipt>> GetAllAsync()
            => await _context.Receipts.Include(r => r.Order).ToListAsync();

        public async Task<bool> InsertAsync(Receipt receipt)
        {
            try
            {
                await _context.Receipts.AddAsync(receipt);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
