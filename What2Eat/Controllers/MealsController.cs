using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using What2Eat.DAL;
using What2Eat.Models;

namespace What2Eat.Controllers
{
    public class MealsController : Controller
    {
        private W2EContext db = new W2EContext();

        // GET: Meals
        public async Task<ActionResult> Index()
        {
            return View(await db.Meals.ToListAsync());
        }

        // GET: Meals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = await db.Meals.FindAsync(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details",meal);
        }

        // GET: Meals/Create
        public ActionResult Create()
        {
            var model = new AddMealViewModel();
            model.AllProducts = db.Products.ToArray();
            return PartialView("Create",model);
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddMealViewModel aMeal)
        {
            if (ModelState.IsValid)
            {
                var meal = new Meal();
                var products = new List<MealProduct>();
                meal.MealCategory = aMeal.MealCategory;
                meal.Name = aMeal.Name;

                if (aMeal.MP1 != null && aMeal.Product1 != null)
                {
                    var p1 = new MealProduct() { Product = db.Products.Find(aMeal.Product1), BaseWaight = aMeal.MP1 };
                   // db.MealProducts.Add(p1);
                    products.Add(p1);
                    //db.SaveChanges();
                }
                if (aMeal.MP2 != null && aMeal.Product2 != null)
                {
                    var p1 = new MealProduct() { Product = db.Products.Find(aMeal.Product2), BaseWaight = aMeal.MP2 };
                    products.Add(p1);
                }
                if (aMeal.MP3 != null && aMeal.Product3 != null)
                {
                    var p1 = new MealProduct() { Product = db.Products.Find(aMeal.Product3), BaseWaight = aMeal.MP3 };
                    products.Add(p1);
                }
                if (aMeal.MP4 != null && aMeal.Product4 != null)
                {
                    var p1 = new MealProduct() { Product = db.Products.Find(aMeal.Product4), BaseWaight = aMeal.MP4 };
                    products.Add(p1);
                }
                meal.Products = products;
                db.Meals.Add(meal);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
        

             return PartialView("Create",aMeal);
        }

        // GET: Meals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = await db.Meals.FindAsync(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit",meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MealId,Name,MealCategory")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return PartialView("Edit",meal);
        }

        // GET: Meals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = await db.Meals.FindAsync(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete",meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Meal meal = await db.Meals.FindAsync(id);
            db.Meals.Remove(meal);
            await db.SaveChangesAsync();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
