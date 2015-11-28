using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_3_Test
    {
        [Test]
        public void Create_ValidCommand_Verify_That_Save_Is_Called()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerCreateCommand>()))
                .Returns("mail@mail.com");

            CustomerService_3 customerService = new CustomerService_3(mockAddressBuilder.Object, mockRepository.Object);
            //Act
            customerService.Create(createCommmand);

            //Assert
            mockRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [Test]
        [ExpectedException(typeof(InvalidCustomerMailingAddressException))]
        public void Create_ValidCommand_If_Customer_Has_No_Mailing_Address()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerCreateCommand>()))
                .Returns(() => null);

            CustomerService_3 customerService = new CustomerService_3(mockAddressBuilder.Object, mockRepository.Object);
            //Act
            customerService.Create(createCommmand);

            //Assert
        }
    }
}
