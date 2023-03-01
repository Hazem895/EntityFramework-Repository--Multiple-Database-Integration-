using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEF.Shared.DataObjectLayer
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }

    }
}