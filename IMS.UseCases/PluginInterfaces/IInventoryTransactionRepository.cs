﻿using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(string poNumber, Inventory Inventory, int quantity, double price, string doneBy);

        Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(string inventoryName, DateTime? dateForm, DateTime? dateTo, InventoryTransactionType? transactionType);
    }
}
