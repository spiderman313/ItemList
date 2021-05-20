using System;
using System.Threading.Tasks;
using ItemList.DataAccess.Interfaces;
using ItemList.BLL.Interfaces;
using ItemList.Domain;
using ItemList.Domain.Models;

namespace ItemList.BLL.Implementation {
    public class ItemCreateService : IItemCreateService {
        private IItemDataAccess ItemDataAccess { get; }
        private ICategoryGetService CategoryGetService { get; }

        public ItemCreateService(IItemDataAccess itemDataAccess, ICategoryGetService categoryGetService) {
            this.ItemDataAccess = itemDataAccess;
            this.CategoryGetService = categoryGetService;
        }

        public async Task<Item> CreateAsync(ItemUpdateModel item) {
            await this.CategoryGetService.ValidateAsync(item);

            return await this.ItemDataAccess.InsertAsync(item);
        }
    }
}
