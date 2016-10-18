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
                    Color = "Bl�",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Boeing",
                    Model = "747"
                },
                new Vehicle {
                    RegNr = "AAA123",
                    Type = VehicleType.Bil,
                    Color = "R�d",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "BMW",
                    Model = "545"
                },
                new Vehicle {
                    RegNr = "ABQ444",
                    Type = VehicleType.Buss,
                    Color = "Gr�n",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Skania",
                    Model = "747"
                },
                new Vehicle {
                    RegNr = "ABC999",
                    Type = VehicleType.Bil,
                    Color = "Bl�",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Saab",
                    Model = "Sonett"
                },
                new Vehicle {
                    RegNr = "ACC222",
                    Type = VehicleType.Bil,
                    Color = "Bl�",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "VW",
                    Model = "Bubbla"
                },
                new Vehicle {
                    RegNr = "EFG456",
                    Type = VehicleType.Buss,
                    Color = "R�d",
                    CheckInTime = DateTime.Now,
                    Tyres = 6,
                    Brand = "Scania",
                    Model = "P42"
                },

                new Vehicle {
                    RegNr = "BBC123",
                    Type = VehicleType.Motorcykel,
                    Color = "Bl�",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Boeing",
                    Model = "747"
                },
                new Vehicle {
                    RegNr = "AAF123",
                    Type = VehicleType.Bil,
                    Color = "R�d",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "BMW",
                    Model = "545"
                },
                new Vehicle {
                    RegNr = "ZBQ444",
                    Type = VehicleType.Buss,
                    Color = "Gul",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Skania",
                    Model = "747"
                },
                new Vehicle {
                    RegNr = "ZBC999",
                    Type = VehicleType.Bil,
                    Color = "R�d",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Ford",
                    Model = "Fiesta"
                },
                new Vehicle {
                    RegNr = "ZCC222",
                    Type = VehicleType.Bil,
                    Color = "Gul",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "VW",
                    Model = "Bubbla"
                },
                new Vehicle {
                    RegNr = "EBQ444",
                    Type = VehicleType.Buss,
                    Color = "Gul",
                    CheckInTime = DateTime.Now,
                    Tyres = 6,
                    Brand = "Skania",
                    Model = "747"
                },
                new Vehicle {
                    RegNr = "EFG999",
                    Type = VehicleType.Bil,
                    Color = "Gul",
                    CheckInTime = DateTime.Now,
                    Tyres = 8,
                    Brand = "Ford",
                    Model = "Fiesta"
                },
                new Vehicle {
                    RegNr = "EEE222",
                    Type = VehicleType.Bil,
                    Color = "Gul",
                    CheckInTime = DateTime.Now,
                    Tyres = 3,
                    Brand = "VW",
                    Model = "Bubbla"
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
