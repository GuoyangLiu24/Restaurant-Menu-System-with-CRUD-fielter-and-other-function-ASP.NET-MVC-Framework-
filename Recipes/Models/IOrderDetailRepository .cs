using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{ // andrea
   public interface IOrderDetailRepository
    {
        IQueryable<OrderDetail> OrderDetail { get; }
        void SaveOrderDetail(OrderDetail orderDetail);

        OrderDetail DeleteOrder(int orderDetailID);


    }
}
