using DesignPatterns.ChainOfResponsibility.contexts;
using DesignPatterns.ChainOfResponsibility.models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ChainOfResponsibility.repositories
{
    internal class IngredientRepository(PizzeriaContext context)
    {
        private readonly PizzeriaContext _context = context;

        public async Task<IReadOnlyList<Ingredient>> GetAllAsync()
            => await _context.Ingredients.ToListAsync();
    }
}
