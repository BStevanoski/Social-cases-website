using Final_Social_Cases_Project.Models;
using Final_Social_Cases_Project.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Social_Cases_Project.Controllers
{
    public class ListingCasesController : Controller
    {
        // GET: ListingCases
        public ActionResult Index()
        {
            ListingCases listingCases = new ListingCases();
            listingCases.categories = new List<Category>();
            CategoryContext categoryContext = new CategoryContext();
            listingCases.categories = categoryContext.Categories.ToList();

            listingCases.refugees = new List<Refugee>();
            listingCases.orphans = new List<Orphan>();
            listingCases.families = new List<Family>();
            return View(listingCases);
        }

        public ActionResult Listing(int categoryID) {
            ListingCases listingCases = new ListingCases();
            listingCases.categories = new List<Category>();
            CategoryContext categoryContext = new CategoryContext();
            listingCases.categories = categoryContext.Categories.ToList();

            listingCases.families = new List<Family>();
            listingCases.refugees = new List<Refugee>();
            listingCases.orphans = new List<Orphan>();

            if (categoryID == 1) {
                FamilyContext familyContext = new FamilyContext();
                //listingCases.families = familyContext.Families.Where(emp=>emp.CategoryID == categoryID).ToList();
                listingCases.families = familyContext.Families.ToList();
            }
            else if (categoryID == 2) {
                OrphanContext orphanContext = new OrphanContext();
                //listingCases.orphans = orphanContext.Orphans.Where(emp=>emp.CategoryID == categoryID).ToList();
                listingCases.orphans = orphanContext.Orphans.ToList();
            }
            else if (categoryID == 3) {
                RefugeeContext refugeeContext = new RefugeeContext();
                //listingCases.refugees = refugeeContext.Refugees.Where(emp=>emp.CategoryID == categoryID).ToList();
                listingCases.refugees = refugeeContext.Refugees.ToList();
            }

            return View("Index", listingCases);
        }

        [HttpGet]
        public ActionResult Create(int categoryID) {
            //CreatingCases creatingCases = new CreatingCases();
            //creatingCases.Categories = new List<Category>();
            //CategoryContext categoryContext = new CategoryContext();
            //creatingCases.Categories = categoryContext.Categories.ToList();
            //if (categoryID == 1) {
            //    creatingCases.Family = new Family();
            //}
            //else if(categoryID == 2) {
            //    creatingCases.Orphan = new Orphan();
            //}
            //else if(categoryID == 3) {
            //    creatingCases.Refugee = new Refugee();
            //}

            return View();
        }
        
    }
}