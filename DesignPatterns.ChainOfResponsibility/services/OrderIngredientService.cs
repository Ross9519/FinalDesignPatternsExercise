using DesignPatterns.ChainOfResponsibility.models;
using DesignPatterns.ChainOfResponsibility.repositories;

namespace DesignPatterns.ChainOfResponsibility.services
{
    internal class OrderIngredientService(OrderIngredientRepository repo)
    {
        private readonly OrderIngredientRepository _repo = repo;

        public async Task<bool> InsertIngredientsForOrder((Order order, List<Ingredient> ingredients) pair)
            => await _repo.InsertAsync(pair);
    }
}
