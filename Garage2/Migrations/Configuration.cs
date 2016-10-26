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

            var vehicleTypes = new VehicleType[] {
                new VehicleType() { Type = "Bil"},
                new VehicleType() { Type = "Buss"},
                new VehicleType() { Type = "Flygplan"},
                new VehicleType() { Type = "Båt"},
                new VehicleType() { Type = "Motorcykel"}
            };

            context.VehicleTypes.AddOrUpdate(v => v.Type, vehicleTypes);
            context.SaveChanges();

            var members = new Member[] {
                new Member() { Name = "Pelle Pettersson"}
        };

            context.Members.AddOrUpdate(m => m.Name, members);
            context.SaveChanges();


            context.Vehicles.AddOrUpdate(
                v => v.RegNr,
                new Vehicle {
                    RegNr = "ABC123",
                    VehicleTypeId = vehicleTypes[0].Id,
                    MemberId = members[0].Id,
                    Color = "Blå",
                    CheckInTime = DateTime.Now,
                    Tyres = 4,
                    Brand = "Boeing",
                    Model = "747",
                    SpotNr = 1
                });
            context.SaveChanges();

            //new Vehicle {
            //    RegNr = "AAA123",
            //    Type = VehicleType.Bil,
            //    Color = "Röd",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "BMW",
            //    Model = "545",
            //    SpotNr = 2
            //},
            //new Vehicle {
            //    RegNr = "ABQ444",
            //    Type = VehicleType.Buss,
            //    Color = "Grön",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "Skania",
            //    Model = "747",
            //    SpotNr = 3
            //},
            //new Vehicle {
            //    RegNr = "ABC999",
            //    Type = VehicleType.Motorcykel,
            //    Color = "Blå",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "Saab",
            //    Model = "Sonett",
            //    SpotNr = 4
            //},
            //new Vehicle {
            //    RegNr = "ACC222",
            //    Type = VehicleType.Bil,
            //    Color = "Blå",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "VW",
            //    Model = "Bubbla",
            //    SpotNr = 5
            //},
            //new Vehicle {
            //    RegNr = "EFG456",
            //    Type = VehicleType.Buss,
            //    Color = "Röd",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 6,
            //    Brand = "Scania",
            //    Model = "P42",
            //    SpotNr = 6
            //},

            //new Vehicle {
            //    RegNr = "BBC123",
            //    Type = VehicleType.Motorcykel,
            //    Color = "Blå",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "Boeing",
            //    Model = "747",
            //    SpotNr = 7
            //},
            //new Vehicle {
            //    RegNr = "AAF123",
            //    Type = VehicleType.Båt,
            //    Color = "Röd",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 0,
            //    Brand = "SeaCraft",
            //    Model = "545",
            //    SpotNr = 8
            //},
            //new Vehicle {
            //    RegNr = "ZBQ444",
            //    Type = VehicleType.Buss,
            //    Color = "Gul",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "Skania",
            //    Model = "747",
            //    SpotNr = 9
            //},
            //new Vehicle {
            //    RegNr = "ZBC999",
            //    Type = VehicleType.Bil,
            //    Color = "Röd",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "Ford",
            //    Model = "Fiesta",
            //    SpotNr = 10

            //},
            //new Vehicle {
            //    RegNr = "ZCC222",
            //    Type = VehicleType.Bil,
            //    Color = "Gul",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "VW",
            //    Model = "Bubbla",
            //    SpotNr = 11
            //},
            //new Vehicle {
            //    RegNr = "EBQ444",
            //    Type = VehicleType.Buss,
            //    Color = "Gul",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 6,
            //    Brand = "Skania",
            //    Model = "747",
            //    SpotNr = 12
            //},
            //new Vehicle {
            //    RegNr = "EFG999",
            //    Type = VehicleType.Bil,
            //    Color = "Gul",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 8,
            //    Brand = "Ford",
            //    Model = "Fiesta",
            //    SpotNr = 13
            //},
            //new Vehicle {
            //    RegNr = "EEE222",
            //    Type = VehicleType.Bil,
            //    Color = "Gul",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 3,
            //    Brand = "VW",
            //    Model = "Bubbla",
            //    SpotNr = 14
            //},
            //new Vehicle {
            //    RegNr = "HIJ789",
            //    Type = VehicleType.Bil,
            //    Color = "Svart",
            //    CheckInTime = DateTime.Now,
            //    Tyres = 4,
            //    Brand = "BMW",
            //    Model = "M5",
            //    SpotNr = 15 }
            // );
        }
    }
}
