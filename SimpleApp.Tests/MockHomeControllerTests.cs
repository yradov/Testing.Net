using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.Controllers;
using SimpleApp.Models;
using Xunit;
using Moq;


namespace SimpleApp.Tests
{
    public class MockHomeControllerTests
    {
        [Fact]
        public void IndexActionModelIsComplete()
        {
            Product[] testData = new Product[] {
                new Product { Name = "P1", Price = 275M },
                new Product { Name = "P2", Price = 275.35M },
                new Product { Name = "P3", Price = 48.95M }
            };

            var mock = new Mock<IDataSource>();
            mock.SetupGet(m => m.Products).Returns(testData);

            var controller = new HomeController();
            controller.dataSource = mock.Object;

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal(expected: testData,
                         actual: model,
                         comparer: Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));

            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
