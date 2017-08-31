using Final_Social_Cases_Project.Models;
using Final_Social_Cases_Project.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Social_Cases_Project.Controllers
{
    public class NeedController : Controller
    {
        public ActionResult Index() {
            NeedContext needContext = new NeedContext();
            List<Need> needs = needContext.Needs.ToList();
            return View(needs);
        }

        [HttpGet]
        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Need need) {         
            if (ModelState.IsValid) {
                NeedContext needContext = new NeedContext();
                needContext.AddNeed(need);
                return RedirectToAction("Index");
            }
            return View(need);
        }

        [HttpGet]
        public ActionResult Edit(int needID) {
            NeedContext needContext = new NeedContext();
            Need need = needContext.Needs.Single(n => n.NeedID == needID);
            return View(need);
        }

        [HttpPost]
        public ActionResult Edit(Need need) {
            if (ModelState.IsValid) {
                NeedContext needContext = new NeedContext();
                needContext.EditNeed(need);

                return RedirectToAction("Index");
            }
            return View(need);
        }

        public ActionResult Delete(int id) {
            NeedContext needContext = new NeedContext();
            needContext.DeleteNeed(id);

            return RedirectToAction("Index");
        }
    }
}