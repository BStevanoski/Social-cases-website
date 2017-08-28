using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models {
    [Table("Orphans")]
    public class Orphan : SocialCase {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Years { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string ToString() {
            return base.ToString() + "Name: " + Name + ", Years: " + Years + ", Gender: " + Gender;
        }

    }
}