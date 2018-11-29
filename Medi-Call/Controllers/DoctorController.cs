using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medi_Call.Models;
using System.Net;
using System.Data.Entity.Validation;
using System.Data;
using System.Data.Entity;


namespace Medi_Call.Controllers
{
    public class DoctorController : Controller
    {

        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            DoctorRegisterViewModel usermodel = new DoctorRegisterViewModel();
            return View(usermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(DoctorRegisterViewModel arg)
        {
            using (MedicallDB db = new MedicallDB())
            {
                if (db.Doctors.Any(x => x.Email == arg.Email))
                {
                    ViewBag.DuplicateMessage = "Email already exists";
                    return View("Register", arg);
                }

                Doctor doc = new Doctor();
                    doc.Email = arg.Email;
                    doc.Name = arg.Name;
                    doc.Password = arg.Password;
                    doc.Confirm_Pssword = arg.Confirm_Password;
                    doc.Speciality = arg.Speciality;
                    doc.Contact_No = arg.Contact_No;
                    doc.Location = arg.Location;
                    doc.Fee_Status = arg.Fee_Status;
                    doc.Working_Days = arg.Working_Days;
                    doc.Timings = arg.Timings;
                    db.Doctors.Add(doc);
                    db.SaveChanges();
                ViewBag.SuccessMessage = "Registeration successful";
            }
            
            ModelState.Clear();  
            return View("Register", new DoctorRegisterViewModel());

        }

        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            DoctorLoginViewModel usermodel = new DoctorLoginViewModel();
            return View(usermodel);
        }

        [HttpPost]
        public ActionResult Login(DoctorLoginViewModel usermodel)
        {
            using (MedicallDB db = new MedicallDB())
            {

                if (db.Doctors.Any(x => x.Email == usermodel.Email && x.Password == usermodel.Password))
                {

                    ViewBag.SuccessMessage = "Login Successful";

                    return View("Portal", new DocPortalViewModel());
                }
                ViewBag.LoginErrorMessage = "Wrong Email and password";
                return View("Login", new DoctorLoginViewModel());
            }
        }


        public ActionResult DocPortal(int id = 0)
        {
            DocPortalViewModel doc = new DocPortalViewModel();
            return View(doc);
        }











        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
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

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
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

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
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
