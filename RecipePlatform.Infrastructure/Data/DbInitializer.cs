using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecipePlatform.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
                return; 

            var categories = new Category[]
            {
                new Category { Name = "Breakfast" },
                new Category { Name = "Lunch" },
                new Category { Name = "Dinner" },
                new Category { Name = "Dessert" },
                new Category { Name = "Snacks" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // ingr
            var ingredients = new Ingredient[]
            {
                new Ingredient { Name = "Eggs" },
                new Ingredient { Name = "Flour" },
                new Ingredient { Name = "Milk" },
                new Ingredient { Name = "Sugar" },
                new Ingredient { Name = "Tomato" },
                new Ingredient { Name = "Chicken" },
                new Ingredient { Name = "Salt" },
                new Ingredient { Name = "Butter" }
            };
            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();

            // polzovateli
            var users = new User[]
            {
                new User { Username = "admin", PasswordHash = "admin123", Role = "Admin" },
                new User { Username = "customer", PasswordHash = "customer123", Role = "Customer" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            // rec
            var recipes = new Recipe[]
            {
                new Recipe { Title = "Pancakes", Description = "Fluffy breakfast pancakes.", CategoryId = categories.First(c => c.Name == "Breakfast").Id },
                new Recipe { Title = "Grilled Chicken", Description = "Juicy grilled chicken breast.", CategoryId = categories.First(c => c.Name == "Lunch").Id },
                new Recipe { Title = "Chocolate Cake", Description = "Rich and moist chocolate cake.", CategoryId = categories.First(c => c.Name == "Dessert").Id }
            };
            context.Recipes.AddRange(recipes);
            context.SaveChanges();

            // 
            var recipeIngredients = new RecipeIngredient[]
            {
                new RecipeIngredient { RecipeId = recipes.First(r => r.Title == "Pancakes").Id, IngredientId = ingredients.First(i => i.Name == "Eggs").Id },
                new RecipeIngredient { RecipeId = recipes.First(r => r.Title == "Pancakes").Id, IngredientId = ingredients.First(i => i.Name == "Flour").Id },
                new RecipeIngredient { RecipeId = recipes.First(r => r.Title == "Pancakes").Id, IngredientId = ingredients.First(i => i.Name == "Milk").Id },
                new RecipeIngredient { RecipeId = recipes.First(r => r.Title == "Chocolate Cake").Id, IngredientId = ingredients.First(i => i.Name == "Flour").Id },
                new RecipeIngredient { RecipeId = recipes.First(r => r.Title == "Chocolate Cake").Id, IngredientId = ingredients.First(i => i.Name == "Sugar").Id },
                new RecipeIngredient { RecipeId = recipes.First(r => r.Title == "Chocolate Cake").Id, IngredientId = ingredients.First(i => i.Name == "Butter").Id }
            };
            context.RecipeIngredients.AddRange(recipeIngredients);
            context.SaveChanges();
        }
    }
}
