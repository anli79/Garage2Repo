using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        [Display(Name = "In-checkningstid")]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "Parkeringstid")]
        public string ParkingTime {
            get {
                TimeSpan duration = DateTime.Now - CheckInTime;
                var hours = duration.Days * 24 + duration.Hours;
                var minutes = duration.Minutes;
                return $"{hours}h {minutes}m";
            }
        }

        [Display(Name = "Pris")]
        public string Price {
            get {
                TimeSpan duration = DateTime.Now - CheckInTime;
                int pricePerHour = 60;
                int totalPrice = ((duration.Days * 24 + duration.Hours) * 60) + (duration.Minutes % pricePerHour);
                return $"{totalPrice} kr";
            }
        }

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