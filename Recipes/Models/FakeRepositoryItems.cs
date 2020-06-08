using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class FakeRepositoryItems
    {
        private static List<OrderDetail> items = new List<OrderDetail>();
        public IEnumerable<OrderDetail> Items
        {
            get
            {
                return items;
            }
        }
        public void AddItem(OrderDetail item)
        {
            foreach (var s in items)
            {
                if (s.ReceiptId == item.ReceiptId)
                {

                    item.Quantity = s.Quantity + item.Quantity;
                    items.Remove(s);

                    break;
                }



            }
            items.Add(item);

        }
        public void RemoveAll()
        {

            items = new List<OrderDetail>();




        }

        public void UpdateItem(int Id,int quantity)
        {
            foreach (var s in items)
            {
                if (s.ReceiptId == Id)
                {

                    s.Quantity = quantity;
                   

                    break;
                }



            }
           

        }



        public void RemoveItem(int id)
        {
            foreach (var s in items)
            {
                if (s.ReceiptId == id)
                {

                    
                    items.Remove(s);

                    break;
                }



            }

        }
    }
}
