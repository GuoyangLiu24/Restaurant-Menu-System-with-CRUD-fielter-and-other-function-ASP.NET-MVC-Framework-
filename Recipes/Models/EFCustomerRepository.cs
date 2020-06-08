using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext context;

        public EFCustomerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Customer> Customers => context.Customers;
        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerID == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customer customerEntry = context.Customers.FirstOrDefault(p => p.CustomerID == customer.CustomerID);
                if (customerEntry != null)
                {
                    customerEntry.Name = customer.Name;
                    customerEntry.Email = customer.Email;
                }
            }
            context.SaveChanges();
        }
    }
}
