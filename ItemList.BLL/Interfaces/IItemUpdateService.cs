using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemList.Domain;
using ItemList.Domain.Models;

namespace ItemList.BLL.Interfaces {
    public interface IItemUpdateService
    {
        Task<Item> UpdateAsync(ItemUpdateModel item);
    }
}
