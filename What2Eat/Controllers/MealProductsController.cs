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
    public class MealProductsController : Controller
    {
        private W2EContext db = new W2EContext();

        // GET: MealProducts
        public async Task<ActionResult> Index()
        {
            return View(await db.MealProducts.ToListAsync());
        }

        // GET: MealProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealProduct mealProduct = await db.MealProducts.FindAsync(id);
            if (mealProduct == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details",mealProduct);
        }

        // GET: MealProducts/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: MealProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MealProductId,BaseWaight")] MealProduct mealProduct)
        {
            if (ModelState.IsValid)
            {
                db.MealProducts.Add(mealProduct);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return PartialView("Create",mealProduct);
        }

        // GET: MealProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealProduct mealProduct = await db.MealProducts.FindAsync(id);
            if (mealProduct == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit",mealProduct);
        }

        // POST: MealProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MealProductId,BaseWaight")] MealProduct mealProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return PartialView("Edit",mealProduct);
        }

        // GET: MealProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealProduct mealProduct = await db.MealProducts.FindAsync(id);
            if (mealProduct == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete",mealProduct);
        }

        // POST: MealProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MealProduct mealProduct = await db.MealProducts.FindAsync(id);
            db.MealProducts.Remove(mealProduct);
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
