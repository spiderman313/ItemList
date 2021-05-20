using System;
using System.Threading.Tasks;
using ItemList.DataAccess.Interfaces;
using ItemList.BLL.Interfaces;
using ItemList.Domain;
using ItemList.Domain.Interfaces;
using ItemList.Domain.Models;

namespace ItemList.BLL.Implementation {
    public class ItemUpdateService : IItemUpdateService {
        private IItemDataAccess ItemDataAccess { get; }
        private ICategoryGetService CategoryGetService { get; }

        public ItemUpdateService(IItemDataAccess itemDataAccess, ICategoryGetService categoryGetService) {
            this.ItemDataAccess = itemDataAccess;
            this.CategoryGetService = categoryGetService;
        }

        public async Task<Item> UpdateAsync(ItemUpdateModel item) {
            await this.CategoryGetService.ValidateAsync(item);

            return await this.ItemDataAccess.UpdateAsync(item);
        }
    }
}
