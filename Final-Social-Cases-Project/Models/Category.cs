using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models {
    [Table("Categories")]
    public class Category {
        //public enum Name {
        //   Family,
        //    Refugees,
        //    Orphans
        //}
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}