using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_6
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IFullNameFactory _fullNameFactory;

        public CustomerService_6(ICustomerRepository customerRepository, IFullNameFactory fullNameFactory)
        {
            _customerRepository = customerRepository;
            _fullNameFactory = fullNameFactory;
        }

        /// <summary>
        /// We need to verify that save is called
        /// </summary>
        /// <param name="customercommand"></param>
        public void Create(CustomerCreateCommand customercommand)
        {
            Customer customer = new Customer(customercommand.FirstName, customercommand.LastName);

            customer.FullName = _fullNameFactory.From(customercommand.FirstName, customercommand.LastName);

            _customerRepository.Save(customer);
        }
    }
}
