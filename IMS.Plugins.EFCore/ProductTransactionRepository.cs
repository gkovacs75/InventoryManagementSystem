using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly IMSContext db;
        private readonly IProductRepository productRepository;

        public ProductTransactionRepository(IMSContext db, IProductRepository productRepository)
        {
            this.db = db;
            this.productRepository = productRepository;
        }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy)
        {
            var prod = await this.productRepository.GetProductByIdAsync(product.ProductId);

            if (prod != null)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    int qtyBefore = pi.Inventory.Quantity;

                    pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;

                    this.db.InventoryTransactions.Add(new InventoryTransaction
                    {
                        ProductionNumber = productionNumber,
                        InventoryId = pi.Inventory.InventoryId,
                        QuantityBefore = qtyBefore,
                        ActivityType = InventoryTransactionType.ProduceProduct,
                        QuantityAfter = pi.Inventory.Quantity,
                        TransactionDate = DateTime.Now,
                        DoneBy = doneBy,
                        UnitPrice = price
                    });
                }
            }

            this.db.ProductTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            await this.db.SaveChangesAsync();

        }

        public async Task SellProduceAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy)
        {
            this.db.ProductTransactions.Add(new ProductTransaction
            {
                SalesOrderNumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity - quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            await this.db.SaveChangesAsync();
        }
    }
}
