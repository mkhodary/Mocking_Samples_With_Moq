using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_5_Test
    {
        [Test]
        public void Create_ValidCommand_Each_Customer_Should_Be_Assigned_An_Id()
        {
            //Arrange
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
            var mockIdFactory = new Mock<IIdFactory>();

            var i = 1;
            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockIdFactory.Setup(x => x.Create())
                .Returns(() => i)
                .Callback(() => i++);

            CustomerService_5 customerService = new CustomerService_5(
                mockRepository.Object,
                mockIdFactory.Object
                );

            //Act
            customerService.Create(customerCreateCommandList);

            //Assert
            mockRepository.Verify(x => x.Save(It.IsAny<Customer>()),Times.Exactly(customerCreateCommandList.Count));
            mockIdFactory.Verify(x => x.Create(), Times.Exactly(customerCreateCommandList.Count));
        }
    }
}
