using sign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sign.Controllers
{
    public class DefaultController : Controller
    {
        SignUpEntities db = new SignUpEntities();
        public ActionResult Index()
        {
            var L = db.SignUp.OrderBy(x=>x.Name).ToList();
            return View(L);
        }
        public ActionResult Details(int id)
        {
            SignUp f = db.SignUp.Find(id);
            return View(f);
        }
        public ActionResult List(string List)
        {
            var l = db.SignUp.Where(s => s.Name.StartsWith(List)).ToList();
            return View(l);
        }
    }
}