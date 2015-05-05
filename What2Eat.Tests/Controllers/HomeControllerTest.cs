using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using What2Eat;
using What2Eat.Controllers;
using What2Eat.DAL;
using What2Eat.Enums;
using What2Eat.Models;

namespace What2Eat.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Contact()
        {
            /*private W2EContext db = new W2EContext();
            var model = new UserCharacteristicViewModel() {Bmi = 20, Bmr = 2000, MealCategory = MealCategory.breakfast};

            Random rnd = new Random();
            var partialModel = new Meal();
            var validMeals = db.Meals.Where(x => x.MealCategory == model.MealCategory);
            var selectedMeal = validMeals.ElementAt(rnd.Next(validMeals.Count()));

            partialModel.Name = selectedMeal.Name;
            partialModel.MealCategory = selectedMeal.MealCategory;

            // Act*/
        }
    }
}
