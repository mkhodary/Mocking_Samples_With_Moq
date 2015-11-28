using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_1
    {
        private readonly ICustomerAddressBuilder _customerAddressBuilder;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService_1(ICustomerAddressBuilder customerAddressBuilder, ICustomerRepository customerRepository)
        {
            _customerAddressBuilder = customerAddressBuilder;
            _customerRepository = customerRepository;
        }

        public void Create(CustomerCreateCommand customercommand)
        {
            Customer customer = new Customer(customercommand.FirstName, customercommand.LastName);

            customer.MailingAddress = _customerAddressBuilder.From(customercommand);

            if (customer.MailingAddress == null)
            {
                throw new InvalidCustomerMailingAddressException();
            }

            _customerRepository.Save(customer);
        }
    }
}
