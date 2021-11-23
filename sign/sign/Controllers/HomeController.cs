using sign.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sign.Controllers
{
    public class HomeController : Controller
    {
        SignUpEntities db = new SignUpEntities();
        public ActionResult Index()
        {

            return View(db.SignUp.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SignUp s)
        {
            db.SignUp.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var d = db.SignUp.Find(id);
            db.SignUp.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var l = db.SignUp.Find(id);
            return View(l);
        }
        [HttpPost]
        public ActionResult Edit(SignUp c)
        {   
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}