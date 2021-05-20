using System;
using System.Collections.Generic;
using System.Text;

namespace ItemList.Client.DTO.Read {
    public class ItemDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDTO Category { get; set; }
        public int AmmountLeft { get; set; }
        public decimal Cost { get; set; }
    }
}
