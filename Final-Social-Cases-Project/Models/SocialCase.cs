using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models {
    public class SocialCase {
        //public int CategoryID { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Location { get; set; }

        public string ToString() {
            return "ID: " + ID + ", Surname: " + Surname + ", Location: " + Location;
        }
    }
}