using System;
using System.Collections.Generic;
using System.Data.Entity;
using What2Eat.Enums;
using What2Eat.Models;

namespace What2Eat.DAL
{
        public class W2EInitializer : DropCreateDatabaseAlways<W2EContext>  // niszczy baze przy kazdym uruchomieniu, do zmienienia pozniej
        {
            protected override void Seed(W2EContext context)
            {
                SeedW2ElData(context);
                base.Seed(context);
            }

            private void SeedW2ElData(W2EContext context) // wypelnienie danymi poczatkowymi
            {
                var meals = new List<Meal>();
                var products = new List<Product>();

                var mealProducts = new List<MealProduct>();

                var p1 = new Product()
                {
                    Name = "Jajka",
                    CarbonitesPer100g = 20,
                    ProteinsPer100g = 30,
                    FatPer100g = 10,
                    KcalPer100g = 300,
                    ProductKind = ProductKind.Nabial
                };
                var p2 = new Product()
                {
                    Name = "Ciemny chleb",
                    CarbonitesPer100g = 50,
                    ProteinsPer100g = 10,
                    FatPer100g = 5,
                    KcalPer100g = 350,
                    ProductKind = ProductKind.Pieczywo
                };
                var p3 = new Product()
                {
                    Name = "Sok pomaranczowy",
                    CarbonitesPer100g = 15,
                    ProteinsPer100g = 2,
                    FatPer100g = 1,
                    KcalPer100g = 100,
                    ProductKind = ProductKind.Nabial
                };
                products.Add(p1);
                products.Add(p2);
                products.Add(p3);

                mealProducts.Add(new MealProduct()
                {
                    Product = p1,
                    BaseWaight = 100
                });
                mealProducts.Add(new MealProduct()
                {
                    Product = p2,
                    BaseWaight = 200
                });
                mealProducts.Add(new MealProduct()
                {
                    Product = p3,
                    BaseWaight = 250
                });
                meals.Add(new Meal()
                {
                    MealCategory = MealCategory.breakfast,
                    Name = "Jaja z chlebem",
                    Products = mealProducts
                });

                meals.ForEach(a => context.Meals.Add(a));
                context.SaveChanges();
            }

        } 
    }