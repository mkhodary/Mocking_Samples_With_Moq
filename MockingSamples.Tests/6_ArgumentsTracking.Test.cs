using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_6_Test
    {
        [Test]
        public void Create_ValidCommand_Verfiy_Full_Name_Factory_Called_With_Valid_Parameters()
        {
            // Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockFullNameFactory = new Mock<IFullNameFactory>();

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockFullNameFactory.Setup(x=> x.From(It.IsAny<string>(), It.IsAny<string>()));

            CustomerService_6 customerService = new CustomerService_6(mockCustomerRepository.Object,
                mockFullNameFactory.Object);
            // Act

            customerService.Create(createCommmand);

            // Assert
            mockFullNameFactory.Verify(
                x => x.From(
                    It.Is<string>(fn => fn.Equals(createCommmand.FirstName)),
                    It.Is<string>(fn => fn.Equals(createCommmand.LastName))
                    )
                );
        }
    }
}
