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
    public class EmployeeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        public ActionResult Details(int? id)
        {

            Employee employee = db.Employee.Find(id);


            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = " Id,FullName,Phone,Street,State,City,Zip")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                var currentUser = (from u in db.Users where u.Id == userId select u).First();
                employee.ApplicationUserId = userId;

                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("EmployeeTodayPickups", new { id = employee.Id });
            }


            return View(employee);
        }

        public ActionResult Edit(int? Id)
        {

            Employee employee = db.Employee.Find(Id);

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = " Id,FullName,Phone,Street,State,City,Zip")] Employee employee, int Id)
        {
            if (ModelState.IsValid)
            {
                Employee employees = db.Employee.Find(Id);
                if (employees == null)
                {
                    return RedirectToAction("DisplayError", "Employee");
                }
                employees.FullName = employee.FullName;
                employees.Phone = employee.Phone;
                employees.Street = employee.Street;
                employees.State = employee.State;
                employees.Zip = employee.Zip;
                employees.City = employee.City;
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(employee);
        }

        public ActionResult Delete(int? Id)
        {
            Employee employee = db.Employee.Find(Id);
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int Id)
        {
            Employee employee = db.Employee.Find(Id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Home");

        }
        public ActionResult CustomerDetails(int? id)
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
        public ActionResult EmployeeTodayPickups()
        {
            var userId = User.Identity.GetUserId();
            var currentEmployee = (from e in db.Employee where e.ApplicationUserId == userId select e).FirstOrDefault();
            var PickupDay = DateTime.Now.DayOfWeek.ToString();
            var PresentDate = DateTime.Now.Date;
            var customerZip = (from c in db.Customer where c.Zip == currentEmployee.Zip select c).ToList();
            if (!customerZip.Any())
            {
                return View();
            }
            else
            {
                var checkPickup = db.Customer.Where(c => (c.SpecialPickupDate == PresentDate || c.PickupDayOfWeek.ToString() == PickupDay) && c.Zip == currentEmployee.Zip).ToList();
                if (!checkPickup.Any())
                {
                    return View();
                }
                else
                {
                    return View(checkPickup);
                }
            }


        }
        public ActionResult FilterByWeekday()
        {
            ViewBag.Name = "Stan";
            return View();
        }
        [HttpPost, ActionName("FilterByWeekday")]
        public ActionResult FilterByWeekday(string chosenDay)
        {
            return RedirectToAction("SelectWeekday", new { day = chosenDay });
        }
        public ActionResult SelectWeekday(string day)
        {
            List<Customer> PerticularDayCustomer = new List<Customer>();
            var userId = User.Identity.GetUserId();
            var currentEmployee = (from e in db.Employee where e.ApplicationUserId == userId select e).FirstOrDefault();
            var customerZip = (from c in db.Customer where c.Zip == currentEmployee.Zip select c).ToList();
            if (customerZip.Any())

            {
                foreach (var customer in customerZip)
                {
                    var pickupDateString = customer.SpecialPickupDate.ToString();
                    string specificDatePickup = null;
                    if (pickupDateString != "")
                    {
                        specificDatePickup = DateTime.Parse(pickupDateString).DayOfWeek.ToString();
                    }
                    if ((customer.PickupDayOfWeek.ToString() == day || specificDatePickup == day))

                    {
                        PerticularDayCustomer.Add(customer);
                    }
                }
            }
            ViewBag.dayToSee = day;
            return View(PerticularDayCustomer);
        }




        public ActionResult ConfirmPickup(int? id)
        {

            Customer customer = db.Customer.Find(id);

            return View(customer);
        }
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult ConfirmPickup([Bind(Include = " IsConfirmed")] Customer customer, int id)
        {
            if (ModelState.IsValid)
            {

                Customer updatedCustomer = db.Customer.Find(id);
                if (updatedCustomer == null)
                {
                    return RedirectToAction("DisplayError", "Customer");
                }
                updatedCustomer.IsConfirmed = customer.IsConfirmed;

                db.Entry(updatedCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeeTodayPickups");
            }
            return View(customer);
        }
        public ActionResult CustomerOnMap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerOnMap(string id)
        {
            var userId = User.Identity.GetUserId();
            var currentEmployee = (from e in db.Employee where e.ApplicationUserId == userId select e).FirstOrDefault();
            var employeeZip = currentEmployee.Zip;
            ViewBag.zip = employeeZip;
            var PickupDay = DateTime.Now.DayOfWeek.ToString();
            var PresentDate = DateTime.Now.Date;
            var customerZip = (from c in db.Customer where c.Zip == currentEmployee.Zip select c).ToList();
            if (id!= null)
            {
                var customer = (from c in db.Customer where c.Zip == currentEmployee.Zip select c).ToList();
                return View(customer);
            }
            if (!customerZip.Any())
            {
                return View();
            }
            else
            {
                var checkPickup = db.Customer.Where(c => (c.SpecialPickupDate == PresentDate || c.PickupDayOfWeek.ToString() == PickupDay) && c.Zip == currentEmployee.Zip).ToList();
                if (!checkPickup.Any())
                {
                    return View();
                }
                else
                {
                    return View(checkPickup);
                }
            }















        }
       

    }

}





    
