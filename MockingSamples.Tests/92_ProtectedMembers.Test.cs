using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.Protected;

namespace MockingSamples.Tests
{
    public class CustomerNameFormatter_Test
    {
        [Test]
        public void CustomerNameFormatter_From_Remove_Underscore_From_Full_Name()
        {
            //Arrange
            var mocked = new Mock<CustomerNameFormatter>();

            mocked.Protected()
                .Setup<string>("RemoveUnderScoreFrom", ItExpr.IsAny<string>())
                .Returns("mohamed")
                .Verifiable();

            //Act
            mocked.Object.From(new Customer("mohamed", "ahmed"));

            //Assert
            mocked.Protected().Verify<string>("RemoveUnderScoreFrom", Times.Exactly(2),ItExpr.IsAny<string>());
        }
    }
}
