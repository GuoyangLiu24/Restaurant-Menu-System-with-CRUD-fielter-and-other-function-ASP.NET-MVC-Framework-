using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Models.ViewModels;

namespace Recipes.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRecipeRepository repository;

        public int PageSize = 4;

        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(int recipePage= 1)
        {
            return View(new RecipeListViewModel
            {
                Recipes = repository.Recipes
                    .OrderBy(r => r.Name)
                    .Skip((recipePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = recipePage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Recipes.Count()
                }
            });
        }

        public ViewResult CreateRecipe() => View("EditRecipe", new Recipe());

        [HttpPost]
        public IActionResult DeleteRecipe(int RecipeID)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(RecipeID);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted!";
            }

            return RedirectToAction("Index");
        }
        public ViewResult EditRecipe(int RecipeID)
        {
            return View(repository.Recipes.FirstOrDefault(x => x.RecipeID == RecipeID));
        }

        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(recipe);
            }
        }
       

        
        
    }
}