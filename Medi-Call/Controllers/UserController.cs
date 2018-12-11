﻿using System;
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
