using AutoMapper;
using ItemList.Client.DTO.Read;
using ItemList.Client.Requests.Create;
using ItemList.Client.Requests.Update;
using ItemList.Domain.Models;

namespace ItemList.WebAPI {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            this.CreateMap<DataAccess.Entities.Item, Domain.Item>();
            this.CreateMap<DataAccess.Entities.Category, Domain.Category>();
            this.CreateMap<Domain.Item, ItemDTO>();
            this.CreateMap<Domain.Category, CategoryDTO>();
            this.CreateMap<ItemCreateDTO, ItemUpdateModel>();
            this.CreateMap<ItemUpdateDTO, ItemUpdateModel>();
            this.CreateMap<ItemUpdateModel, DataAccess.Entities.Item>();
        }
    }
}
