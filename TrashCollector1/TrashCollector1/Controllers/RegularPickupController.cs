using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector1.Models;

namespace TrashCollector1.Controllers
{
    public class RegularPickupController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: RegularPickup
        public ActionResult Index()
        {
            return View(db.RegularPickup.ToList());
        }

        // GET: RegularPickup/Details/5
        public ActionResult Details(int? Id)
        {
            RegularPickup regularpickup = db.RegularPickup.Find(Id);
            return View(regularpickup);
        }

        // GET: RegularPickup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegularPickup/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "PickupActive,PickupDayOfWeek,Description")] RegularPickup regularPickup)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                regularPickup.ApplicationUserId = userId;

                db.RegularPickup.Add(regularPickup);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = regularPickup.Id });
            }


            return View(regularPickup);
        }

        // GET: RegularPickup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegularPickup/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RegularPickup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegularPickup/Delete/5
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
