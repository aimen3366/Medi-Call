using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using Medi_Call.Models;
using System.Threading.Tasks;
using System.Web.Security;

namespace Medi_Call.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult AdminLogin(int id = 0)
        {
            AdminLoginViewModel ad = new AdminLoginViewModel();
            return View(ad);
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLoginViewModel login, string ReturnUrl = "")
        {
            string message = "";
            using (MedicallDB db = new MedicallDB())
            {
                var v = db.Admins.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                if (v != null)
                {
                    int timeout = login.RememberMe ? 525600 : 20;
                    var ticket = new FormsAuthenticationTicket(login.Email, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return View("AdminPortal", new AdminPortalView());
                    }
                }
                else
                {
                    message = "Incorrect Email or Password!";
                }
                ViewBag.Message = message;
                return View();
            }
        }


        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            LabViewModel usermodel = new LabViewModel();
            return View(usermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LabViewModel arg)
        {
            using (MedicallDB db = new MedicallDB())
            {
                if (ModelState.IsValid)
                {
                    if (db.Labs.Any(x => x.Name == arg.Name && x.Location == x.Location))
                    {
                        ViewBag.DuplicateMessage = "Already exists";
                        return View("Register", arg);
                    }
                    Lab doc = new Lab();
                    doc.Name = arg.Name;
                    doc.Contact = arg.Contact;
                    doc.Location = arg.Location;
                    doc.Working_Days = arg.Working_Days;
                    doc.Timings = arg.Timings;
                    db.Labs.Add(doc);
                    db.SaveChanges();
                    ViewBag.SuccessMessage = "Registeration successful";
                }

                else
                {
                    ViewBag.DuplicateMessage = "Unsuccessful";
                }
            }
            ModelState.Clear();
            return View("Register", new LabViewModel());

        }

    

        [HttpGet]
        public ActionResult DocRegister(int id = 0)
        {
            AdminAddDoc dd = new AdminAddDoc();
            return View(dd);
        }

        [HttpPost]
        public ActionResult DocRegister(AdminAddDoc c)
        {

            using (MedicallDB db = new MedicallDB())
            {
                if (ModelState.IsValid)
                {
                    if (db.Labs.Any(x => x.Name == c.Name && x.Location == c.Location))
                    {
                        ViewBag.DuplicateMessage = "Already exists";
                        return View("DocRegister", c);
                    }

                    Doctor doc = new Doctor();
                    doc.Name = c.Name;
                    doc.Contact_No = c.Contact_No;
                    doc.Speciality = c.Speciality;
                    doc.Location = c.Location;
                    doc.Fee_Status = c.Fee_Status;
                    doc.Working_Days = c.Working_Days;
                    doc.Timings = c.Timings;
                    db.Doctors.Add(doc);
                    db.SaveChanges();
                    ViewBag.SuccessMessage = "Registeration successful";

                }
                else
                {
                    ViewBag.DuplicateMessage = "Unsuccessful";
                }
            }
            ModelState.Clear();
            return View("DocRegister", new AdminAddDoc());
        }
        public ActionResult AllDoc()
        {
            MedicallDB db = new MedicallDB();
            return View(db.Doctors.ToList());
        }

        public ActionResult AllLabs()
        {
            MedicallDB db = new MedicallDB();
            return View(db.Labs.ToList());
        }

        public ActionResult LDetails(string id)
        {
            MedicallDB db = new MedicallDB();
          var product = db.Labs.Where(p => p.Name == id).FirstOrDefault();
            
            if (product == null)
            {
                return new HttpNotFoundResult();
            }
            LabViewModel model = new LabViewModel()
            {
               Name = product.Name,
               
                Location = product.Location,
                Working_Days = product.Working_Days,
                Timings=product.Timings,
                
            };
            return View(model);
        }
     

        MedicallDB db = new MedicallDB();
        public ActionResult DeleteLab(string id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab personalDetail = db.Labs.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("DeleteLab")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        { 
            Lab personalDetail = db.Labs.Find(id);
            db.Labs.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("AllLabs");
        }

        public ActionResult SearchLab(string search)
        {
            MedicallDB db = new MedicallDB();
            return View(db.Labs.Where(x => x.Name == search || search == null).ToList());
        }

        public ActionResult DoctorDetails(string id)
        {
            MedicallDB db = new MedicallDB();
            var doc = db.Doctors.Where(p => p.Name== id).FirstOrDefault();

            if (doc == null)
            {
                return new HttpNotFoundResult();
            }
            DoctorRegisterViewModel model = new DoctorRegisterViewModel()
            {
                Email = doc.Email,
                Contact_No=Convert.ToInt32(doc.Contact_No),
                Speciality=doc.Speciality,
                Location=doc.Location,
                Fee_Status=Convert.ToInt32(doc.Fee_Status),
                Working_Days=doc.Working_Days,
                Timings=doc.Timings,
            };
            return View(model);
        }
        
        public ActionResult DeleteDoctor(string id)
        {
            MedicallDB dd = new MedicallDB();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doc = dd.Doctors.Find(id);
            if (doc == null)
            {
                return HttpNotFound();
            }
            return View(doc);
        }

        
        [HttpPost, ActionName("DeleteDoctor")]
        [ValidateAntiForgeryToken]
        public ActionResult DelConfirmed(string id)
        {
            MedicallDB dd = new MedicallDB();
            Doctor doc = dd.Doctors.Find(id);
            db.Doctors.Remove(doc);
            db.SaveChanges();
            return RedirectToAction("AllDoc");
        }

    }


    }

