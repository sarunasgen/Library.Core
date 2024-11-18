using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class MathActionsServiceTests
    {
        [Fact]
        public void MathService_Sum_Test()
        {
            //Arrange
            var mathActionsService = new MathActionsServices();

            int a = 8;
            int b = 12;

            int expectedResult = 20;

            //Act

            var actualResult = mathActionsService.Sum(a, b);

            //Assert

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MathService_Subtract_Test()
        {
            //Arrange
            var mathActionsService = new MathActionsServices();

            int a = 10;
            int b = 3;

            int expectedResult = 7;

            //Act

            var actualResult = mathActionsService.Subtract(a, b);

            //Assert

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
