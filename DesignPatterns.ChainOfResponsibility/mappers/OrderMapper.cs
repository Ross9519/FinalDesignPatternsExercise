using DesignPatterns.ChainOfResponsibility.enums;
using DesignPatterns.ChainOfResponsibility.models;
using DesignPatterns.ChainOfResponsibility.seeds;

namespace DesignPatterns.ChainOfResponsibility.mappers
{
    internal static class OrderMapper
    {

        public static (Order, List<Ingredient>) StringToOrder(string str)
        {
            var splitted = str.Split(";");
            var ingredients = splitted[2].Split(",");
            List<Ingredient> ingredientList = ingredients.Select(i => typeof(IngredientSeeder).GetField(i)?.GetValue(null) as Ingredient).ToList()!;
            Order order = new()
            {
                Base = splitted[0],
                Dough = splitted[1],
            };
            return (order,ingredientList);
        }
    }
}
