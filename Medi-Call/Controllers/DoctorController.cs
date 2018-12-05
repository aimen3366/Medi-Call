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

        [HttpGet]
        public ActionResult Write(int id = 0)
        {
            BlogViewModel usermodel = new BlogViewModel();
            return View(usermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Write(BlogViewModel arg)
        {
            using (MedicallDB db = new MedicallDB())
            {
                if (db.Blogs.Any(x => x.Title == arg.Title))
                {
                    ViewBag.DuplicateMessage = "Already exists";
                    return View("Write", arg);
                }

                Blog bb= new Blog();
                bb.Title = arg.Title;
                bb.Paragraph = arg.Paragraph;
                bb.Uploaded_By = arg.Uploaded_By;
                db.Blogs.Add(bb);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Uploaded";
            }

            ModelState.Clear();
            return View("Write", new BlogViewModel());

        }










    }
}
