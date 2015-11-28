using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_4
    {
        private readonly IMailingAddressFactory _mailingAddressFactory;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService_4(IMailingAddressFactory mailingAddressFactory, ICustomerRepository customerRepository)
        {
            _mailingAddressFactory = mailingAddressFactory;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// We need to verify that save is called
        /// </summary>
        /// <param name="customercommand"></param>
        public void Create(CustomerCreateCommand customercommand)
        {
            Customer customer = new Customer(customercommand.FirstName, customercommand.LastName);
            customer.MailingAddress = customercommand.MailingAddress;

            MailingAddress mailingAddress;

            // We need to mock the output parameter to continue testing...
            bool mailingAddressSuccessfullyCreated = _mailingAddressFactory.TryParse(customer.MailingAddress, out mailingAddress);

            if (!mailingAddressSuccessfullyCreated)
            {
                throw new InvalidCustomerMailingAddressException();
            }

            customer.DetailedMailingAddress = mailingAddress;

            _customerRepository.Save(customer);
        }
    }
}
