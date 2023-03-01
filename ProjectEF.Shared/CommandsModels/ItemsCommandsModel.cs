using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Shared.CommandsModels
{
    public class CreateItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public Guid CategoryId { get; set; }
        public string? ImagePath { get; set; }
    }

    public class UpdateItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public Guid CategoryId { get; set; }

        public string? ImagePath { get; set; }
    }
}
