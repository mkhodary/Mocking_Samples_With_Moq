using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_5
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IIdFactory _idFactory;

        public CustomerService_5(ICustomerRepository customerRepository, IIdFactory idFactory)
        {
            _customerRepository = customerRepository;
            _idFactory = idFactory;
        }

        /// <summary>
        /// We need to verify that save is called
        /// </summary>
        /// <param name="customercommand"></param>
        public void Create(IEnumerable<CustomerCreateCommand> customercommandsList)
        {
            foreach (var customercommand in customercommandsList)
            {
                Customer customer = new Customer(customercommand.FirstName, customercommand.LastName);

                // We need different Ids from create method...
                customer.Id = _idFactory.Create();

                _customerRepository.Save(customer);
            }
        }
    }
}
