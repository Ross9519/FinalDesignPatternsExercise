using DesignPatterns.ChainOfResponsibility.models;
using DesignPatterns.ChainOfResponsibility.repositories;

namespace DesignPatterns.ChainOfResponsibility.services
{
    internal class ReceiptService(ReceiptRepository repo)
    {
        private readonly ReceiptRepository _repo = repo;

        public async Task<IReadOnlyList<Receipt>> FindAllAsync()
            => await _repo.GetAllAsync();

        public async Task<bool> SaveOneAsync(Receipt receipt)
            => await _repo.InsertAsync(receipt);
    }
}
