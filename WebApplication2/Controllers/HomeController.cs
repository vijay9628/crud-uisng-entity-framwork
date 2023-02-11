using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        enitities db = new enitities();
        public ActionResult Index()
        {
            var data = db.Emps.ToList();
            return View(data);
        }
        public ActionResult Create()

        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(Emp e)
        {
            
            db.Emps.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id=0)
        {
            Emp e = db.Emps.Find(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Emp e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            Emp e = db.Emps.Find(id);
            db.Emps.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}