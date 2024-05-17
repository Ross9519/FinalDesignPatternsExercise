using DesignPatterns.ChainOfResponsibility.models;
using DesignPatterns.ChainOfResponsibility.repositories;

namespace DesignPatterns.ChainOfResponsibility.services
{
    internal class OrderService(OrderRepository repo)
    {
        private readonly OrderRepository _repo = repo;

        public async Task<IReadOnlyList<Order>> FindAllAsync()
            => await _repo.GetAllAsync();

        public async Task<bool> SaveOneAsync(Order order)
            => await _repo.InsertAsync(order);

        public async Task<bool> UpdateAsync(Order order)
            => await _repo.UpdateAsync(order);
    }
}
