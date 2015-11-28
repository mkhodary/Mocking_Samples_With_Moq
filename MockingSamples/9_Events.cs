using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_9
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailingRepository _mailingRepository;

        public CustomerService_9(ICustomerRepository customerRepository, IMailingRepository mailingRepository)
        {
            _customerRepository = customerRepository;
            _mailingRepository = mailingRepository;

            _customerRepository.NotifySalesTeam += _customerRepository_NotifySalesTeam;
        }

        private void _customerRepository_NotifySalesTeam(object sender, EventArgs e)
        {
            // We need to verify that this method is called when event raised by customer repository...
            _mailingRepository.NewCustomerMessage(e);
        }

        public void Create(CustomerCreateCommand createCommand)
        {
            var customer = new Customer(createCommand.FirstName, createCommand.LastName);

            _customerRepository.Save(customer);
        }
    }
}
