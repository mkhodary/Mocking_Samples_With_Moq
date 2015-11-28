using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples
{
    public class CustomerService_8
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IApplicationSettings _applicationSettings;

        public CustomerService_8(ICustomerRepository customerRepository, IApplicationSettings applicationSettings)
        {
            _customerRepository = customerRepository;
            _applicationSettings = applicationSettings;
        }

        public void Create(CustomerCreateCommand createCommand)
        {
            var customer = new Customer(createCommand.FirstName, createCommand.LastName);

            // We need to verify that this property is set...
            _customerRepository.TimeZone = TimeZone.CurrentTimeZone.StandardName;

            _customerRepository.Save(customer);
        }

        /// <summary>
        /// Create a customer with assigned workstation...
        /// </summary>
        /// <param name="createCommand"></param>
        public void CreateAssignedWorkStation(CustomerCreateCommand createCommand)
        {
            var customer = new Customer(createCommand.FirstName, createCommand.LastName);

            // We need to verify that this property is get from workstation Id...
            customer.WorkStationId = _applicationSettings.WorkStationId;

            _customerRepository.Save(customer);
        }

        /// <summary>
        /// Create a customer with assigned workstation...
        /// </summary>
        /// <param name="createCommand"></param>
        public void CreateComplexAssignedWorkStation(CustomerCreateCommand createCommand)
        {
            var customer = new Customer(createCommand.FirstName, createCommand.LastName);

            // We need to verify that this property is get from workstation Id in application settings...
            int? workstationId = _applicationSettings
                .SystemConfiguration
                .AuditingInformation
                .WorkStationId;

            if (!workstationId.HasValue)
            {
                throw new InvalidWorkStationIdException();
            }

            customer.WorkStationId = workstationId.Value;

            _customerRepository.Save(customer);
        }
    }
}
