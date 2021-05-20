using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemList.Domain.Interfaces;

namespace ItemList.Domain.Models {
    public class ItemIdentityModel : IItemIdentity {
        public int Id { get;  }

        public ItemIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
