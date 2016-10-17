using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


// hej hej 
// Ny kommentar!

namespace Garage2.Models {
    public class Vehicle {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fordonstyp")]      
        public VehicleType Type { get; set; }

        [Required]
        [MinLength(6)]
        [Display(Name = "Regnr")]
        [StringLength(10)]
        public string RegNr { get; set; }

        [Required]
        [Display(Name = "Färg")]
        public string Color { get; set; }

        public DateTime CheckInTime { get; set; }

        [Required]
        [Display(Name = "Antal hjul")]
        [Range(0,int.MaxValue, ErrorMessage = "Måste vara ett positivt tal!")]
        public int Tyres { get; set; }

        [Required]
        [Display(Name = "Märke")]
        [StringLength(10)]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Modell")]
        [StringLength(10)]
        public string Model { get; set; }
    }

    public enum VehicleType {
        Flygplan,
        Bil,
        Motorcykel,
        Båt,
        Buss
    }
}