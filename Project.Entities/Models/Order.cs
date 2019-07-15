using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("AppUser")]
        public string CreatedById { get; set; }
        public virtual Package Package { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
    }
}
