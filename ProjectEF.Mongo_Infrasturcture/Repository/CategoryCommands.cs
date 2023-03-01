using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjectEF.Domain.IRepository;
using ProjectEF.Domain.DomainModels;

namespace ProjectEF.Mongo_Infrasturcture.Repository
{
    public class CategoryCommands : ICrudCommands<Category>
    {
        private readonly MongoDbContext _context;

        public CategoryCommands(MongoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string Delete(Guid ID)
        {
            _context.Categories.DeleteOne(x => x.CategoryId == ID);
            return $"{ID} Deleted";
        }

        public IEnumerable<Category> ReadAll()
        {
            return _context.Categories.Find(_ => true).ToEnumerable();
        }

        public Category? ReadById(Guid ID)
        {
            return _context.Categories.Find(x => x.CategoryId == ID).SingleOrDefault();
        }
        public string Create(Category Input)
        {
            var id = ReadAll().Count() + 1;
            _context.Categories.InsertOne(Input);
            return $"{Input.CategoryId} Added";
        }

        public string Update(Category Input/*, Guid ID*/)
        {
            var recToUpdate = ReadById(Input.CategoryId);
            if (recToUpdate != null)
            {
                _context.Categories.ReplaceOne(d => d.CategoryId == Input.CategoryId, recToUpdate);
                return $"{Input.CategoryId} Updated";
            }
            return "Not Exists";

        }
    }
}
