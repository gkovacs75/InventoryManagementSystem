using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases
{
    public class SearchInventoryTransactionsUseCase : ISearchInventoryTransactionsUseCase
    {
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;

        public SearchInventoryTransactionsUseCase(IInventoryTransactionRepository inventoryTransactionRepository)
        {
            this.inventoryTransactionRepository = inventoryTransactionRepository;
        }

        public async Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime dateForm, DateTime dateTo, InventoryTransactionType transactionType)
        {
            return await this.inventoryTransactionRepository.GetInventoryTransactionsAsync(inventoryName, dateForm, dateTo, transactionType);
        }
    }
}
