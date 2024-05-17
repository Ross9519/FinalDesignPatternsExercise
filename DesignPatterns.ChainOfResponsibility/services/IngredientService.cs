using DesignPatterns.ChainOfResponsibility.models;
using DesignPatterns.ChainOfResponsibility.repositories;

namespace DesignPatterns.ChainOfResponsibility.services
{
    internal class IngredientService(IngredientRepository repo)
    {
        private readonly IngredientRepository _repo = repo;

        public async Task<Ingredient?> FindByName(string name)
        {
            var ingredients = await _repo.GetAllAsync();
            return ingredients.Where(i => i.Name.Equals(name)).SingleOrDefault();
        }
    }
}
