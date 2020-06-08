using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class FakeRepositoryOrder
    {
        private static List<Orders> orders = new List<Orders>();
        public IEnumerable<Orders> Orders
        {
            get
            {
                return orders;
            }
        }

        public void AddItem(Orders order)
        {
           
            orders.Add(order);

        }




    }
}
