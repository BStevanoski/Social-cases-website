using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models {
    [Table("Refugees")]
    public class Refugee : SocialCase {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Nationality { get; set; }
    }
}