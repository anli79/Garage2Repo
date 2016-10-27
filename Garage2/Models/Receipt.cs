using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Receipt {
        [Display(Name = "Typ:")]
        public string Type  { get; set; }

        [Display(Name = "Regnr")]
        public string RegNr { get; set; }

        [Display(Name = "Ägare")]
        public string Member { get; set; }

        [Display(Name = "Parkeringstid")]
        public string ParkingTime { get; set; }

        [Display(Name = "Pris")]
        public string Price { get; set; }
    }
}