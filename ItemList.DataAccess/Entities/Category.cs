using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemList.DataAccess.Entities {
    public partial class Category {
        public Category() {
            this.Item = new HashSet<Item>();
            this.InverseParent = new HashSet<Category>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
    }
}
