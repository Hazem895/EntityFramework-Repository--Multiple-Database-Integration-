using ProjectEF.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Domain.IRepository
{
    public interface IItemsCommand : ICrudCommands<Item>
    {
        IEnumerable<Item> GetItemsByCategoryId(Guid CategoryId);
    }
}
