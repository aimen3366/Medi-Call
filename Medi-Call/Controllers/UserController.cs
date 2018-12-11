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
<<<<<<< HEAD
=======
<<<<<<< HEAD
                }
                else
                {
                    message = "Incorrect Email or Password!";
                }
=======
>>>>>>> a11dc09e91a98dac70189bba16610f7c357cb838
                }
                else
                {
                    message = "Incorrect Email or Password!";
                }
<<<<<<< HEAD
=======
>>>>>>> 67e6b90f616d0ee635916be293e0b027fb52fdf3
>>>>>>> a11dc09e91a98dac70189bba16610f7c357cb838
                ViewBag.Message = message;
                return View();
            }
        }

<<<<<<< HEAD
        //[HttpGet]
        //public ActionResult UserLogin(int id = 0)
        //{
        //    UserLoginViewModel usermodel = new UserLoginViewModel();
        //    return View(usermodel);
        //}

        //[HttpPost]
        //public ActionResult UserLogin(UserLoginViewModel usermodel)
        //{
        //    using (MedicallDB db = new MedicallDB())
        //    {

        //        if (db.Users.Any(x => x.Email == usermodel.Email && x.Password == usermodel.Password))
        //        {

        //            ViewBag.SuccessMessage = "Login Successful";

        //            return View("UserPortal", new UserPortalViewModel());
        //        }
        //        ViewBag.LoginErrorMessage = "Wrong Email and password";
        //        return View("UserLogin", new UserLoginViewModel());
        //    }
        //}

=======
        public ActionResult Search(string loc,string sp)
<<<<<<< HEAD
=======
        {
            MedicallDB db = new MedicallDB();
            return View(db.Doctors.Where(x => x.Location == loc && x.Speciality ==sp ).ToList());
        }
>>>>>>> a11dc09e91a98dac70189bba16610f7c357cb838

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
>>>>>>> 67e6b90f616d0ee635916be293e0b027fb52fdf3
        {
            MedicallDB db = new MedicallDB();
            return View(db.Doctors.Where(x => x.Location == loc && x.Speciality ==sp ).ToList());
        }

        public ActionResult SearchLab(string lc)
        {
            MedicallDB db = new MedicallDB();
            return View(db.Labs.Where(x => x.Location == lc).ToList());
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
                Timings = product.Timings,

            };
            ModelState.Clear();

            return View(model);
        }

        public ActionResult Appointment(string id)
        {
            MedicallDB db = new MedicallDB();
            var doc = db.Doctors.Where(p => p.Name == id).FirstOrDefault();

            if (doc == null)
            {
                return new HttpNotFoundResult();
            }
            DoctorRegisterViewModel model = new DoctorRegisterViewModel()
            {
                Name=doc.Name,
                Email = doc.Email,
                Contact_No = Convert.ToInt32(doc.Contact_No),
                Speciality = doc.Speciality,
                Location = doc.Location,
                Fee_Status = Convert.ToInt32(doc.Fee_Status),
                Working_Days = doc.Working_Days,
                Timings = doc.Timings,
            };
            return View(model);
        }
    }
}
