using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemList.Domain;
using ItemList.Domain.Interfaces;

namespace ItemList.BLL.Interfaces {
    public interface ICategoryGetService
    {
        Task ValidateAsync(ICategoryContainer categoryContainer);
    }
}
