using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.Models
{
    public class ProfileVm
    {
        public AppUser User { get; set; }
        public int AllDemands { get; set; }
        public int CompletedDemands { get; set; }
        public int UncompletedDemands { get; set; }
    }
}