using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Member {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn måste anges!")]
        [StringLength(20, ErrorMessage = "Namn får vara högst 20 tecken långt!")]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adress måste anges!")]
        [StringLength(30, ErrorMessage = "Adress får vara högst 30 tecken långt!")]
        [Display(Name = "Adress")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Personnummer måste anges!")]
        [StringLength(13, ErrorMessage = "Personnummer får vara högst 13 tecken långt!")]
        [Display(Name = "Personnummer")]
        public string PNr { get; set; }

        [Display(Name = "Aktiv medlem")]
        public bool ActiveMemberShip { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}