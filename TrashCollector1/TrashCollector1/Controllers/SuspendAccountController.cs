using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector1.Models;

namespace TrashCollector1.Controllers
{
    public class SuspendAccountController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: SuspendAccount
        public ActionResult Index()
        {
            return View(db.SuspendAccount.ToList());
        }

        // GET: SuspendAccount/Details/5
        public ActionResult Details(int? id)
        {
            SuspendAccount suspendAccount = db.SuspendAccount.Find(id);
            return View(suspendAccount);
        }

        // GET: SuspendAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuspendAccount/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = " id,AccountSuspendDate,AccountSuspendEndDate,Address,State,City,ZipCode")] SuspendAccount suspendAccount)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                suspendAccount.ApplicationUserId = userId;

                db.SuspendAccount.Add(suspendAccount);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = suspendAccount.id });
            }


            return View(suspendAccount);
        }

        // GET: SuspendAccount/Edit/5
        public ActionResult Edit(int id)
        {
            SuspendAccount suspendAccount = db.SuspendAccount.Find(id);
            return View(suspendAccount);
        }

        // POST: SuspendAccount/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = " id,AccountSuspendDate,AccountSuspendEndDate,Address,State,City,ZipCode")] SuspendAccount suspendAccount,int id)
        {
            if (ModelState.IsValid)
            {
                SuspendAccount suspendAccounts = db.SuspendAccount.Find(id);
                if (suspendAccount == null)
                {
                    return RedirectToAction("DisplayError", "SuspendAccount");
                }
                suspendAccounts.AccountSuspendDate = suspendAccount.AccountSuspendDate;
                suspendAccounts.AccountSuspendEndDate = suspendAccount.AccountSuspendEndDate;
                suspendAccounts.Address = suspendAccount.Address;
                suspendAccounts.State = suspendAccount.State;
                suspendAccounts.City = suspendAccount.City;
                suspendAccounts.ZipCode = suspendAccount.ZipCode;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = suspendAccounts.id });
            }
            return View(suspendAccount);
        }
        // GET: SuspendAccount/Delete/5
        public ActionResult Delete(int id)
        {
            SuspendAccount suspendAccount = db.SuspendAccount.Find(id);
            return View(suspendAccount);
        }

        // POST: SuperHero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            SuspendAccount suspendAccount = db.SuspendAccount.Find(id);
            db.SuspendAccount.Remove(suspendAccount);
            db.SaveChanges();
            return RedirectToAction("Create");

        }
    }
}
