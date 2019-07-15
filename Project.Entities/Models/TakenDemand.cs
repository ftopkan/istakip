using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class TakenDemand
    {
        [Key, ForeignKey("Demand")]
        public int TakenDemandId { get; set; }
        public virtual Demand Demand { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
