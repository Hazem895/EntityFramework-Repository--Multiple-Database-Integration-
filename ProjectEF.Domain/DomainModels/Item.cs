using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Domain.DomainModels
{
    public class Item
    {
        //public int Id { get; set; }
        [Key]
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string? ImagePath { get; set; }
        public Guid? CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public ICollection<Category> Categories { get; set; }


    }
}
