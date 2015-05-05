using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using What2Eat.DAL;
using What2Eat.Models;

namespace What2Eat.Controllers
{
    public class UserController : Controller
    {
        private W2EContext db = new W2EContext();
        // GET: UserAtributes
        public ActionResult Index()
        {
            return View(db.Users.ToListAsync());
        }

        // GET: UserAtributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", user);
        }

        // GET: UserAtributes/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: UserAtributes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Login,Password,Target,Atributes")] User user)
        {
           if(ModelState.IsValid)
           {
               db.Users.Add(user);
               db.SaveChanges();
               return Json(new {succses = true});
           }
            return PartialView("_Create", user);
        }

        // GET: UserAtributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", user);
        }

        // POST: UserAtributes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: UserAtributes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAtributes/Delete/5
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
