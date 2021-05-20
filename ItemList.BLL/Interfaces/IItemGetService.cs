using ItemList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemList.Domain.Interfaces;

namespace ItemList.BLL.Interfaces {
    public interface IItemGetService
    {
        Task<IEnumerable<Item>> GetAsync();
        Task<Item> GetAsync(IItemIdentity item);
    }
}
