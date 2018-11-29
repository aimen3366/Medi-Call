using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medi_Call.Models;

namespace Medi_Call.Controllers
{
    public class BloodController : Controller
    {
        // GET: Blood

        public ActionResult BloodDonor(int id = 0)
        {
            BloodViewModel usermodel = new BloodViewModel();
            return View(usermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BloodDonor(BloodViewModel arg)
        {
            using (MedicallDB db = new MedicallDB())
            {
                Blood lb = new Blood();
                lb.Name = arg.Name;
                lb.Contact_No = arg.Contact;
                lb.Location = arg.Location;
                lb.Blood_Group = arg.Blood_Group;
                db.Bloods.Add(lb);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Registered";
            }

            ModelState.Clear();
            return View("BloodDonor", new BloodViewModel());
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Blood/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blood/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blood/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blood/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blood/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blood/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blood/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
