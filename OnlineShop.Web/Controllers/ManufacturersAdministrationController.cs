using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Data;

namespace OnlineShop.Web.Controllers
{
    //[Authorize(Roles="Admin")]
    public class ManufacturersAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Administration/
        public ActionResult Index()
        {
            return View(db.Manufacturers.ToList());
        }

        // GET: /Administration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: /Administration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administration/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] Manufacturer manufacturer)
        {

            if (db.Manufacturers.Any(x => x.Name == manufacturer.Name))
            {
                ModelState.AddModelError("Name", "There is a already a vendor with the same name in the Database.");
            }

            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: /Administration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: /Administration/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Manufacturer manufacturer)
        {
            if (db.Manufacturers.Any(x => x.Name == manufacturer.Name))
            {
                ModelState.AddModelError("Name", "There is a already a vendor with the same name in the Database.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: /Administration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: /Administration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);

            foreach (var cellphon in manufacturer.CellPhones.ToList())
            {
                foreach (var vote in cellphon.Vote.ToList())
                {
                    db.Votes.Remove(vote);
                }

                foreach (var comment in cellphon.Comment.ToList())
                {
                    db.Comments.Remove(comment);
                }

                db.CellPhones.Remove(cellphon);
            }

            db.Manufacturers.Remove(manufacturer);
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
