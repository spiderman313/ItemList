using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemList.Domain.Interfaces;

namespace ItemList.Domain.Models {
    public class ItemUpdateModel : IItemIdentity, ICategoryContainer {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
