using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class Customer
    {
        
        [System.ComponentModel.DataAnnotations.Key]
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public string TwoFactAuthenticationCode { get; set; }
        public  bool IsAuthenticationFinish { get; set; }
            

    }
}
