using CoffeeShop.Core;
using CoffeeShop.Core.ApplicationService.DomainService;
using CoffeeShop.Core.ApplicationService.Impl;
using CoffeeShop.Core.Entities;
using Moq;
using System;
using System.IO;
using Xunit;

namespace XUnitTestCoffee
{
    public class UnitTest1
    {
        [Fact]
        public void CreateCofeeWithMissingNameThrowsException()
        {
            var coffRepo = new Mock<ICoffeeRepository>();
            ICoffeeService service = new CoffeeService(coffRepo.Object);
            var coffee = new Coffee()
            {

            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateCoffee(coffee));
            Assert.Equal("You have to enter a name for the coffee", ex.Message);
        }

        public void CreateCoffeeWithMissingDescriptionThrowsException()
        {
            var coffRepo = new Mock<ICoffeeRepository>();
            ICoffeeService service = new CoffeeService(coffRepo.Object);
            var coffee = new Coffee()
            {

            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            service.CreateCoffee(coffee));
            Assert.Equal("You need to insert a description!", ex.Message);
        }
    }
}
