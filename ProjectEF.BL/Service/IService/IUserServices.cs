using ProjectEF.Shared.DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.BL.Service.IService
{
    public interface IUserServices
    {
        Task<UserSrvResponse> IsValidUser(UserDTO user);
        Task<bool> IsUserAdmin(Guid id);
    }
}
