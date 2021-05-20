using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemList.Domain {
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
    }
}
