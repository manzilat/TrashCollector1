﻿using Microsoft.AspNet.Identity;
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
        public ActionResult Details(int? id)
        {
            Customer customer = null;
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var FoundUserId = User.Identity.GetUserId();

                customer = db.Customer.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(customer);

            }

            else
            {
                customer = db.Customer.Find(id);
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
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

                var userId = User.Identity.GetUserId();
                customer.ApplicationUserId = userId;

                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer.Id });
            }


            return View(customer);
        }
        public ActionResult CreateRegularPickup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRegularPickup([Bind(Include = " PickupDayOfWeek,Time,Description")] Customer customer)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                customer.ApplicationUserId = userId;
        
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("DetailsOfPickup", new { id = customer.Id });
            }


            return View(customer);
        }

        //public ActionResult DetailsOfPickup(int? id)
        //{

        //    Customer customer = db.Customer.Find(id);


        //    return View(customer);
        //}



        public ActionResult DetailsOfPickup(int? id)
        {
            Customer customer = null;
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var FoundUserId = User.Identity.GetUserId();

                customer = db.Customer.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(customer);

            }

            else
            {
                customer = db.Customer.Find(id);
            }

            if (customer == null)
            {
                return HttpNotFound();
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
        public ActionResult Edit([Bind(Include = " Id,FullName,Phone,Street,State,City,Zip")] Customer customer, int id)
        {
            if (ModelState.IsValid)
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

        public ActionResult EditRegularPickup(int? id)
        {

            Customer customer = db.Customer.Find(id);

            return View(customer);
        }
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult EditRegularPickup([Bind(Include = " PickupDayOfWeek,Time,Description")] Customer customer, int id)
        {
            if (ModelState.IsValid)
            {
                Customer updatedCustomer = db.Customer.Find(id);
                if (updatedCustomer == null)
                {
                    return RedirectToAction("DisplayError", "Customer");
                }
                updatedCustomer.PickupDayOfWeek = customer.PickupDayOfWeek;
                updatedCustomer.Time = customer.Time;
                updatedCustomer.Description = customer.Description;
               
                db.Entry(updatedCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DetailsOfPickup");
            }
            return View(customer);
        }

        public ActionResult CreateSpecialPickup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSpecialPickup([Bind(Include = "SpecialPickupDate,Time,Street,State,City,Zip,Description")]Customer customer )
        {
            if(ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                customer.ApplicationUserId = userId;

                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("DetailsOfSpecialPickup", new { id = customer.Id });
            }


            return View(customer);
        }
        public ActionResult DetailsOfSpecialPickup(int? id)
        {
            Customer customer = db.Customer.Find(id);
            return View(customer);
        }
        public ActionResult CreateSuspendAccount()
        {
            return View();
        }
        // POST: Customer/Create
        [HttpPost]
        public ActionResult CreateSuspendAccount([Bind(Include = " AccountSuspendDate,AccountSuspendEndDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                customer.ApplicationUserId = userId;

                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("DetailsOfSuspendedAccount", new { id = customer.Id });
            }


            return View(customer);
        }
        public ActionResult DetailsOfSuspendedAccount(int? id)
        {
            Customer customer = db.Customer.Find(id);
            return View(customer);
        }
    }
}