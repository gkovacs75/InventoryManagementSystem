using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductTransactionRepository productTransactionRepository;
        private readonly IProductRepository productRepository;

        public SellProductUseCase(IProductTransactionRepository productTransactionRepository, IProductRepository productRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy)
        {
            await productTransactionRepository.SellProductAsync(salesOrderNumber, product, quantity, product.Price, doneBy);

            product.Quantity -= quantity;

            await productRepository.UpdateProductAsync(product);
        }
    }
}
