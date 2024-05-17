using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.handlers
{
    internal abstract class Handler
    {
        protected Handler? _next;

        public Handler SetNext(Handler next)
        {
            _next = next;
            return _next;
        }

        public virtual void CalculateCost(Order order, Receipt receipt, List<Ingredient> ingredients)
        {
            _next?.CalculateCost(order, receipt, ingredients);
        }
    }
}
