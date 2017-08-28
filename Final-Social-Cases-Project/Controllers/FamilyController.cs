using Final_Social_Cases_Project.Models;
using Final_Social_Cases_Project.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Social_Cases_Project.Controllers
{
    public class FamilyController : Controller {

        [HttpGet]
        public ActionResult Create(int categoryID) {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Family family) {
            if (ModelState.IsValid) {
                FamilyContext familyContext = new FamilyContext();
                familyContext.AddFamily(family);
                return RedirectToAction("Listing", "ListingCases", new { categoryID = 1 });
            }
            return View(family);
        }
        [HttpGet]
        public ActionResult Edit(int familyID) {
            FamilyContext familyContext = new FamilyContext();
            Family family = familyContext.Families.Single(fam => fam.ID == familyID);
            family.ID = familyID;
            return View(family);
        }

        [HttpPost]
        public ActionResult Edit(Family family) {
            if (ModelState.IsValid) {
                FamilyContext familyContext = new FamilyContext();
                familyContext.EditFamily(family);

                return RedirectToAction("Listing", "ListingCases", new { categoryID = 1 });
            }
            return View(family);
        }
        public ActionResult Delete(int id) {
            FamilyContext familyContext = new FamilyContext();
            familyContext.DeleteFamily(id);

            return RedirectToAction("Listing", "ListingCases", new { categoryID = 1 });
        }
    }
}