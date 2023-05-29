using System;
using Xunit;
using FakeItEasy;
using ChekoutApplication.Controllers;
namespace CheckoutApplication.Test
{
        public class CheckoutControllerTests
    {
        [Fact]
        public void CheckoutControllerTests_ShouldReturnSuccess()
        {
            //Arrange
            var controller = new CheckoutController();
            int ExpectedResult = 50;

            //Act
            int result = controller.CalculateTotalPrice("A");

            //Assert
            Assert.Equal(ExpectedResult, result);

        }
        [Fact]
        public void CheckoutControllerTests_ShouldReturn()
        {
            //Arrange
            var controller = new CheckoutController();
            int ExpectedResult = 80;

            //Act
            int result = controller.CalculateTotalPrice("AB");

            //Assert
            Assert.Equal(ExpectedResult, result);

        }
        [Fact]
        public void CheckoutControllerTests_ShouldReturnZero()
        {
            //Arrange
            var controller = new CheckoutController();
            int ExpectedResult = 0;

            //Act
            int result = controller.CalculateTotalPrice("");

            //Assert
            Assert.Equal(ExpectedResult, result);

        }
    }
}