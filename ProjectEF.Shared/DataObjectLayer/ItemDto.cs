using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Shared.DataObjectLayer
{
    public class ItemDto
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string? ImagePath { get; set; }

    }
}
