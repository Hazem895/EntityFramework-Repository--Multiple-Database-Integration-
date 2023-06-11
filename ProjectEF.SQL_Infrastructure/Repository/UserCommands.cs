using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectEF.ProjectEF.SQL_Infrastructure;
using System.Runtime.CompilerServices;
using ProjectEF.Domain.IRepository;
using ProjectEF.Domain.DomainModels;

namespace ProjectEF.SQL_Infrastructure.Repository
{
    public class UserCommands : IUserCommands
    {
        private readonly ApplicationDbContext_SQL _context;

        public UserCommands(ApplicationDbContext_SQL context) { _context = context; }
        public async Task<bool> IsUserAdmin(Guid userId)
        {
            var result = await _context.Users.SingleOrDefaultAsync(x => x.ID == userId);
            return result.IsAdmin;
        }

        public async Task<User?> GetUserByCridentials(string userName, string password)
        {
            var result = await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return result;
        }
        public async Task<bool> IsUserExist(string userName)
        {
            var result = await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName);
            return result!=null;
        }

    }

}
