using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Models.ViewModels;

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
       
        private IRecipeRepository repository;
      
        public int PageSize = 4;

        private string searchInfo=SearchInfo.getSearchInfo();

        public ViewResult Index()
        {
           // public IEnumerable<Recipe> recipesForFilter = select catgory from repository.Recipes;
            return View();
        }
        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }
        public ViewResult RecipeList(int recipePage=1)
        {
           
            var recipes = from r in repository.Recipes select r;
            if (!string.IsNullOrEmpty(searchInfo))
            {
                recipes = repository.Recipes.Where(r => r.Name.Contains(searchInfo) ||
                                                   r.Ingredients.Contains(searchInfo) ||
                                                   r.Category.Contains(searchInfo) ||
                                                   r.Price.ToString().Contains(searchInfo));
                //||r.Yields.ToString().Contains(searchInfo));

            }


            return View(new RecipeListViewModel
            {
                Recipes = recipes
                    .OrderBy(r => r.Name)
                    .Skip((recipePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = recipePage,
                    ItemsPerPage = PageSize,
                    TotalItems = recipes.Count()
                }
            });

        }

        [HttpPost]
        public IActionResult RecipeList(string searchingString, int recipePage = 1) 
        {
            SearchInfo.setSearchInfo(searchingString);
            var recipes = from r in repository.Recipes select r;
            if (!string.IsNullOrEmpty(searchingString))
            {
                recipes = repository.Recipes.Where(r => r.Name.Contains(searchingString) ||
                                                   r.Ingredients.Contains(searchingString) ||
                                                   r.Category.Contains(searchingString) ||
                                                   r.Price.ToString().Contains(searchingString)); 
                                                   //||r.Yields.ToString().Contains(searchingString));
            }
            string filterItem = Request.Form["Category"].ToString();
            if (!string.IsNullOrEmpty(filterItem))
            {
                recipes = repository.Recipes.Where(r => r.Category.Contains(filterItem));
            }

            return View(new RecipeListViewModel {
                Recipes = recipes
                    .OrderBy(r => r.Name)
                    .Skip((recipePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = recipePage,
                    ItemsPerPage = PageSize,
                    TotalItems = recipes.Count()
                }
            });
        }

        public ViewResult ViewRecipe(int id)
        {
            return View(repository.Recipes.FirstOrDefault(x => x.RecipeID == id));
        }

        [HttpGet]
        public ViewResult ReviewRecipe()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ReviewRecipe(Review review)
        {
            if (ModelState.IsValid)
            {
                FakeRepositoryReviews.AddReview(review);
                return View("ReviewThanks", review);
            }
            else
            {
                return View();
            }
        }
        
    }

}
