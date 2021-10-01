using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee.Models;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        private yazcity_EmployeeEntities db = new yazcity_EmployeeEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.TBL_EMPLOYEE.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EMPLOYEE tBL_EMPLOYEE = db.TBL_EMPLOYEE.Find(id);
            if (tBL_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EMPLOYEE);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPLOYEEID,EMPLOYEENAME,PLACE,CREATEDDATE,UPDATEDDATE")] TBL_EMPLOYEE tBL_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.TBL_EMPLOYEE.Add(tBL_EMPLOYEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_EMPLOYEE);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EMPLOYEE tBL_EMPLOYEE = db.TBL_EMPLOYEE.Find(id);
            if (tBL_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EMPLOYEE);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLOYEEID,EMPLOYEENAME,PLACE,CREATEDDATE,UPDATEDDATE")] TBL_EMPLOYEE tBL_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_EMPLOYEE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_EMPLOYEE);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EMPLOYEE tBL_EMPLOYEE = db.TBL_EMPLOYEE.Find(id);
            if (tBL_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EMPLOYEE);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TBL_EMPLOYEE tBL_EMPLOYEE = db.TBL_EMPLOYEE.Find(id);
            db.TBL_EMPLOYEE.Remove(tBL_EMPLOYEE);
            db.SaveChanges();
            return RedirectToAction("Index");
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
