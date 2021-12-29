using MvcHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcHouse.Controllers
{
    public class HouseController : Controller
    {
        private MyDB db = new MyDB();
        // GET: House
        public ActionResult Index(string strSearch)
        {
            var houses = from i in db.Houses
                        select i;
            if (!String.IsNullOrEmpty(strSearch))
            {
                houses = houses.Where(s => s.Owner.Contains(strSearch));
            }
            return View(houses);
        }
        [HttpPost]
        public string Index(FormCollection fc, string strSearch)
        {
            return "<h3> From [HttpPost]Index: " + strSearch + "</h3>";
        }
        // GET: House/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: House/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: House/Create
        [HttpPost]
        public ActionResult Create(House model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new MyDB();
                context.Houses.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: House/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new MyDB();
            var editing = context.Houses.Find(id);
            return View(editing);
        }

        // POST: House/Edit/5
        [HttpPost]
        public ActionResult Edit(House model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new MyDB();
                var houses = context.Houses.Find(model.ID);
                houses.Owner = model.Owner;
                houses.Type = model.Type;
                houses.Price = model.Price;
                houses.Address = model.Address;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: House/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new MyDB();
            var deleting = context.Houses.Find(id);
            return View(deleting);
        }

        // POST: House/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new MyDB();
                var deleting = context.Houses.Find(id);
                context.Houses.Remove(deleting);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
