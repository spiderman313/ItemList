using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ItemList.BLL.Interfaces;
using ItemList.Client.DTO;
using ItemList.Client.DTO.Read;
using ItemList.Client.Requests.Create;
using ItemList.Client.Requests.Update;
using ItemList.Domain;
using ItemList.Domain.Interfaces;
using ItemList.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ItemList.WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase {
        private ILogger<ItemController> Logger { get; }
        private IItemCreateService ItemCreateService { get; }
        private IItemGetService ItemGetService { get; }
        private IItemUpdateService ItemUpdateService { get; }
        private IMapper Mapper { get; }

        public ItemController(ILogger<ItemController> logger
                            , IMapper mapper
                            , IItemCreateService itemCreateService
                            , IItemGetService itemGetService
                            , IItemUpdateService itemUpdateService) {
            this.Logger = logger;
            this.ItemCreateService = itemCreateService;
            this.ItemGetService = itemGetService;
            this.ItemUpdateService = itemUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ItemDTO> PutAsync(ItemCreateDTO item) {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ItemCreateService.CreateAsync(this.Mapper.Map<ItemUpdateModel>(item));

            return this.Mapper.Map<ItemDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ItemDTO> PatchAsync(ItemUpdateDTO item) {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ItemUpdateService.UpdateAsync(this.Mapper.Map<ItemUpdateModel>(item));

            return this.Mapper.Map<ItemDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ItemDTO>> GetAsync() {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<ItemDTO>>(await this.ItemGetService.GetAsync());
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<ItemDTO> GetAsync(int itemId) {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {itemId}");

            return this.Mapper.Map<ItemDTO>(await this.ItemGetService.GetAsync(new ItemIdentityModel(itemId)));
        }
    }
}
