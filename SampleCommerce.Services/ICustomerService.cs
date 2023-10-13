using SampleCommerce.Models;
using SampleCommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public interface ICustomerService
    {
        ICollection<Customer> GetAll();
        Customer GetById(int id);

        Result Add(Customer customer);

        Result Update(Customer customer);

        Result Remove(Customer customer);
    }
}
