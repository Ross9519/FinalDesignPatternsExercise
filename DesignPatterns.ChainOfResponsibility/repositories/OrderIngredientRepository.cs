using DesignPatterns.ChainOfResponsibility.contexts;
using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.repositories
{
    internal class OrderIngredientRepository(PizzeriaContext context)
    {
        private readonly PizzeriaContext _context = context;

        public async Task<bool> InsertAsync((Order order, List<Ingredient> ingredients) pair)
        {
            try
            {
                var orderIngredients = pair.ingredients.Select(i => new OrderIngredient
                {
                    OrderId = pair.order.Id,
                    IngredientId = i.Id
                }).ToList();

                await _context.OrderIngredients.AddRangeAsync(orderIngredients);
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
