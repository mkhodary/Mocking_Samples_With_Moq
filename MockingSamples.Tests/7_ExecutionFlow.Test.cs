using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_7_Test
    {
        [Test]
        public void Create_ValidCommand_Save_Special_If_Customer_Platinum()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockSatusFactory = new Mock<IStatusFactory>();

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockSatusFactory.Setup(x => x.From(It.IsAny<CustomerCreateCommand>()))
                .Returns(CustomerStatusEnum.Platinum);

            CustomerService_7 customerService = new CustomerService_7(
                mockCustomerRepository.Object,
                mockSatusFactory.Object
                );

            //Act
            customerService.Create(createCommmand);

            //Assert
            mockCustomerRepository.Verify(x => x.SaveSpecial(It.IsAny<Customer>()));
            
            //Practice: Test the other method..
            //QUESTION: How to verify that the other method is not called.
        }
    }
}
