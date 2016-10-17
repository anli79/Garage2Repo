namespace Garage2.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2.DAL;
    using Garage2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.DAL.VehicleDBContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2.DAL.VehicleDBContext context) {
            context.Vehicles.AddOrUpdate(
                v => v.RegNr,
                new Vehicle {
                    RegNr = "ABC123",
                    Type = VehicleType.Flygplan,
                    Color = "Blå",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Boeing",
                    Model = "747"
                },
                new Vehicle {
                    RegNr = "EFG456",
                    Type = VehicleType.Buss,
                    Color = "Röd",
                    CheckInTime = DateTime.Now,
                    Tyres = 6,
                    Brand = "Scania",
                    Model = "P42"
                },
                new Vehicle {
                    RegNr = "HIJ789",
                    Type = VehicleType.Bil,
                    Color = "Svart",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "BMW",
                    Model = "M5"
                });
        }
    }
}
