using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEF.Api.MapperHelper;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;

namespace ProjectEF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICrudCommands<Category> _com;

        public CategoriesController(ICrudCommands<Category> U)
        {
            this._com = U;
        }

        [HttpPost]
        public string SaveRequest(CreateCategory cc)
        {
            return _com.Create(cc.CreateMapper());
        }


        [HttpPut("{Id}")]
        public string UpdateRequest(UpdateCategory cc, Guid Id)
        {
            return _com.Update(cc.UpdateMapper(Id));

        }


        [HttpDelete("{Id:Guid}")]
        public string DeleteRequest(Guid Id)
        {
            return _com.Delete(Id);
        }

        [HttpGet]
        public IEnumerable<CategoryDto> SelectRequest()
        {
            return _com.ReadAll().ToDto();
        }
        [HttpGet("{Id:Guid}")]
        public CategoryDto? SelectByIdRequest(Guid Id )
        {
            return _com.ReadById(Id).ToDto();
        }

    }
}
