using DesignPatterns.ChainOfResponsibility.enums;
using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.seeds
{
    internal static class IngredientSeeder
    {
        public static Ingredient CookedProsciutto = new()
        {
            Id = 1,
            Name = nameof(IngredientEnum.CookedProsciutto)
        };

        public static Ingredient Mushrooms = new()
        {
            Id = 2,
            Name = nameof(IngredientEnum.Mushrooms)
        };

        public static Ingredient Prosciutto = new()
        {
            Id = 3,
            Name = nameof(IngredientEnum.Prosciutto)
        };

        public static Ingredient Pineapple = new()
        {
            Id = 4,
            Name = nameof(IngredientEnum.Pineapple)
        };

        public static List<Ingredient> Ingredients =
        [
            CookedProsciutto,
            Mushrooms,
            Prosciutto,
            Pineapple
        ];
    }
}
