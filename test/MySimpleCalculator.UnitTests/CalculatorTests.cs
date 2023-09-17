using NUnit.Framework;

namespace MySimpleCalculator.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        [TestCase(3, 1, 4)]
        [TestCase(2, 1, 3)]
        //[TestCase(int.MaxValue, 0, 2)]
        public void ShouldReturnASum(int n1, int n2, int sum)
        {
            var sut = new Calculator(); //Arrange
            var result = sut.Add(n1, n2); //Act
            Assert.That(sum, Is.EqualTo(result)); //Assert
        }

        [Test]
        [TestCase(null, 1)]
        [TestCase(1, null)]
        public void ShouldNotAddNULL(int? n1, int? n2)
        {
            //Arrange
            var sut = new Calculator();
            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.Add(n1, n2));
        }

        [Test]
        [TestCase(3, 1, 2)]
        [TestCase(2, 1, 1)]
        public void ShouldReturnASubtraction(int n1, int n2, int sub)
        {
            var sut = new Calculator(); //Arrange
            var result = sut.Subtract(n1, n2); //Act
            Assert.That(sub, Is.EqualTo(result)); //Assert
        }

        [Test]
        [TestCase(null, 1)]
        [TestCase(1, null)]
        public void ShouldNotSubtractNULL(int? n1, int? n2)
        {
            //Arrange
            var sut = new Calculator();
            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.Subtract(n1, n2));
        }

        [Test]
        [TestCase(3, 1, 3)]
        [TestCase(2, 3, 6)]
        public void ShouldReturnAMultiplication(int n1, int n2, int mul)
        {
            var sut = new Calculator(); //Arrange
            var result = sut.Multiply(n1, n2); //Act
            Assert.That(mul, Is.EqualTo(result)); //Assert
        }

        [Test]
        [TestCase(null, 1)]
        [TestCase(1, null)]
        public void ShouldNotMultiplyNULL(int? n1, int? n2)
        {
            //Arrange
            var sut = new Calculator();
            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.Multiply(n1, n2));
        }

        [Test]
        [TestCase(3, 1, 3)]
        [TestCase(3, 3, 1)]
        [TestCase(2.0, 4.0, 0.5)]
        [TestCase(2, 4, 0.5)]
        public void ShouldReturnADivision(double n1, double n2, double div)
        {
            var sut = new Calculator(); //Arrange
            var result = sut.Divide(n1, n2); //Act
            Assert.That(div, Is.EqualTo(result)); //Assert
        }

        [Test]
        [TestCase(null, 1)]
        [TestCase(1, null)]
        public void ShouldNotDivideNULL(int? n1, int? n2)
        {
            //Arrange
            var sut = new Calculator();
            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.Divide(n1, n2));
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(1, 0)]
        public void ShouldNotDivideByZero(int? n1, int? n2)
        {
            //Arrange
            var sut = new Calculator();
            if (n1 == null)
                //Assert                                   Act 
                Assert.Throws<ArgumentNullException>(() => sut.Divide(n1, n2));
            else
                //Assert                                   Act 
                Assert.Throws<DivideByZeroException>(() => sut.Divide(n1, n2));
        }
    }
}
