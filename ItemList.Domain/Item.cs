using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemList.Domain.Interfaces;

namespace ItemList.Domain {
    public class Item : ICategoryContainer {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int AmmountLeft { get; set; }
        public decimal Cost { get; set; }
        int? ICategoryContainer.CategoryId => this.Category.Id;
    }
}
