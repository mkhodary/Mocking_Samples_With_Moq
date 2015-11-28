using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_7
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IStatusFactory _statusFactory;

        public CustomerService_7(ICustomerRepository customerRepository, IStatusFactory statusFactory)
        {
            _customerRepository = customerRepository;
            _statusFactory = statusFactory;
        }

        public void Create(CustomerCreateCommand createCommand)
        {
            var customer = new Customer(createCommand.FirstName, createCommand.LastName);

            customer.Status = _statusFactory.From(createCommand);

            if (customer.Status == CustomerStatusEnum.Platinum)
            {
                _customerRepository.SaveSpecial(customer);
            }
            else
            {
                _customerRepository.Save(customer);
            }
        }
    }
}
