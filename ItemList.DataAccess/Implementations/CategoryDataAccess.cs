using System.Threading.Tasks;
using AutoMapper;
using ItemList.DataAccess.Context;
using ItemList.DataAccess.Interfaces;
using ItemList.Domain;
using ItemList.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItemList.DataAccess.Implementations {
    public class CategoryDataAccess : ICategoryDataAccess {
        private ItemDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public CategoryDataAccess(ItemDirectoryContext context, IMapper mapper) {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Category> GetByAsync(ICategoryContainer category) {
            return category.CategoryId.HasValue
                ? this.Mapper.Map<Category>(await this.Context.Category.FirstOrDefaultAsync(x => x.Id == category.CategoryId))
                : null;
        }
    }
}
