using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class CustomerService_8_Test
    {
        [Test]
        public void Create_ValidCommand_Verify_Timezone_Is_Set()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            CustomerService_8 customerService = new CustomerService_8(
                mockCustomerRepository.Object,
                mockApplicationSettings.Object
                );

            //Act
            customerService.Create(createCommmand);

            //Assert
            mockCustomerRepository.VerifySet(x => x.TimeZone = It.IsAny<string>());
        }

        [Test]
        public void CreateAssignedWorkStation_ValidCommand_Verify_WorkStationId_Get_From_ApplicationSettings()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockApplicationSettings.Setup(x => x.WorkStationId)
                .Returns(10);

            CustomerService_8 customerService = new CustomerService_8(
                mockCustomerRepository.Object,
                mockApplicationSettings.Object
                );

            //Act
            customerService.CreateAssignedWorkStation(createCommmand);

            //Assert
            mockApplicationSettings.VerifyGet(x => x.WorkStationId);
        }

        [Test]
        public void CreateComplexAssignedWorkStation_ValidCommand_Verify_WorkStationId_Get_From_ApplicationSettings()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockApplicationSettings.Setup(x => x.SystemConfiguration.AuditingInformation.WorkStationId)
                .Returns(10);

            CustomerService_8 customerService = new CustomerService_8(
                mockCustomerRepository.Object,
                mockApplicationSettings.Object
                );

            //Act
            customerService.CreateComplexAssignedWorkStation(createCommmand);

            //Assert
            mockApplicationSettings.VerifyGet(x => x.SystemConfiguration.AuditingInformation.WorkStationId);
            mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [Test]
        public void CreateAssignedWorkStation_ValidCommand_Verify_WorkStationId_Get_From_ApplicationSettings_Using_Setup_Property()
        {
            //Arrange
            var createCommmand = new CustomerCreateCommand()
            {
                FirstName = "Mohamed",
                LastName = "Ahmed"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            //mockApplicationSettings.Setup(x => x.WorkStationId)
            //    .Returns(10);

            mockApplicationSettings.SetupProperty(x => x.WorkStationId, 123);
            
            //Can we set if from the object itself??
            //mockApplicationSettings.Object.WorkStationId = 345;

            //mockApplicationSettings.SetupAllProperties();

            CustomerService_8 customerService = new CustomerService_8(
                mockCustomerRepository.Object,
                mockApplicationSettings.Object
                );

            //Act
            customerService.CreateAssignedWorkStation(createCommmand);

            //Assert
            mockApplicationSettings.VerifyGet(x => x.WorkStationId);
        }
    }
}
