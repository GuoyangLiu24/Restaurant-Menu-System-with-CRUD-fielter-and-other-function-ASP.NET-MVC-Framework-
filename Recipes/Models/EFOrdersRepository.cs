using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    
    public class EFOrdersRepository : IOrdersRepository
    {
        private ApplicationDbContext context;

        public EFOrdersRepository (ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Orders> Orders => context.Orders;

        public Orders DeleteOrder(int orderID)
        {
            Orders orderEntry = context.Orders
                .FirstOrDefault(p => p.ID == orderID);

            if (orderEntry != null)
            {
                context.Orders.Remove(orderEntry);
                context.SaveChanges();
            }
            return orderEntry;
        }

        public int SaveOrder(Orders order)
        {
            if (order.ID == 0)
            {
                context.Orders.Add(order);
               
            }
            else
            {
                Orders orderEntry = context.Orders.FirstOrDefault(p => p.ID == order.ID);
                if (orderEntry != null)
                {
                    orderEntry.CustomerID = order.CustomerID;
                    orderEntry.TotalPrice = order.TotalPrice;
                    orderEntry.Oderdate = System.DateTime.Now;
                    context.SaveChanges();
                    return orderEntry.ID;
                }
            }

            context.SaveChanges();
            return context.Orders.Last().ID;
        }
    }
}
