using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string UserName { get; set; }
        public string RecipeName { get; set; }
        [Required(ErrorMessage = "Please enter your comments here")]
        public string Comments { get; set; }

    }
}
