using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEF.Domain;

namespace ProjectEF.ProjectEF.SQL_Infrastructure
{
    public class ApplicationDbContext_SQL : DbContext
    {
        public ApplicationDbContext_SQL(DbContextOptions<ApplicationDbContext_SQL> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        

    }
}
