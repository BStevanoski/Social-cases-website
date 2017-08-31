using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models {
    [Table("Needs")]
    public class Need {
        public int NeedID { get; set; }
        [Required]
        public string NeedName { get; set; }
    }
}