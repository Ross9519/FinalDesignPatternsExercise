using DesignPatterns.ChainOfResponsibility.models;
using DesignPatterns.ChainOfResponsibility.services;

namespace DesignPatterns.ChainOfResponsibility.datamanagers
{
    internal class DbManager(ReceiptService receiptService, OrderService orderService, OrderIngredientService orderIngredientService)
    {
        private readonly ReceiptService _receiptService = receiptService;
        private readonly OrderService _orderService = orderService;
        private readonly OrderIngredientService _orderIngredientService = orderIngredientService;

        public async Task<bool> SaveOrderAndReceiptAsync((Order order, List<Ingredient> ingredients) pair, Receipt receipt)
        {
            try
            {
                await _orderService.SaveOneAsync(pair.order);
                await _orderIngredientService.InsertIngredientsForOrder(pair);
                receipt.OrderId = pair.order.Id;
                await _receiptService.SaveOneAsync(receipt);
                pair.order.ReceiptId = receipt.Id;
                await _orderService.UpdateAsync(pair.order);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SaveAllOrdersAndReceiptsAsync(IEnumerable<(Order order, List<Ingredient> ingredients)> pairs, IEnumerable<Receipt> receipts)
        {
            try
            {
                foreach(var (pair, receipt) in pairs.Zip(receipts, (p, r) => (p, r)))
                    await SaveOrderAndReceiptAsync(pair, receipt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IReadOnlyList<Order>> GetOrdersAsync()
            => await _orderService.FindAllAsync();

        public async Task<IReadOnlyList<Receipt>> GetReceiptsAsync()
            => await _receiptService.FindAllAsync();
    }
}
