using DesignPatterns.ChainOfResponsibility.enums;
using DesignPatterns.ChainOfResponsibility.exceptions;
using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.handlers
{
    internal class DoughHandler : Handler
    {
        public override void CalculateCost(Order order, Receipt receipt, List<Ingredient> ingredients)
        {
            receipt.Cost += order.Dough switch
            {
                nameof(DoughEnum.Normal) => 0,
                nameof(DoughEnum.Integral) => 1,
                _ => throw new WrongInputException(Enum.Parse<DoughEnum>(order.Dough!))
            };
            base.CalculateCost(order, receipt, ingredients);
        }
    }
}
