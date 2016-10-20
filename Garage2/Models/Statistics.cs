using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Statistics {
        [Display(Name = "Antal bilar")]
        public int NrOfCars { get; set; }

        [Display(Name = "Antal bussar")]
        public int NrOfBusses { get; set; }

        [Display(Name = "Antal båtar")]
        public int NrOfBoats { get; set; }

        [Display(Name = "Antal flygplan")]
        public int NrOfAirplanes { get; set; }

        [Display(Name = "Antal motorcyklar")]
        public int NrOfMotorcycles { get; set; }

        [Display(Name = "Totalt antal hjul i garaget")]
        public int NrOfWheels { get; set; }

        [Display(Name = "Totalt pris för alla fordon i garaget")]
        public int PriceAllVehicles { get; set; }
    }
}