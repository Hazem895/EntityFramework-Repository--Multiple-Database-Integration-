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
using ProjectEF.Domain;

namespace ProjectEF.Mongo_Infrasturcture.Repository
{
    public class CategoryCommands : ICommands<Category>
    {
        private readonly MongoDbContext _context;

        public CategoryCommands(MongoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string Delete(Guid ID)
        {
            _context.Categories.DeleteOne(x=>x.CategoriesId==ID);
            return $"{ID} Deleted";
        }

        public IEnumerable<Category> Read(Guid? ID)
        {
            return _context.Categories.Find(_ => true).ToEnumerable() ;
        }

        private Category FindById(Guid ID)
        {
          return _context.Categories.Find(x=>x.CategoriesId== ID).SingleOrDefault();
        }
        public string Save(Category Input)
        {
            var id = Read(null).Count()+1;
            Input.Id=id;
            Input.CategoriesId=Guid.NewGuid();
             _context.Categories.InsertOne(Input);
            return $"{Input.CategoriesId} Added";
        }

        public string Update(Category Input, Guid ID)
        {
            var recordToUpdate = FindById(ID);
            recordToUpdate.Name = Input.Name;
             _context.Categories.ReplaceOne(d => d.CategoriesId == ID, recordToUpdate);
            return $"{ID} Updated";
        }
    }
}
