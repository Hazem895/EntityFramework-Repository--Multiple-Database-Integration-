using ProjectEF.BL.MapperHelper;
using ProjectEF.BL.Service.IService;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.Shared.DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.BL.Service
{
    public class UserServices : IUserServices
    {
        private readonly IUserCommands _com;
        public UserServices(IUserCommands com)
        {
            _com = com;
        }

        public async Task<UserSrvResponse?> IsValidUser(UserDTO user)
        {
            try
            {
                var isUserExist = await _com.IsUserExist(user.UserName);
                if (!isUserExist)
                {
                    return new()
                    {
                        IsValid = false,
                        ResponseMessage = "User doesn't exist",
                        HttpStatusCode = HttpStatusCode.NotFound
                    };
                }
                var result = (await _com.GetUserByCridentials(user.UserName, user.Password)).ToDto();
                if (result == null || result == default)
                {
                    return new()
                    {
                        IsValid = false,
                        ResponseMessage = "Douple check your password",
                        HttpStatusCode = HttpStatusCode.Unauthorized
                    };
                }
                return new() { IsValid = true, HttpStatusCode = HttpStatusCode.OK }; ;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> IsUserAdmin(Guid id)
        {
            var result = await _com.IsUserAdmin(id);
            return result;
        }
    }
    public class UserSrvResponse
    {
        public bool IsValid { get; set; }
        public string ResponseMessage { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
