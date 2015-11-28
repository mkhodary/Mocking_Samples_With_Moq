using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingSamples.Tests
{
    public class StringSequenceReader_Test
    {
        [Test]
        public void ReadAll_Verify_Enumerable_Disposed()
        {
            // Arrange
            var mockedEnumerable = new Mock<IEnumerable<string>>();

            mockedEnumerable.Setup(x => x.GetEnumerator())
                .Returns(new string[] { "Ahmed", "Mohamed", "Hani" }.Select(x=>x).GetEnumerator());

            var mockedDisposable = mockedEnumerable.As<IDisposable>();
            
            StringSequenceReader reader = new StringSequenceReader(mockedEnumerable.Object);

            // Act
            reader.ReadAll();

            // Assert
            mockedDisposable.Verify(x => x.Dispose());
            
            //QUESTION: Verify to return result...
            //CollectionAssert.AreEqual(new string[] { "Ahmed", "Mohamed", "Hani" }, reader.ReadAll());
            //mockedDisposable.Verify(x => x.Dispose());
        }
    }
}
