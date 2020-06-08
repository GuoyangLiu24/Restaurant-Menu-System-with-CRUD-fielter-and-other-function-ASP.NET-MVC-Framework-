using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipes.Controllers
{
    public class OrdersController : Controller
    {
        
        private FakeRepositoryItems items = new FakeRepositoryItems();
        private IOrdersRepository repositoryO;
        private IOrderDetailRepository repositoryOD;
        
        // andrea
        // GET: /<controller>/

        public OrdersController(IOrdersRepository orderRepo, IOrderDetailRepository orderDetailRepo)
        {

            repositoryOD = orderDetailRepo;
            repositoryO = orderRepo;
        }

        public ViewResult List()
        {
            return View(repositoryO.Orders);
        }
        public ViewResult ListCustomers()
        {
            return View();
          //  return View(orderRepository.Customers);
        }
        public ViewResult ReviewPayment()
        {
            double total = 0;
            if (AccountController.login == null)
                return View("../Account/Login");
            Orders order = new Orders();
            order.CustomerID = AccountController.login;
            order.TotalPrice = total;
            int orderNumber = repositoryO.SaveOrder(order);
          
            foreach (OrderDetail item in items.Items)
            {
                item.OrderId = orderNumber;
                 total += item.calculate();
                repositoryOD.SaveOrderDetail(item);
                
                
            }
            items.RemoveAll();
            order.ID = orderNumber;
            order.TotalPrice = total;
            repositoryO.SaveOrder(order);
            FakeRepositoryOrder Orders = new FakeRepositoryOrder();
            var fakeOrders = repositoryO.Orders.Where(r => r.CustomerID.Contains(AccountController.login));
            foreach (Orders O in fakeOrders)
            {
                Orders.AddItem(O);
            }
            return View("../Order/ReviewPayment", Orders);
        }
        public ViewResult ReviewHistory()
        {
            
            FakeRepositoryOrder Orders = new FakeRepositoryOrder();
            var fakeOrders = repositoryO.Orders.Where(r => r.CustomerID.Contains(AccountController.login));
            foreach (Orders O in fakeOrders)
            {
                Orders.AddItem(O);
            }
            return View("../Order/ReviewPayment", Orders);
        }






        //[HttpPost]
        //public ViewResult CartAdd(string Id)
        //{
        //   items.AddItem(new Item(Id,1));
        //    //const string sessionKey = "amount";

        //    //var value = HttpContext.Session.GetString(sessionKey);
        //    //var itemId = Id.ToString();
        //    //var quantity = "1";
        //    //if (string.IsNullOrEmpty(value))
        //    //{
        //    //    value="1";



        //    //    HttpContext.Session.SetString(sessionKey, value);

        //    //    HttpContext.Session.SetString("Id", itemId);

        //    //    HttpContext.Session.SetString("Quantity", quantity);
        //    //}
        //    //else
        //    //{
        //    //    FakeRepositoryItems.AddItem(new Item(Id));
        //    //    int a = int.Parse(value);
        //    //    a += 1;
        //    //    value = a.ToString();
        //    //    HttpContext.Session.SetString(sessionKey, a.ToString()); ;

        //    //    HttpContext.Session.SetString("Id"+a.ToString(), itemId);

        //    //    HttpContext.Session.SetString("Quantity"+a.ToString(), quantity);
        //    //}
        //    return View("Index");
        //}
        public ViewResult ViewDetail(int Id)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();    
            var fakeOrderDetail = repositoryOD.OrderDetail.Where(r => r.OrderId ==Id);
            items.RemoveAll();
            foreach (OrderDetail O in fakeOrderDetail)
            {
                //orderDetails.Add(O);
                items.AddItem(O);
            }

            
            return View("../Order/OrderDetail", items);
        }
        public ViewResult DeleteRecipe(string Id)
        {
            items.RemoveItem(int.Parse(Id));

            return View("../Order/Cart", items);
        }
        public ViewResult UpdateCart(string Id, int quantity)
        {
            items.UpdateItem(int.Parse(Id), quantity);
            Console.WriteLine("id " + Id);
            Console.WriteLine("qantity " + quantity);
            
            //throw new Exception();
            return View("../Order/Cart", items);
        }


        [HttpPost]
        public ViewResult CartAdd(string Id, string quantity, string price)
        {
            items.AddItem(new OrderDetail(int.Parse(Id), int.Parse(quantity), double.Parse(price)));
            return View("../Order/Cart", items);
        }




    }
}
