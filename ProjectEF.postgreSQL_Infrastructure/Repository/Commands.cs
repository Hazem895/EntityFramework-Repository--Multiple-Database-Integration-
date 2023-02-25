using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectEF.Domain;
//using ProjectEF.Models;
//using ProjectEF.ProjectEF.postgreSQL_Infrastructure;

namespace ProjectEF.postgreSQL_Infrastructure.Repository
{
    public class CategoryCommands : ICommands<Category>
    {
        private readonly ApplicationDbContext_PG _context;
        //private static string connectionString;

        public CategoryCommands(ApplicationDbContext_PG context)
        {

            _context = context;

            // connectionString = _context.Database.GetDbConnection().ConnectionString;
        }
        public string Delete(Guid ID)
        {
            Category? record = Read(ID).FirstOrDefault();
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

        public IEnumerable<Category> Read(Guid? ID)
        {
            if (!ID.HasValue) return _context.Categories.AsEnumerable();
            else return _context.Categories.Where(x => x.CategoriesId == ID);
        }

        public string Save(Category Input)
        {
            if (Read(Input.CategoriesId).Any())
            {
                return "Already Exists";
            }
            else
            {
                _context.Categories.Add(Input);
                _context.SaveChanges();
                return $"{Input.CategoriesId} Added Successfully";
            }
        }

        public string Update(Category Input, Guid ID)
        {
            Category? record = (Read(ID).FirstOrDefault());
            if (record != null)
            {
                record.Name = Input.Name;
                _context.Categories.Update(record);
                _context.SaveChanges();
                return $"{ID} Updated Successfully";
            }
            else
            {
                return "Not Exists";

            }
        }

    }
}
