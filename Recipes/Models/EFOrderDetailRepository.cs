using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    
    public class EFOrderDetailRepository : IOrderDetailRepository
    {
        private ApplicationDbContext context;

        public EFOrderDetailRepository (ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<OrderDetail> OrderDetail => context.OrderDetail;
    

        public OrderDetail DeleteOrder(int orderDetailID)
        {
            OrderDetail orderEntry = context.OrderDetail
              .FirstOrDefault(p => p.Id == orderDetailID);

            if (orderEntry != null)
            {
                context.OrderDetail.Remove(orderEntry);
                context.SaveChanges();
            }
            return orderEntry;
        }

        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail.Id == 0)
            {
                context.OrderDetail.Add(orderDetail);

            }
            else
            {
                OrderDetail orderEntry = context.OrderDetail.FirstOrDefault(p => p.Id == orderDetail.Id);
                if (orderEntry != null)
                {
                    orderEntry.Price = orderDetail.calculate();
                    orderEntry.Quantity = orderDetail.Quantity;
                    orderEntry.OrderId = orderDetail.OrderId;
                    orderEntry.ReceiptId = orderDetail.ReceiptId;


                }
            }

            context.SaveChanges();
        
    }
    }
}
