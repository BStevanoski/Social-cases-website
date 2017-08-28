using Final_Social_Cases_Project.Models;
using Final_Social_Cases_Project.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Social_Cases_Project.Controllers {
    public class OrphanController : Controller {

        [HttpGet]
        public ActionResult Create(int categoryID) {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Orphan o) {
            /*
            Orphan orphan = new Orphan();
            orphan.Gender = formCollection["Gender"].Equals("Male") ? Gender.Male : Gender.Female;
            orphan.Location = formCollection["Location"];
            orphan.Name = formCollection["Name"];
            orphan.Surname = formCollection["Surname"];
            orphan.Years = Convert.ToInt32(formCollection["Years"]);
            */
            if (ModelState.IsValid) {
                OrphanContext orphanContext = new OrphanContext();
                orphanContext.AddOrphan(o);
                return RedirectToAction("Listing", "ListingCases", new { categoryID = 2 });
            }
            return View(o);
        }

        [HttpGet]
        public ActionResult Edit(int orphanID) {
            OrphanContext orphanContext = new OrphanContext();
            Orphan orphan = orphanContext.Orphans.Single(orp => orp.ID == orphanID);
            orphan.ID = orphanID;
            return View(orphan);
        }

        [HttpPost]
        public ActionResult Edit(Orphan o) {
            /*
            Orphan orphan = new Orphan();
            orphan.Gender = formCollection["Gender"].Equals("Male") ? Gender.Male : Gender.Female;
            orphan.Location = formCollection["Location"];
            orphan.Name = formCollection["Name"];
            orphan.Surname = formCollection["Surname"];
            orphan.Years = Convert.ToInt32(formCollection["Years"]);

            System.Diagnostics.Debug.WriteLine(orphan.ToString());
            */
            if (ModelState.IsValid) {
                OrphanContext orphanContext = new OrphanContext();
                orphanContext.EditOrphan(o);

                return RedirectToAction("Listing", "ListingCases", new { categoryID = 2 });
            }
            return View(o);
        }

        public ActionResult Delete(int id) {
            OrphanContext orphanContext = new OrphanContext();
            orphanContext.DeleteOrphan(id);

            return RedirectToAction("Listing", "ListingCases", new { categoryID = 2 });
        }
    }
}