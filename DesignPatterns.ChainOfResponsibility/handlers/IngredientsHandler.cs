using DesignPatterns.ChainOfResponsibility.enums;
using DesignPatterns.ChainOfResponsibility.exceptions;
using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.handlers
{
    internal class IngredientsHandler : Handler
    {
        public override void CalculateCost(Order order, Receipt receipt, List<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                if(ingredient?.Name == nameof(IngredientEnum.Pineapple))
                {
                    receipt.Cost = 0;
                    break;
                }
                receipt.Cost += ingredient?.Name switch
                {
                    nameof(IngredientEnum.CookedProsciutto) => 1,
                    nameof(IngredientEnum.Mushrooms) => 2,
                    nameof(IngredientEnum.Prosciutto) => 2,
                    _ => throw new WrongInputException(Enum.Parse<IngredientEnum>(ingredient?.Name!))
                };
            }
            base.CalculateCost(order, receipt, ingredients);
        }
    }
}
