using System.Collections.Generic;
using System.Threading.Tasks;
using ItemList.DataAccess.Interfaces;
using ItemList.BLL.Interfaces;
using ItemList.Domain;
using ItemList.Domain.Interfaces;

namespace ItemList.BLL.Implementation {
    public class ItemGetService : IItemGetService {
        private IItemDataAccess ItemDataAccess { get; }

        public ItemGetService(IItemDataAccess itemDataAccess) {
            this.ItemDataAccess = itemDataAccess;
        }

        public Task<IEnumerable<Item>> GetAsync() {
            return this.ItemDataAccess.GetAsync();
        }

        public Task<Item> GetAsync(IItemIdentity item) {
            return this.ItemDataAccess.GetAsync(item);
        }
    }
}
