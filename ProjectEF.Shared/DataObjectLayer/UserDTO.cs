using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEF.Shared.DataObjectLayer
{
    public class UserDTO
    {
        public Guid? ID { get; set; }
        public string? Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
    }
}