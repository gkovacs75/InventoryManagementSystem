using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases
{
	public class AddInventoryUseCase : IAddInventoryUseCase
	{
		private readonly IInventoryRepository inventoryRepository;

		public AddInventoryUseCase(IInventoryRepository InventoryRepository)
		{
			this.inventoryRepository = InventoryRepository;
		}

		public async Task ExecuteAsync(Inventory inventory)
		{
			await inventoryRepository.AddInventoryAsync(inventory);
		}
	}
}
