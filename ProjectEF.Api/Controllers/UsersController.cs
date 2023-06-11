using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectEF.Api.MapperHelper;
using ProjectEF.BL.Service;
using ProjectEF.BL.Service.IService;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;
using System.Text.Json;

namespace ProjectEF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _srv;
        JsonSerializerOptions Options;

        public UsersController(IUserServices srv)
        {
            this._srv = srv;
            Options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        [HttpGet]
        public async Task<ActionResult<UserSrvResponse>> Login([FromBody]UserDTO userCridentialsJSON)
        {
            //var user = System.Text.Json.JsonSerializer.Deserialize<sfwf>(userCridentialsJSON);
            //var us = new UserDTO() { UserName = user.username, Password = user.password };
            return await _srv.IsValidUser(userCridentialsJSON);
        }
    }
    public class sfwf
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
