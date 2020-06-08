using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Recipes.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "andrea88",
                        Phone="416-555-5588",
                        Email="andrea.xiu@gmail.com",
                        Password="aaaaa",
                        IsAdmin=true
                        

                    },
                    new Customer
                    {
                        Name = "andrea1",
                        Phone = "416-555-5552",
                        Email = "andrea1.xiu@gmail.com",
                        Password = "aaaaaeeee",
                        IsAdmin = false
                    }

                    );
                context.SaveChanges();
            }


            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Orders
                    {
                        CustomerID = "andrea",
                        TotalPrice = 96

                    },
                    new Orders
                    {
                        CustomerID = "andrea2",
                        TotalPrice = 96

                    }

                    );
                context.SaveChanges();
            }


            if (!context.Recipes.Any())
            {

                
                context.Recipes.AddRange(
                    new Recipe
                    {                      
                        Name = "Açaí Bowl",
                        Category = "Dessert",
                        Ingredients = "3 (3.5-ounce) frozen açaí packs,2 medium bananas,1 c. frozen blueberries,1 1/2 c. almond milk,Pinch of kosher salt",
                        Price = 15
                    },
                    new Recipe
                    {

                        Name = "Strawberry Smoothie",
                        Category = "Dessert",
                        Ingredients = "160g ripe strawberries,160g baby spinach,1 small avocado",

                        Price = 5
                    },
                    new Recipe
                    {

                        Name = "Breakfast smoothie",
                        Category = "Dessert",
                        Ingredients = "1 banana,1 tbsp porridge oats,80g soft fruit,150ml milk",

                        Price = 5
                    },
                    new Recipe
                    {

                        Name = "Sunshine smoothie",
                        Category = "Dessert",
                        Ingredients = "500ml carrot juice,200g pineapple,2 bananas",

                        Price = 5
                    },
                    new Recipe
                    {

                        Name = "Kale smoothie",
                        Category = "Dessert",
                        Ingredients = "2 handfuls kale,½ avocado,½ lime,1 tbsp cashew nuts",

                        Price = 5
                    },
                    new Recipe
                    {

                        Name = "Coconut & banana smoothie",
                        Category = "Dessert",
                        Ingredients = "100g coconut yogurt,3 tbsp milk,2 tsp baobab powder,1 small ripe banana",

                        Price = 5
                    },
                    new Recipe
                    {

                        Name = "Turmeric smoothie bowl",
                        Category = "Dessert",
                        Ingredients = "10cm/4in fresh turmeric,3 tbsp coconut milk yogurt,2 bananas",

                        Price = 5
                    },
                    new Recipe
                    {

                        Name = "Cantaloupe Breakfast Bowls",
                        Category = "MainCourse",
                        Ingredients = "1 cantaloupe, halved,1 1/2 c. almond milk,1 c. frozen raspberries,1 banana, sliced into coin,1/2 c. frozen pineapple",

                        Price = 20
                    },
                    new Recipe
                    {

                        Name = "Green breakfast smoothie",
                        Category = "MainCourse",
                        Ingredients = "1 handful spinach,100g broccoli floret,1 banana",

                        Price = 20
                    },
                    new Recipe
                    {

                        Name = "Vegan smoothie",
                        Category = "MainCourse",
                        Ingredients = "100ml (¼ tall glass) cherry,1 cherry soya yogurt,2 tbsp porridge oat",

                        Price = 20
                    },
                    new Recipe
                    {

                        Name = "Creamy mango & coconut smoothie",
                        Category = "MainCourse",
                        Ingredients = "200ml (½ tall glass) coconut milk,1 banana",

                        Price = 20
                    },
                new Recipe
                {

                    Name = "Elise's Green Smoothie Bowl",
                    Category = "Drinks",
                    Ingredients = "½ cup almond milk,1 banana frozen,1 Medjool date pitted,1 tablespoon almond butter",

                    Price = 10
                },
                new Recipe
                {

                    Name = "Vanilla Chai Superfood Smoothie Bowl",
                    Category = "Drinks",
                    Ingredients = "½ cup almond milk,1 banana frozen,1 Medjool date pitted,1 tablespoon almond butter",

                    Price = 10
                },
                new Recipe
                {

                    Name = "Detox Protein Smoothie Bowl",
                    Category = "Drinks",
                    Ingredients = "½ cup almond milk,1 banana frozen,1 Medjool date pitted,1 tablespoon almond butter",

                    Price = 10
                },
                new Recipe
                {

                    Name = "Carrot Oatmeal Smoothie Bowl",
                    Category = "Salads",
                    Ingredients = "½ cup almond milk,1 banana frozen,1 Medjool date pitted,1 tablespoon almond butter",

                    Price = 10
                },
                new Recipe
                {

                    Name = "Dark Chocolate Peanut Butter Smoothie Bowl",
                    Category = "Salads",
                    Ingredients = "½ cup almond milk,1 banana frozen,1 Medjool date pitted,1 tablespoon almond butter",

                    Price = 10
                }
                );


                context.SaveChanges();

            }
        }
    }
}
