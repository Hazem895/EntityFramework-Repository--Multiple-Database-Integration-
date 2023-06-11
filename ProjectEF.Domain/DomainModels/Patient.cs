using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Domain.DomainModels
{
    public class Patient
    {
        [Key]
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Data { get; set; }
        public string? Address { get; set; }
        public string? Operations { get; set; }
        public string? History { get; set; }
        public string? Complain { get; set; }
        public string? FinalDiagnosis { get; set; }
        public string? FutherManagment { get; set; }
        public string? ProvisonalDiagnosis { get; set; }
    }
}
