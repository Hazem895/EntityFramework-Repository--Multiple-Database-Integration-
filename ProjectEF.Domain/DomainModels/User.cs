using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEF.Domain.DomainModels
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

}