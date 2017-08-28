using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models {
    [Table("Families")]
    public class Family : SocialCase {
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Must be a number")]
        public int NumberOfPeople { get; set; }
        [Required]
        [RegularExpression("(07[0125678][0-9]{6})", ErrorMessage = "Not valid Macedonian phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Must be a number")]
        public int NumberOfEmployedMembers { get; set; }
    }
}