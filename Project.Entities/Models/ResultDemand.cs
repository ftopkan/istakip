using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class ResultDemand
    {
        [Key, ForeignKey("Demand")]
        public int ResultDemandId { get; set; }
        public virtual Demand Demand { get; set; }
        public bool isFinished { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
