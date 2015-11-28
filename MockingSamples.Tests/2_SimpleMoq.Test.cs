using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_2_Test
    {
        [Test]
        public void Create_ValidCreateCommand_CustomerServiceRepository_Should_be_Called()
        {
            // Arrange
            var createCommand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockedRepository = new Mock<ICustomerRepository>();
            mockedRepository.Setup(x=> x.Save(It.IsAny<Customer>()));

            CustomerService_2 customerService =
                new CustomerService_2(mockedRepository.Object);

            // Act
            customerService.Create(createCommand);

            // Assert
            mockedRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [Test]
        public void Create_ValidCreateCommandsList_CustomerServiceRepository_Should_be_Called()
        {
            // Arrange
            List<CustomerCreateCommand> customerCreateCommandList =
                new List<CustomerCreateCommand>()
                {
                    new CustomerCreateCommand()
                        {
                            FirstName = "Mohamed",
                            LastName = "Ahmed"
                        },
                        new CustomerCreateCommand()
                        {
                            FirstName = "Adel",
                            LastName = "Mostafa"
                        },
                        new CustomerCreateCommand()
                        {
                            FirstName = "Ahmed",
                            LastName = "Kamal"
                        }
                };

            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            MockingSamples.CustomerService_2 customerService = new MockingSamples.CustomerService_2(mockRepository.Object);

            // Act
            customerService.Create(customerCreateCommandList);

            // Assert
            mockRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Exactly(customerCreateCommandList.Count));
        }
    }
}
