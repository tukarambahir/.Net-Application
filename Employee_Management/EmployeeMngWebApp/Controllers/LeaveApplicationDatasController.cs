using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeMngWebApp.Models;

namespace EmployeeMngWebApp.Controllers
{
    public class LeaveApplicationDatasController : BaseController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: LeaveApplicationDatas
        public ActionResult Index()
        {
            return View(db.LeaveApplicationDatas.ToList());
        }

        // GET: LeaveApplicationDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplicationData leaveApplicationData = db.LeaveApplicationDatas.Find(id);
            if (leaveApplicationData == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplicationData);
        }

        // GET: LeaveApplicationDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveApplicationDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_no,username,LeaveTypeId,StartingDate,EndingDate,ApplyDate,NoOfDays,LeavePurpose")] LeaveApplicationData leaveApplicationData)
        {
            if (ModelState.IsValid)
            {
                db.LeaveApplicationDatas.Add(leaveApplicationData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaveApplicationData);
        }

        // GET: LeaveApplicationDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplicationData leaveApplicationData = db.LeaveApplicationDatas.Find(id);
            if (leaveApplicationData == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplicationData);
        }

        // POST: LeaveApplicationDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_no,username,LeaveTypeId,StartingDate,EndingDate,ApplyDate,NoOfDays,LeavePurpose")] LeaveApplicationData leaveApplicationData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveApplicationData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveApplicationData);
        }

        // GET: LeaveApplicationDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplicationData leaveApplicationData = db.LeaveApplicationDatas.Find(id);
            if (leaveApplicationData == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplicationData);
        }

        // POST: LeaveApplicationDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveApplicationData leaveApplicationData = db.LeaveApplicationDatas.Find(id);
            db.LeaveApplicationDatas.Remove(leaveApplicationData);
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
