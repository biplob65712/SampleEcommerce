using SampleCommerce.Models;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public class CustomerService: ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository; 

        }

        public ICollection<Customer> GetAll()
        {
            
            return _customerRepository.Get(); 
        }

        public Customer GetById(int id)
        {
            return  _customerRepository.GetFirstOrDefault(c=>c.Id == id); 

        }

        public Result Add(Customer customer)
        {
            var result = new Result();

            //code unique 
            var customerResult = _customerRepository.Get(cust => cust.Code == customer.Code );
            
            if(customerResult.Any())
            {
                result.IsSucceed = false;
                result.ErrorMessages.Add("Customer Already Exists with the same code");
            }

            //phone no unique
            var phoneResult = _customerRepository.Get(c => c.PhoneNo == customer.PhoneNo);

            if(phoneResult.Any())
            {
                result.IsSucceed = false;
                result.ErrorMessages.Add("Customer Already Exists with the same phone no. ");
            }


            if (result.ErrorMessages.Any())
            {
                return result;
            }


           var isSuccess = _customerRepository.Add(customer);

            if (isSuccess)
            {
                result.IsSucceed = true;
            }

            result.ErrorMessages.Add("Could not create customer!");

            return result; 
        }

        public Result Update(Customer customer)
        {
            var result = new Result();
            var isSuccess = _customerRepository.Update(customer);

            if (isSuccess)
            {
                result.IsSucceed = true;
            }

            result.ErrorMessages.Add("Could not update customer!");

            return result;
        }

        public Result Remove(Customer customer)
        {
            var result = new Result();
            var isSuccess = _customerRepository.Remove(customer);

            if (isSuccess)
            {
                result.IsSucceed = true;
            }

            result.ErrorMessages.Add("Could not remove customer!");

            return result;
        }
    }
}
