using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using What2Eat.Helpers;
using What2Eat.Models;

namespace What2Eat.Controllers
{
    public class HomeController : Controller
    {
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
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}