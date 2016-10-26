using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class QueryObj {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp")]
        public string Type { get; set; }

        [Display(Name = "Regnr")]
        public string RegNr { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        [StringLength(10)]
        public string Brand { get; set; }

    }
}