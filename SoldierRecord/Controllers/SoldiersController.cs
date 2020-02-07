using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasicEF6_migrations;
using DataModels;

namespace SoldierRecord.Controllers
{
    public class SoldiersController : Controller
    {
        private SoldierContext db = new SoldierContext();

        // GET: Soldiers
        public ActionResult Index()
        {
            var soldiers = db.Soldiers.Include(s => s.Clan);
            return View(soldiers.ToList());
        }

        // GET: Soldiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soldier soldier = db.Soldiers.Find(id);
            if (soldier == null)
            {
                return HttpNotFound();
            }
            return View(soldier);
        }

        // GET: Soldiers/Create
        public ActionResult Create()
        {
            ViewBag.ClanId = new SelectList(db.Clans, "Id", "ClanName");
            return View();
        }

        // POST: Soldiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ServerdInSpecial,ClanId,BirthDate,DateCreated,DateModified")] Soldier soldier)
        {
            if (ModelState.IsValid)
            {
                db.Soldiers.Add(soldier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClanId = new SelectList(db.Clans, "Id", "ClanName", soldier.ClanId);
            return View(soldier);
        }

        // GET: Soldiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soldier soldier = db.Soldiers.Find(id);
            if (soldier == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClanId = new SelectList(db.Clans, "Id", "ClanName", soldier.ClanId);
            return View(soldier);
        }

        // POST: Soldiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ServerdInSpecial,ClanId,BirthDate,DateCreated,DateModified")] Soldier soldier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soldier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClanId = new SelectList(db.Clans, "Id", "ClanName", soldier.ClanId);
            return View(soldier);
        }

        // GET: Soldiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soldier soldier = db.Soldiers.Find(id);
            if (soldier == null)
            {
                return HttpNotFound();
            }
            return View(soldier);
        }

        // POST: Soldiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soldier soldier = db.Soldiers.Find(id);
            db.Soldiers.Remove(soldier);
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
