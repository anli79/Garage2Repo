using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Member {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PNr { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}