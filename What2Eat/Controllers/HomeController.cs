using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using What2Eat.DAL;
using What2Eat.Helpers;
using What2Eat.Models;

namespace What2Eat.Controllers
{
    public class HomeController : Controller
    {
        private W2EContext db = new W2EContext();
        public ActionResult Index()
        {             
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserAtributes atr, double ActivityLevel)
        {
            var model = new UserCharacteristicViewModel() {
                Bmi = Bmi.ComputeBmi(atr.Weight, atr.Height),
                Bmr = Bmr.ComputeBmr(atr.Weight,atr.Height,atr.Age,atr.Sex,ActivityLevel),
                UserAtributes = atr
            };

            return RedirectToAction("MealChoice",model);
        }

        public ActionResult MealChoice(UserCharacteristicViewModel model)
        {
            if (model.MealCategory != null)
            {
                Random rnd = new Random();
                var partialModel = new Meal();
                var validMeals = db.Meals.Where(x => x.MealCategory == model.MealCategory).ToArray();
                var selectedMeal = validMeals[(rnd.Next(validMeals.Count()))];

                partialModel.Name = selectedMeal.Name;
                partialModel.MealCategory = selectedMeal.MealCategory;





            }
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}