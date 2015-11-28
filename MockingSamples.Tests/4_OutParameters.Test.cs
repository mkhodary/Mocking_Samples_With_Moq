using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_4_Test
    {
        [Test]
        public void Create_ValidCommand_Client_Should_Be_Persisted()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            MailingAddress mailingAddress = new MailingAddress() { Street = "Test Street", StreetNumber = 10 };

            var mockRepository = new Mock<ICustomerRepository>();
            var mockMailingAddressFactory = new Mock<IMailingAddressFactory>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            mockMailingAddressFactory.Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress))
                .Returns(true);

            CustomerService_4 customerService = new CustomerService_4(mockMailingAddressFactory.Object, mockRepository.Object);
            //Act
            customerService.Create(createCommmand);

            //Assert
            mockRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }
    }
}
