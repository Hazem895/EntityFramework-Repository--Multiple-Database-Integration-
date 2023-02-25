using Microsoft.EntityFrameworkCore;
using ProjectEF.Domain;

namespace ProjectEF.postgreSQL_Infrastructure
{
    public class ApplicationDbContext_PG : DbContext
    {

        public ApplicationDbContext_PG(DbContextOptions<ApplicationDbContext_PG> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }


    }
}