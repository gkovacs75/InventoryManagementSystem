using IMS.CoreBusiness;

namespace IMS.UseCases
{
	public interface ISearchProductTransactionsUseCase
	{
		Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType);
	}
}