using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ItemList.DataAccess.Context;
using ItemList.DataAccess.Interfaces;
using ItemList.DataAccess.Entities;
using ItemList.Domain.Interfaces;
using ItemList.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Category = ItemList.Domain.Category;

namespace ItemList.DataAccess.Implementations {
    public class ItemDataAccess : IItemDataAccess {
        private ItemDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public ItemDataAccess(ItemDirectoryContext context, IMapper mapper) {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<ItemList.Domain.Item> InsertAsync(ItemUpdateModel item) {
            var result = await this.Context.AddAsync(this.Mapper.Map<Item>(item));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<ItemList.Domain.Item>(result.Entity);
        }

        public async Task<IEnumerable<ItemList.Domain.Item>> GetAsync() {
            return this.Mapper.Map<IEnumerable<ItemList.Domain.Item>>(
                await this.Context.Item.Include(x => x.Category).ToListAsync());
        }

        public async Task<ItemList.Domain.Item> GetAsync(IItemIdentity item) {
            var result = await this.Get(item);

            return this.Mapper.Map<ItemList.Domain.Item>(result);
        }

        private async Task<Item> Get(IItemIdentity item) {
            if (item == null) {
                throw new ArgumentNullException(nameof(item));
            }

            return await this.Context.Item.Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == item.Id);
        }

        public async Task<ItemList.Domain.Item> UpdateAsync(ItemUpdateModel item) {
            var existing = await this.Get(item);

            var result = this.Mapper.Map(item, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<ItemList.Domain.Item>(result);
        }
    }
}
