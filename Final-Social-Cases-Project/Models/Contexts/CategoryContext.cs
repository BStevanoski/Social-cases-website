using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models.Contexts {
    public class CategoryContext : DbContext {
        public DbSet<Category> Categories { get; set; }
    }
}