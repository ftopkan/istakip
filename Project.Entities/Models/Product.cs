using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(255)]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
