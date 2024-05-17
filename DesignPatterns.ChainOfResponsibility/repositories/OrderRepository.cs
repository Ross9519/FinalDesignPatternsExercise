using DesignPatterns.ChainOfResponsibility.contexts;
using DesignPatterns.ChainOfResponsibility.models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ChainOfResponsibility.repositories
{
    internal class OrderRepository(PizzeriaContext context)
    {
        private readonly PizzeriaContext _context = context;

        public async Task<IReadOnlyList<Order>> GetAllAsync()
            => await _context.Orders.Include(o => o.Receipt).Include(o => o.OrderIngredients.Select(oi => oi.Ingredient)).ToListAsync();

        public async Task<bool> InsertAsync(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async Task<bool> UpdateAsync(Order order)
        {
            try
            {
                _context.Update(order);
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
