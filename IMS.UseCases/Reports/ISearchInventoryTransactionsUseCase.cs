using IMS.CoreBusiness;

namespace IMS.UseCases.Reports
{
    public interface ISearchInventoryTransactionsUseCase
    {
        Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime dateForm, DateTime dateTo, InventoryTransactionType transactionType);
    }
}