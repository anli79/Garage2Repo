using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class VehicleType {
        public int Id { get; set; }

        [Display(Name = "Typ")]
        public string Type { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}