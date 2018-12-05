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
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult UserRegister(int id = 0)
        {
            UserRegisterViewModel usermodel = new UserRegisterViewModel();
            return View(usermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserRegister(UserRegisterViewModel arg)
        {
            using (MedicallDB db = new MedicallDB())
            {
                if (db.Users.Any(x => x.Email== arg.Email))
                {
                    ViewBag.DuplicateMessage = "Email already exists";
                    return View("UserRegister", arg);
                }
                User us = new User();
                us.Email = arg.Email;
                us.Password = arg.Password;
                us.Confirm_Password = arg.Confirm_Password;
                us.Secret_Question = arg.Secret_Question;
                us.Answer = arg.Answer;
                db.Users.Add(us);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Registeration successful";
            }
          
            ModelState.Clear();
            return View("UserRegister", new UserRegisterViewModel());

        }

        [HttpGet]
        public ActionResult ULogin(int id = 0)
        {
            UserLoginViewModel ad = new UserLoginViewModel();
            return View(ad);
        }

        [HttpPost]
        public ActionResult ULogin(UserLoginViewModel login, string ReturnUrl = "")
        {
            string message = "";
            using (MedicallDB db = new MedicallDB())
            {
                var v = db.Users.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
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
                        return View("UserPortal", new UserPortalViewModel());
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

        public ActionResult Search(string loc,string sp)
        {
            MedicallDB db = new MedicallDB();
            return View(db.Doctors.Where(x => x.Location == loc && x.Speciality ==sp ).ToList());
        }

        public ActionResult LoadLocation()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Johar Town", Value = "1" });
            li.Add(new SelectListItem { Text = "Model Town", Value = "2" });
            li.Add(new SelectListItem { Text = "DHA", Value = "3" });
            li.Add(new SelectListItem { Text = "Garden Town", Value = "4" });
            li.Add(new SelectListItem { Text = "Bahria", Value = "5" });
            li.Add(new SelectListItem { Text = "Allama Iqbal Town", Value = "6" });
            ViewData["loc"] = li;
            return View();
        }

        public ActionResult LoadSpeciality()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Cardiac Surgeon", Value = "1" });
            li.Add(new SelectListItem { Text = "Neuro Surgeon", Value = "2" });
            li.Add(new SelectListItem { Text = "Child Specialist", Value = "3" });
            li.Add(new SelectListItem { Text = "Dermatologist", Value = "4" });
            li.Add(new SelectListItem { Text = "Gynecologist", Value = "5" });
            li.Add(new SelectListItem { Text = "Ear, Throat, Nose", Value = "6" });
            ViewData["sp"] = li;
            return View();
        }



        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
