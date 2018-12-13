using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector1.Models;

namespace TrashCollector1.Controllers
{
    public class SpecialPickupController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: SpecialPickup
        public ActionResult Index()
        {
            return View(db.SpecialPickup.ToList());
        }

        // GET: SpecialPickup/Details/5
        public ActionResult Details(int? id)
        {
            SpecialPickup specialPickup = db.SpecialPickup.Find(id);
            return View(specialPickup);
        }

        // GET: SpecialPickup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialPickup/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "PickupDate,Time,PickupAddress,Zip,Description")]SpecialPickup specialPickup)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                specialPickup.ApplicationUserId = userId;

                db.SpecialPickup.Add(specialPickup);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = specialPickup.id });
            }


            return View(specialPickup);
        }
        // GET: SpecialPickup/Edit/5
        public ActionResult Edit(int id)
        {
            SpecialPickup specialPickup = db.SpecialPickup.Find(id);
            return View(specialPickup);
        }

        // POST: SpecialPickup/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "PickupDate,Time,PickupAddress,Zip,Description")]SpecialPickup specialPickup, int id)
        {
            if (ModelState.IsValid)
            {
                if (specialPickup == null)
                {
                    return RedirectToAction("DisplayError", "SpecialPickup");
                }
                specialPickup.PickupDate = specialPickup.PickupDate;
                specialPickup.Time = specialPickup.Time;
                specialPickup.PickupAddress = specialPickup.PickupAddress;
                specialPickup.Zip = specialPickup.Zip;
                specialPickup.Description = specialPickup.Description;

                db.SaveChanges();
                return RedirectToAction("Details", new { id = specialPickup.id });
            }
            return View(specialPickup);
        }

    // GET: SpecialPickup/Delete/5
    public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialPickup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
