using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEF.Domain.DomainModels
{
    public class Category
    {
        //public int Id { get; set; }
        [Key]
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        //public Guid ItemId { get; set; }
        //[ForeignKey("ItemId")]
        //public ICollection<Item> Items { get; set; }
    }

}