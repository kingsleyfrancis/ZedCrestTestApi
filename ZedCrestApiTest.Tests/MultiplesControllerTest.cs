using Microsoft.AspNetCore.Mvc;
using Xunit;
using ZedCrestApiTest.Controllers;
using ZedCrestApiTest.Models;

namespace ZedCrestApiTest.Tests
{
    public class MultiplesControllerTest
    {
        private readonly MultiplesController _testsController = new MultiplesController();

        [Theory]
        [InlineData(13, "13")]
        [InlineData(27, "Fizz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(-5, "Invalid number supplied. The number must be between 1 and 100")]
        [InlineData(101, "Invalid number supplied. The number must be between 1 and 100")]
        public void TestMultiplesPostActionMethod(int inputData, string expectedResult)
        {
            //Arrange
            var testVal = new PostBody { Number = inputData };

            //Act
            var response = _testsController.Post(testVal);

            //Assert
            var viewResult = Assert.IsAssignableFrom<ObjectResult>(response);
            Assert.Equal(expectedResult, viewResult.Value);
        }
    }
}
