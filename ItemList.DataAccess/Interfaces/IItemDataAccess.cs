using System.Threading.Tasks;
using ItemList.Domain;
using ItemList.Domain.Interfaces;
using ItemList.Domain.Models;
using System.Collections.Generic;


namespace ItemList.DataAccess.Interfaces {
    public interface IItemDataAccess {
        Task<Item> InsertAsync(ItemUpdateModel item);
        Task<IEnumerable<Item>> GetAsync();
        Task<Item> GetAsync(IItemIdentity itemId);
        Task<Item> UpdateAsync(ItemUpdateModel item);
    }
}
