using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public DateTime Oderdate { get; set; }
        public string CustomerID { get; set; }
        public double TotalPrice { get; set; }


        public Orders()
        {
            ID = 0;
            Oderdate = System.DateTime.Now;
            
        }
        public Orders(int id, DateTime orderDate, string customer,double totalPrice)
        {
            ID = id;
            CustomerID = customer;
            TotalPrice = totalPrice;
            Oderdate = System.DateTime.Now;

        }
    }
}
// andrea