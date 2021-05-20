using System.Threading.Tasks;
using ItemList.Domain;
using ItemList.Domain.Interfaces;

namespace ItemList.DataAccess.Interfaces {
    public interface ICategoryDataAccess {
        Task<Category> GetByAsync(ICategoryContainer categoryId);
    }
}
