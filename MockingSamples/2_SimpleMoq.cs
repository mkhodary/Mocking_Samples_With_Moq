using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_2
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService_2(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(CustomerCreateCommand customercommand)
        {
            Customer customer = new Customer(customercommand.FirstName, customercommand.LastName);

            _customerRepository.Save(customer);
        }

        public void Create(List<CustomerCreateCommand> customerCreateCommandsList)
        {
            foreach (CustomerCreateCommand customerCommand in customerCreateCommandsList)
            {
                _customerRepository.Save(new Customer(customerCommand.FirstName, customerCommand.LastName));
            }
        }
    }
}
