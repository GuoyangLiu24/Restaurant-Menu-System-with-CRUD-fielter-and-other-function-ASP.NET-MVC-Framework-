using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ReceiptId { get; set; }
        public int OrderId { get; set; }

        public OrderDetail()
        {
            Id = 0;
        }

        public OrderDetail(int id)
        {

            Quantity = 1;
            Price = 0;

        }
        public OrderDetail(int id, double price, int quan, int receiptId, int orderId )
        {
            Id = 0;
            ReceiptId = id;
            Quantity = quan;
            Price = price;

        }
        public OrderDetail(int id, int quan, double price)
        {
            Id = 0;
            ReceiptId = id;
            Quantity = quan;
            Price = price;
        }
        public double calculate()
        {
            return Price * Quantity * 0.87;
        }
    }
}
