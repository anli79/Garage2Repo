﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Vehicle {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fordonstyp måste anges!")]
        [Display(Name = "Fordonstyp")]      
        public VehicleType Type { get; set; }

        [Required(ErrorMessage = "Regnr måste anges!")]
        [MinLength(6, ErrorMessage = "Regnr måste vara minst 6 tecken!")]
        [Display(Name = "Regnr")]
        [StringLength(10, ErrorMessage = "Regnr får vara högst 10 tecken lång!")]
        public string RegNr { get; set; }

        [Required(ErrorMessage = "Färg måste anges!")]
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

        [Required(ErrorMessage = "Antal hjul måste anges!")]
        [Display(Name = "Antal hjul")]
        [Range(0,int.MaxValue, ErrorMessage = "Måste vara ett positivt tal!")]
        public int Tyres { get; set; }

        [Required(ErrorMessage = "Märke måste anges!")]
        [Display(Name = "Märke")]
        [StringLength(10, ErrorMessage = "Märke får vara högst 10 tecken!")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Modell måste anges!")]
        [Display(Name = "Modell")]
        [StringLength(10, ErrorMessage = "Modell får vara högst 10 tecken!")]
        public string Model { get; set; }
    }

    public enum VehicleType {
        Bil,
        Buss,
        Båt,
        Flygplan,
        Motorcykel
    }
}