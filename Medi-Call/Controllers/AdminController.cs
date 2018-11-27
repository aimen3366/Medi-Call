﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medi_Call.Models;

namespace Medi_Call.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminLogin(int id = 0)
        {
            AdminLoginViewModel usermodel = new AdminLoginViewModel();
            return View(usermodel);
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLoginViewModel usermodel)
        {
            using (MedicallDB db = new MedicallDB())
            {

                if (db.Admins.Any(x => x.Email == usermodel.Email && x.Password == usermodel.Password))
                {

                    ViewBag.SuccessMessage = "Login Successful";

                    return View("AdminPortal", new AdminPortalView());
                }
                ViewBag.LoginErrorMessage = "Wrong Email and password";
                return View("AdminLogin", new AdminLoginViewModel());
            }
        }

        public ActionResult AddLab(int id = 0)
        {
            LabViewModel usermodel = new LabViewModel();
            return View(usermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLab(LabViewModel arg)
        {
            using (MedicallDB db = new MedicallDB())
            {
                Lab lb = new Lab();
                lb.Name = arg.Name;
                lb.Contact = arg.Contact;
                lb.Location = arg.Location;
                lb.Working_Days = arg.Working_Days;
                lb.Timings = arg.Timings;
                db.Labs.Add(lb);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Lab Added";
            }

            ModelState.Clear();
            return View("AddLab", new LabViewModel());
        }

        public ActionResult AllLabs()
        {
            MedicallDB r = new MedicallDB();
            var data = r.Labs.ToList();
            ViewBag.userdetails = data;
            return View();
        }


        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
