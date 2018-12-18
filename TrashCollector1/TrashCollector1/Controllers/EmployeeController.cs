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
            return View(db.Employee.ToList());
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

        public ActionResult Edit(int? id)
        {

            Employee employee = db.Employee.Find(id);

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = " Id,FullName,Phone,Street,State,City,Zip")] Employee employee, int id)
        {
            if (ModelState.IsValid)
            {
                Employee employees = db.Employee.Find(id);
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

        public ActionResult Delete(int? id)
        {
            Employee employee = db.Employee.Find(id);
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Home");

        }
        public ActionResult EmployeeTodayPickups()
        {
            var userId = User.Identity.GetUserId();
            var currentEmployee = (from e in db.Employee where e.ApplicationUserId == userId select e).FirstOrDefault();
            var PickupDay = DateTime.Now.DayOfWeek.ToString();
            var PresentDate = DateTime.Now.Date;
            var customersMatchingZip = (from c in db.Customer where c.Zip == currentEmployee.Zip select c).ToList();
            if (!customersMatchingZip.Any())
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




    
