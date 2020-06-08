using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }

        void SaveCustomer(Customer customer);

    }
}
