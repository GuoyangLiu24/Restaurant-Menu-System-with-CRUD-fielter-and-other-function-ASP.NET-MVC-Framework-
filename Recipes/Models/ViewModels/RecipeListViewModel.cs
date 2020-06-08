using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipes.Models;

namespace Recipes.Models.ViewModels
{
    public class RecipeListViewModel
    {
        public enum CategoryType
        {
            MainCourse,
            Salads,
            Soup,
            Drinks,
            Dessert
        }
        public IEnumerable<Recipe> Recipes { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string SearchInfo { get; set; }
    }
}
