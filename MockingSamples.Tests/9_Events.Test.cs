using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_9_Test
    {
        [Test]
        public void Email_Should_Be_Sent_To_Sales_Team()
        {
            //Arrange
            var mockedCustomerRepository = new Mock<ICustomerRepository>();
            var mockedMailingRepository = new Mock<IMailingRepository>();

            CustomerService_9 customerService = new CustomerService_9(
                mockedCustomerRepository.Object,
                mockedMailingRepository.Object
                );

            //Act
            mockedCustomerRepository.Raise(x => x.NotifySalesTeam += null, new EventArgs());

            //Assert
            mockedMailingRepository.Verify(x => x.NewCustomerMessage(It.IsAny<object>()));
        }
    }
}
