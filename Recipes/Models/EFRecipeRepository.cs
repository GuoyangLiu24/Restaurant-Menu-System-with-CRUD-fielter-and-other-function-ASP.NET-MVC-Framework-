using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;
        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeID == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes.FirstOrDefault(p => p.RecipeID == recipe.RecipeID);
                if(recipeEntry != null)
                {
                    recipeEntry.Name = recipe.Name;
                    recipeEntry.Category = recipe.Category;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    //recipeEntry.Steps = recipe.Steps;
                    //recipeEntry.Yields = recipe.Yields;
                    recipeEntry.Price = recipe.Price;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(p => p.RecipeID == recipeID);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }
            return recipeEntry;
        }
    }
}
