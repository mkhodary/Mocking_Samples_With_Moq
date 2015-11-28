using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_91_Test
    {
        [Test]
        public void Verify_That_MailingAddress_Is_Get_From_customerAddressBuilder()
        {
            // Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockedCustomerRepository = new Mock<ICustomerRepository>();
            var mockedMailingFactory = new Mock<IMailingAddressFactory>() { DefaultValue = DefaultValue.Mock };

            var customerService = new CustomerService_91(mockedCustomerRepository.Object, mockedMailingFactory.Object);

            ICustomerAddressBuilder customerAddressBuilder = 
                mockedMailingFactory.Object.GetAddressBuilder(true);

            var mockedCustomerAddressBuilder = Mock.Get<ICustomerAddressBuilder>(customerAddressBuilder);
            
            // Act
            customerService.Create(createCommmand);

            // Assert
            mockedCustomerAddressBuilder.Verify(x => x.From(It.IsAny<CustomerCreateCommand>()));
        }
    }
}
