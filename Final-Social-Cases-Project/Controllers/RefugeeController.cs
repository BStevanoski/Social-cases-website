using Final_Social_Cases_Project.Models;
using Final_Social_Cases_Project.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Social_Cases_Project.Controllers
{
    public class RefugeeController : Controller
    {
        [HttpGet]
        public ActionResult Create(int categoryID) {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Refugee refugee) {
            
            if (ModelState.IsValid) {
                RefugeeContext orphanContext = new RefugeeContext();
                orphanContext.AddRefugee(refugee);
                return RedirectToAction("Listing", "ListingCases", new { categoryID = 3 });
            }
            return View(refugee);
        }

        [HttpGet]
        public ActionResult Edit(int refugeeID) {
            RefugeeContext refugeeContext = new RefugeeContext();
            Refugee refugee = refugeeContext.Refugees.Single(r => r.ID == refugeeID);
            refugee.ID = refugeeID;
            return View(refugee);
        }

        [HttpPost]
        public ActionResult Edit(Refugee refugee) {
            if (ModelState.IsValid) {
                RefugeeContext orphanContext = new RefugeeContext();
                orphanContext.EditRefugee(refugee);

                return RedirectToAction("Listing", "ListingCases", new { categoryID = 3 });
            }
            return View(refugee);
        }

        public ActionResult Delete(int id) {
            RefugeeContext refugeeContext = new RefugeeContext();
            refugeeContext.DeleteRefugee(id);

            return RedirectToAction("Listing", "ListingCases", new { categoryID = 3 });
        }
    }
}