using DesignPatterns.ChainOfResponsibility.enums;
using DesignPatterns.ChainOfResponsibility.exceptions;
using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.handlers
{
    internal class BaseHandler : Handler
    {
        public override void CalculateCost(Order order, Receipt receipt, List<Ingredient> ingredients)
        {
            receipt.Cost += order.Base switch
            {
                nameof(BasePizzaEnum.White) => 5,
                nameof(BasePizzaEnum.Margherita) => 7,
                nameof(BasePizzaEnum.Neapolitan) => 3,
                _ => throw new WrongInputException(Enum.Parse<BasePizzaEnum>(order.Base!)),
            };
            base.CalculateCost(order, receipt, ingredients);
        }
    }
}
