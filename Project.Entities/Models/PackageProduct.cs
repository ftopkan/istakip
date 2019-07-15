using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class PackageProduct
    {
        [Key, ForeignKey("Package"), Column(Order = 10)]
        public int PackageId { get; set; }
        public Package Package { get; set; }
        [Key, ForeignKey("Product"), Column(Order = 20)]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
