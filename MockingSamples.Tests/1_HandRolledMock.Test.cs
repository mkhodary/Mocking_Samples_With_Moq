using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class HandRolledMock
    {
        [Test]
        public void Create_ValidMailAddress_ShouldSave()
        {
            // Arrange
            var createCommmand = new CustomerCreateCommand() {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var customerAddressBuilder = new MockedCustomerAddressBuilder();
            var customerRepository = new MockedCustomerRepository();

            CustomerService_1 customerService = new CustomerService_1(customerAddressBuilder, customerRepository);

            // Act
            customerService.Create(createCommmand);

            // Assert
            Assert.IsTrue(customerRepository.IsSaveCalled);
        }
    }

    public class MockedCustomerRepository : ICustomerRepository
    {
        public MockedCustomerRepository()
        {
            IsSaveCalled = false;
        }

        public void Save(Customer customer)
        {
            IsSaveCalled = true;
        }

        public bool IsSaveCalled
        {
            get;
            set;
        }

        public void SaveSpecial(Customer customer)
        {
            throw new NotImplementedException();
        }


        public string TimeZone
        {
            get;
            set;
        }


        public event EventHandler NotifySalesTeam;
    }

    public class MockedCustomerAddressBuilder : ICustomerAddressBuilder
    {
        public string From(CustomerCreateCommand customercommand)
        {
            return string.Format("{0}.{1}@itworx.com", customercommand.FirstName, 
                customercommand.LastName);
        }
    }

}
