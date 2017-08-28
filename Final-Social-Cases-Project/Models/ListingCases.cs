using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models {
    public class ListingCases {
        public List<Category> categories { get; set; }

        public List<Family> families { get; set; }
        public List<Orphan> orphans { get; set; }
        public List<Refugee> refugees { get; set; }
    }
}