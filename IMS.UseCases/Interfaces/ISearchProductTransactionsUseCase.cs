using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
	public interface ISearchProductTransactionsUseCase
	{
		Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType);
	}
}