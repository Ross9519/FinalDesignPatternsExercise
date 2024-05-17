using DesignPatterns.ChainOfResponsibility.models;

namespace DesignPatterns.ChainOfResponsibility.handlers
{
    internal static class ClientHandler
    {
        public static Handler BuildHandler()
        {
            var baseHandler = new BaseHandler();
            var doughHandler = new DoughHandler();
            var ingredientsHandler = new IngredientsHandler();

            baseHandler
                .SetNext(doughHandler)
                .SetNext(ingredientsHandler);

            return baseHandler;
        }

        public static List<Receipt> ControlChain(List<(Order order, List<Ingredient> ingredients)> pairs)
        {
            List<Receipt> receipts = [];

            foreach (var (order, ingredients) in pairs)
            {
                var chainHandler = BuildHandler();
                var receipt = new Receipt();
                chainHandler.CalculateCost(order, receipt, ingredients);
                receipts.Add(receipt);
            }
            return receipts;
        }
    }
}
