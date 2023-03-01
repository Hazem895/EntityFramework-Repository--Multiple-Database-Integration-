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
    public class CategoryCrudCommands : ICrudCommands<Category>
    {
        private readonly ApplicationDbContext_SQL _context;

        public CategoryCrudCommands(ApplicationDbContext_SQL context) { _context = context; }
        public string Delete(Guid ID)
        {
            Category? record = ReadById(ID);
            if (record != null)
            {
                _context.Categories.Remove(record);
                _context.SaveChanges();
                return $"{ID} deleted Successfully";
            }
            else
            {
                return "Not Exists";

            }
        }

        public IEnumerable<Category> ReadAll()
        {
            return _context.Categories.AsEnumerable();
        }

        public Category? ReadById(Guid ID)
        {
            return _context.Categories.SingleOrDefault(x => x.CategoryId == ID);
        }

        public string Create(Category Input)
        {
            if (ReadById(Input.CategoryId) != null)
            {
                return "Already Exists";
            }
            else
            {
                _context.Categories.Add(Input);
                _context.SaveChanges();
                return $"{Input.CategoryId} Added Successfully";
            }
        }

        public string Update(Category Input/*, Guid ID*/)
        {
            Category? record = ReadById(Input.CategoryId);
            Detached(record);

            _context.Entry(record).State = EntityState.Detached;
            if (record != null)
            {
                _context.Categories.Update(Input);
                _context.SaveChanges();
                return $"{Input.CategoryId} Updated Successfully";
            }
            return "Not Exists";
        }

        private void Detached(Category? category)
        {
            if (category != null) _context.Entry(category).State = EntityState.Detached;
        }

    }

}
