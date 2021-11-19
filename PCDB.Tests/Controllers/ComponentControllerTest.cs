using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PCDB.Controllers;
using PCDB.Interfaces;
using PCDB.Models.Components;
using PCDB.Repositories;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace PCDB.Tests.Controllers
{
    [TestClass]
    public class ComponentControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var repositoryMock = new Mock<IComponentRepository<Component>>();
            ComponentsController componentsController = new ComponentsController(repositoryMock.Object);

            // Act
            ViewResult result = componentsController.Index(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Details()
        {
            // Arrange
            var repositoryMock = new Mock<IComponentRepository<Component>>();
            var components = repositoryMock.Object.GetAll().ToList();
            ComponentsController componentsController = new ComponentsController(repositoryMock.Object);

            // Act
            Component component = null;
            if (components.Count > 0)
            {
                Random rand = new Random();
                component = components[rand.Next(components.Count)];

                ViewResult result = componentsController.Details(component.Name) as ViewResult;

                // Assert
                Assert.IsNotNull(component);
                Assert.IsNotNull(result);
            }
        }
    }
}
