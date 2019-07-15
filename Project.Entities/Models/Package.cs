using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        public string PackageKey { get; set; }
        [MaxLength(255)]
        public string PackageName { get; set; }
        public decimal PackagePrice { get; set; }
    }
}
