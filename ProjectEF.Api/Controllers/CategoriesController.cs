using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEF.Domain;
//sing ProjectEF.SQL_Infrastructure.Repository.IRepository;

namespace ProjectEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICommands<Category> _com;
        //private readonly IUnitOfWork<> _Uni;

        public CategoriesController(ICommands<Category> U /*IUnitOfWork uni*/)
        {
            this._com = U;
            //this._Uni = uni;
        }

        [HttpPost("Save")]
        public string SaveRequest(Category cc)
        {
            return _com.Save(cc);
            // _Uni.Save();
        }


        [HttpPut("Update/{Id}")]
        public string UpdateRequest(Category cc, Guid Id)
        {
           return _com.Update(cc, Id);
            //_Uni.Save();

        }


        [HttpDelete("Delete/{Id}")]
        public string DeleteRequest(Guid Id)
        {
            return _com.Delete(Id);
            // _Uni.Save();
        }


        [HttpGet("Select/{Id?}")]
        public IEnumerable<Category> SelectRequest(Guid? Id = null)
        {
            return _com.Read(Id);

        }
    }
}
