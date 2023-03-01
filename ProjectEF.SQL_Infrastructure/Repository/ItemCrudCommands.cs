using Microsoft.EntityFrameworkCore;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.ProjectEF.SQL_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.SQL_Infrastructure.Repository
{
    public class ItemCrudCommands : IItemsCommand
    {
        private readonly ApplicationDbContext_SQL _context;

        public ItemCrudCommands(ApplicationDbContext_SQL context) { _context = context; }

        public string Delete(Guid ID)
        {
            Item? record = ReadById(ID);
            if (record != null)
            {
                _context.Items.Remove(record);
                _context.SaveChanges();
                return $"{ID} deleted Successfully";
            }
            else
            {
                return "Not Exists";

            }
        }

        public IEnumerable<Item> ReadAll()
        {
            return _context.Items.AsEnumerable();
        }

        public Item? ReadById(Guid ID)
        {
            return _context.Items.SingleOrDefault(x => x.ItemId == ID);
        }

        public string Create(Item Input)
        {
            if (ReadById(Input.ItemId) != null)
            {
                return "Already Exists";
            }
            else
            {
                _context.Items.Add(Input);
                _context.SaveChanges();
                return $"{Input.ItemId} Added Successfully";
            }
        }

        public string Update(Item Input/*, Guid ID*/)
        {
            Item? record = ReadById(Input.ItemId);
            Detached(record);

            _context?.Entry(record).State = EntityState.Detached;
            if (record != null)
            {
                _context.Items.Update(Input);
                _context.SaveChanges();
                return $"{Input.ItemId} Updated Successfully";
            }
            return "Not Exists";
        }

        private void Detached(Item? Item)
        {
            if (Item != null) _context.Entry(Item).State = EntityState.Detached;
        }

        public IEnumerable<Item> GetItemsByCategoryId(Guid CategoryId)
        {
            return _context.Items.Where(x=>x.CategoryId==CategoryId).AsEnumerable();
        }
    }
}
