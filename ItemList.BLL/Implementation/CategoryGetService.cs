using System;
using System.Threading.Tasks;
using ItemList.DataAccess.Interfaces;
using ItemList.BLL.Interfaces;
using ItemList.Domain;
using ItemList.Domain.Interfaces;

namespace ItemList.BLL.Implementation {
    public class CategoryGetService : ICategoryGetService {
        private ICategoryDataAccess CategoryDataAccess { get; }

        public CategoryGetService(ICategoryDataAccess categoryDataAccess) {
            this.CategoryDataAccess = categoryDataAccess;
        }

        public async Task ValidateAsync(ICategoryContainer categoryContainer) {
            if (categoryContainer == null) {
                throw new ArgumentNullException(nameof(categoryContainer));
            }

            var category = await this.GetBy(categoryContainer);

            if (categoryContainer.CategoryId.HasValue && category == null) {
                throw new InvalidOperationException($"Category not found by id {categoryContainer.CategoryId}");
            }
        }

        private async Task<Category> GetBy(ICategoryContainer categoryContainer) {
            return await this.CategoryDataAccess.GetByAsync(categoryContainer);
        }
    }
}
