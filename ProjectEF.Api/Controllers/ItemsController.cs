using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEF.Api.MapperHelper;
using ProjectEF.Api.Services.CategoriesServices;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;

namespace ProjectEF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsCommand _com;
        private readonly ICategoriesServices _srv;

        public ItemsController(IItemsCommand com, ICategoriesServices srv)
        {
            this._com = com;
            this._srv = srv;
        }

        [HttpPost]
        public async Task<string> SaveRequest(CreateItem cc)
        {
            bool IsCat = await _srv.IsCategoryAvilable(cc.CategoryId);
            if (IsCat) return _com.Create(cc.CreateMapper());
            return "Invalid Category";
        }


        [HttpPut("{Id}")]
        public async Task<string> UpdateRequest(UpdateItem cc, Guid Id)
        {
            bool IsCat = await _srv.IsCategoryAvilable(cc.CategoryId);
            if (IsCat) return _com.Update(cc.UpdateMapper(Id));
            return "Invalid Category";

        }


        [HttpDelete("{Id:Guid}")]
        public string DeleteRequest(Guid Id)
        {
            return _com.Delete(Id);
        }

        [HttpGet]
        public IEnumerable<ItemDto> SelectRequest()
        {
            return _com.ReadAll().ToDto();
        }
        [HttpGet("{Id:Guid}")]
        public ItemDto? SelectByIdRequest(Guid Id)
        {
            return _com.ReadById(Id).ToDto();
        }

        [HttpGet("Categorized/{Id:Guid}")]
        public IEnumerable<ItemDto> SelectByCategoryIdRequest(Guid Id)
        {
            return _com.GetItemsByCategoryId(Id).ToDto();
        }
    }
}
