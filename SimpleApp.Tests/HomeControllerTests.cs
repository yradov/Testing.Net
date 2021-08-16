using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.Controllers;
using SimpleApp.Models;
using Xunit;


namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        class FakeDataSource : IDataSource
        {
            public FakeDataSource(Product[] data) => Products = data;
            public IEnumerable<Product> Products { get; set; }
        }

        [Fact]
        public void IndexActionModelIsComplete()
        {
            Product[] testData = new Product[] {
                new Product { Name = "P1", Price = 275M },
                new Product { Name = "P2", Price = 275.35M },
                new Product { Name = "P3", Price = 48.95M }
            };

            IDataSource data = new FakeDataSource(testData);
            var controller = new HomeController();
            controller.dataSource = data;

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal(expected: data.Products,
                         actual: model,
                         comparer: Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
