using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// hej hej 
// Ny kommentar!

namespace Garage2.Models {
    public class Vehicle {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public DateTime CheckInTime { get; set; }
        public int Tyres { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }

    public enum VehicleType {
        Aeroplane,
        Car,
        Motorcycle,
        Boat,
        Bus
    }
}