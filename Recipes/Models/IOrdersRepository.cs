using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{ // andrea
   public interface IOrdersRepository
    {
        IQueryable<Orders> Orders { get; }
        
        int SaveOrder(Orders orders);

        Orders DeleteOrder(int orderID);

    }
}
