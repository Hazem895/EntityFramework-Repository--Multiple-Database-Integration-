using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using ProjectEF.Domain.DomainModels;

namespace ProjectEF.ProjectEF.SQL_Infrastructure
{
    public class ApplicationDbContext_SQL : DbContext
    {
        public ApplicationDbContext_SQL(DbContextOptions<ApplicationDbContext_SQL> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Item>()
        //        .HasOne<Category>(x=>x.Category).WithMany(s=>s.Items).HasForeignKey<string>(c=>c.CategoryId.ToString());
        //}
        

    }
}
