﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectEF.Domain.IRepository;
using ProjectEF.Domain.DomainModels;
//using ProjectEF.Models;
//using ProjectEF.ProjectEF.postgreSQL_Infrastructure;

namespace ProjectEF.postgreSQL_Infrastructure.Repository
{
    public class CategoryCommands : ICrudCommands<Category>
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
            Category? record = (ReadById(Input.CategoryId));
            if (record != null)
            {
                _context.Categories.Update(Input);
                _context.SaveChanges();
                return $"{Input.CategoryId} Updated Successfully";
            }
            return "Not Exists";
        }

    }
}
