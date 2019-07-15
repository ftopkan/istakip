using Microsoft.AspNet.Identity.EntityFramework;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {
           // Database.Connection.ConnectionString= @"server=WISSEN\MSSQL720707;database=DemandPlanningDb;uid=sa;pwd=12345";
            Database.Connection.ConnectionString = @"server=DESKTOP-0QGVMC9\SQLEXPRESS;database=DemandPlanningDb;Integrated Security=SSPI";
        }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<TakenDemand> TakenDemands { get; set; }
        public DbSet<ResultDemand> ResultDemands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageProduct> PackageProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
