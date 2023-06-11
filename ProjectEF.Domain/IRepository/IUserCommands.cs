using ProjectEF.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Domain.IRepository
{
    public interface IUserCommands
    {
        Task<bool> IsUserExist(string userName);
        Task<bool> IsUserAdmin(Guid userId);
        Task<User?> GetUserByCridentials(string userName, string password);
    }
}
