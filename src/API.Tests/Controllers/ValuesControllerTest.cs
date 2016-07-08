using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using API;
using API.Controllers;
using NUnit.Framework;
using Application.Services.Ads;
using Moq;

namespace API.Tests.Controllers
{
    [TestFixture]
    public class ValuesControllerTest
    {
        private AdController _AdController;

        [SetUp]
        public void SetUpFixture()
        {
            this._AdController = new AdController(new Mock<IAdService>().Object);
        }

        [Test]
        public void Get()
        {
            // Arrange

            AdController controller = this._AdController;

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [Test]
        public void GetById()
        {
            // Arrange
            AdController controller = this._AdController;

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [Test]
        public void Post()
        {
            // Arrange
            AdController controller = this._AdController;

            // Act
            controller.Post("value");

            // Assert
        }

        [Test]
        public void Put()
        {
            // Arrange
            AdController controller = this._AdController;

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [Test]
        public void Delete()
        {
            // Arrange
            AdController controller = this._AdController;

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
