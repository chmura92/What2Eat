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
                var validMeals = db.Meals.Where(x => x.MealCategory == model.MealCategory).ToArray();
<<<<<<< HEAD
                if (validMeals.Any())
                {
                    var selectedMeal = validMeals[(rnd.Next(validMeals.Count()))];

                    double? baseKcal = 0;
                    double targetKcal = model.DayPercent/100.0*model.Bmr;
                    double ratio;
=======
                var selectedMeal = validMeals[(rnd.Next(validMeals.Count()))];
>>>>>>> 20732bca4fe5e14ed96e0c7d45028593b5aa6e3e

                double? baseKcal =0;
                double targetKcal = model.DayPercent/100.0 * model.Bmr;
                double ratio;

                foreach (var item in selectedMeal.Products)
                {
                    baseKcal += item.BaseWaight/100.0*item.Product.KcalPer100g;
                }

                ratio = (double) (targetKcal/baseKcal);
                var computedProducts = new List<ProductViewModel>();
                double totalP = 0;
                double totalC = 0;
                double totalF = 0;
                double totalK = 0;
                double totalW = 0;
                foreach (var item in selectedMeal.Products)
                {
                    double weight = (double) (item.BaseWaight*ratio);
                    var x = new ProductViewModel()
                    {
<<<<<<< HEAD
                        Name = selectedMeal.Name,
                        Products = computedProducts,
                        TotalCarbonites = Math.Round((totalC),2),
                        TotalFat = Math.Round((totalF),2),
                        TotalKcal = Math.Round((totalK),2),
                        TotalProteins = Math.Round((totalP),2),
                        TotalWeight = Math.Round((totalW),2)
=======
                        Name = item.Product.Name,
                        Carbonites = (double)item.Product.CarbonitesPer100g * weight/100,
                        Fat = (double)item.Product.FatPer100g * weight/100,
                        Proteins = (double)item.Product.ProteinsPer100g * weight/100,
                        Kcal = (double)item.Product.KcalPer100g * weight/100,
                        Weight = weight
>>>>>>> 20732bca4fe5e14ed96e0c7d45028593b5aa6e3e
                    };
                    computedProducts.Add(x);
                    totalW += x.Weight;
                    totalP += x.Proteins;
                    totalF += x.Fat;
                    totalC += x.Carbonites;
                    totalK += x.Kcal;
                }

                var partialModel = new MealViewModel
                {
                    Name = selectedMeal.Name,
                    Products = computedProducts,
                    TotalCarbonites = totalC,
                    TotalFat = totalF,
                    TotalKcal = totalK,
                    TotalProteins = totalP,
                    TotalWeight = totalW
                };

                return PartialView("_meal", partialModel);
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