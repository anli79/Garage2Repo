using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage2.Models;

namespace Garage2.DAL {
    public class VehicleDBContext : DbContext {
        public VehicleDBContext() : base("GVDB") {

        }

        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}