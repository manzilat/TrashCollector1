using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector1.Models;

namespace TrashCollector1.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id )
        {
           
            Customer customer = db.Customer.Find(id);
  

            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = " Id,FullName,Phone,Street,State,City,Zip")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.MoneyOwed = 0;
                var userId = User.Identity.GetUserId();
                customer.ApplicationUserId = userId;

                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer.Id }); 
            }


            return View(customer);
        }
        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {

            Customer customer = db.Customer.Find(id);

            return View(customer);
        }
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = " Id,FullName,Phone,Street,State,City,Zip")] Customer customer,int id)
        {
            if(ModelState.IsValid)
            {
                Customer updatedCustomer = db.Customer.Find(id);
                if (updatedCustomer == null)
                {
                    return RedirectToAction("DisplayError", "Customer");
                }
                updatedCustomer.FullName = customer.FullName;
                updatedCustomer.Phone = customer.Phone;
                updatedCustomer.Street = customer.Street;
                updatedCustomer.State = customer.State;
                updatedCustomer.Zip = customer.Zip;
                updatedCustomer.City = customer.City;
                db.Entry(updatedCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            Customer customer = db.Customer.Find(id);
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)

        {
            Customer customer = db.Customer.Find(id);
            customer.FullName = "Deleted";
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("LogOff", "Account");
        }

        public ActionResult PayForService()
        {
            var userId = User.Identity.GetUserId();
            Customer customer = (from c in db.Customer where userId == c.ApplicationUserId select c).First();

            return View(customer);
        }

        public ActionResult PayForServiceConfirmed(string id)
        {
            Customer customer = (from c in db.Customer where c.ApplicationUserId == id select c).First();

            customer.IsConfirmed = false;
            customer.MoneyOwed = 0;

            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
