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
        public double? ChargesForCustomer(Customer customer)
        {
            customer.Fee = customer.Fee + 10;
            var money = customer.Fee;
            return money;
        }


        public ActionResult MakePayment()
        {
            var userId = User.Identity.GetUserId();
            //customer.ApplicationUserId = userId;
            var currentCustomer = (from c in db.Customer where c.ApplicationUserId == userId select c).FirstOrDefault();
           
            return View (currentCustomer);
        }
       
        public ActionResult CheckBalance(int? id)
        {
            var userId = User.Identity.GetUserId();
            //customer.ApplicationUserId = userId;
            var currentCustomer = (from c in db.Customer where c.ApplicationUserId == userId select c).FirstOrDefault();
            currentCustomer.PickupCompleted = true;
           
            var charge = ChargesForCustomer(currentCustomer);

            if (currentCustomer != null) currentCustomer.Fee = charge;
            if (currentCustomer != null) currentCustomer.IsConfirmed = true;

            db.Entry(currentCustomer).State = EntityState.Modified;
            db.SaveChanges();

            return View(currentCustomer);
        }
       

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
                var currentCstomer = (from c in db.Customer where c.ApplicationUserId == userId select c).FirstOrDefault();//added test 
                currentCstomer.PickupDayOfWeek = customer.PickupDayOfWeek;
                currentCstomer.Time = customer.Time;
                currentCstomer.Description = customer.Description;
                db.SaveChanges();
                return RedirectToAction("DetailsOfPickup", new { id = customer.Id });
            }


            return View(customer);
        }

        public ActionResult DetailsOfPickup()
        {

            var FoundUserId = User.Identity.GetUserId();
            Customer customer = db.Customer.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
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
        public ActionResult CreateSpecialPickup([Bind(Include = "SpecialPickupDate,Time,Description")]Customer customer )
        {
            if(ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                customer.ApplicationUserId = userId;
                var currentCstomer = (from c in db.Customer where c.ApplicationUserId == userId select c).FirstOrDefault();//
                currentCstomer.SpecialPickupDate = customer.SpecialPickupDate;
                currentCstomer.Time = customer.Time;
                

                db.SaveChanges();
                return RedirectToAction("DetailsOfSpecialPickup", new { id = customer.Id });
            }


            return View(customer);
        }

        public ActionResult DetailsOfSpecialPickup()
        {

            var FoundUserId = User.Identity.GetUserId();
            Customer customer = db.Customer.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(customer);
        }


   
        public ActionResult EditSpecialPickup(int? id)
        {

            Customer customer = db.Customer.Find(id);

            return View(customer);
    }
    // POST: Customer/Edit/5
    [HttpPost]
    public ActionResult EditSpecialPickup([Bind(Include = " SpecialPickupDate,Time,Description")] Customer customer, int id)
    {
        if (ModelState.IsValid)
        {
            Customer updatedCustomer = db.Customer.Find(id);
            if (updatedCustomer == null)
            {
                return RedirectToAction("DisplayError", "Customer");
            }
            updatedCustomer.SpecialPickupDate = customer.SpecialPickupDate;
            updatedCustomer.Time = customer.Time;
            updatedCustomer.Description = customer.Description;

            db.Entry(updatedCustomer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DetailsOfSpecialPickup");
        }
        return View(customer);
    }
    /// </summary>
    /// <returns></returns>
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
                var currentCstomer = (from c in db.Customer where c.ApplicationUserId == userId select c).FirstOrDefault();
                currentCstomer.AccountSuspendDate = customer.AccountSuspendDate;
                currentCstomer.AccountSuspendEndDate = customer.AccountSuspendEndDate;
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
