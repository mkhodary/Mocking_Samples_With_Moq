using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_91
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailingAddressFactory _mailingAddressFactory;

        public CustomerService_91(ICustomerRepository customerRepository, IMailingAddressFactory mailingAddressFactory)
        {
            _customerRepository = customerRepository;
            _mailingAddressFactory = mailingAddressFactory;
        }

        public void Create(CustomerCreateCommand customercommand)
        {
            Customer customer = new Customer(customercommand.FirstName, customercommand.LastName);

            ICustomerAddressBuilder customerAddressBuilder = _mailingAddressFactory.GetAddressBuilder(true);

            // we need to verify that from is called in customer address builder...
            customer.MailingAddress = customerAddressBuilder.From(customercommand);

            _customerRepository.Save(customer);
        }
    }
}
