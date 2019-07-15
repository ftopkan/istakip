using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Demand
    {
        [Key]
        public int CreateDemandId { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public virtual ResultDemand ResultDemand { get; set; }

    }
}
