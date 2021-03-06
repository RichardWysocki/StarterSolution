﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ASPNET_API.Controllers;
using AutoMapper;
using DataAccess;
using DataAccess.Models;
using Moq;
using NUnit.Framework;

namespace Test.NUnitTestProject.ASPNET_API
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetReturnsAllCustomers()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<ICustomerRepository>();
            var mockCustomerLocationRepository = new Mock<ICustomerLocationRepository>();
            mockRepository.Setup(x => x.GetAllCustomers())
                .Returns(new List<Customer>()
                {
                    new Customer() {CustomerId = 1, FirstName = "Richard", LastName = "Wysocki", State = "PA"},
                    new Customer() {CustomerId = 2, FirstName = "Richard", LastName = "Wysocki", State = "PA"}
                    }
                );
            var controller = new CustomerController(mockMapper.Object, mockRepository.Object, mockCustomerLocationRepository.Object);

            // Act
            var actionResult = controller.Get();

            //actionResult.
            var contentResult = actionResult as OkObjectResult;// Ok as OkNegotiatedContentResult<List<Customer>>;

            // Assert
            Assert.AreEqual(200, contentResult.StatusCode);
            //var data = contentResult.Value;
            var data = (List<Customer>) contentResult.Value;
            ////Assert.that(result, Is.InstanceOf<Boo>()); //True ("Boo" or "Woo")
            //var returnValue = Assert.IsType<List<IdeaDTO>>(okResult.Value);
            //var idea = returnValue.FirstOrDefault();
            Assert.IsTrue(data.Count== 2);
            Assert.AreEqual(2, data.Last().CustomerId);
        }

        [Test]
        public void GetIdReturnsCustomerWithSameId()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<ICustomerRepository>();
            var mockCustomerLocationRepository = new Mock<ICustomerLocationRepository>();
            mockRepository.Setup(x => x.GetCustomerByCustomerID(1))
                .Returns(new Customer() {CustomerId = 1, FirstName = "Richard", LastName = "Wysocki", State = "PA"}
                );
            var controller = new CustomerController(mockMapper.Object, mockRepository.Object, mockCustomerLocationRepository.Object);

            // Act
            var actionResult = controller.Get(1);

            //actionResult.
            var contentResult = actionResult as OkObjectResult;// Ok as OkNegotiatedContentResult<List<Customer>>;

            // Assert
            Assert.AreEqual(200, contentResult.StatusCode);
            //var data = contentResult.Value;
            var data = (Customer)contentResult.Value;
            ////Assert.that(result, Is.InstanceOf<Boo>()); //True ("Boo" or "Woo")
            //var returnValue = Assert.IsType<List<IdeaDTO>>(okResult.Value);
            //var idea = returnValue.FirstOrDefault();
            Assert.AreEqual(1, data.CustomerId);
        }

        [Test]
        public void GetIdThrowsExceptionWithInvalidId()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<ICustomerRepository>();
            var mockCustomerLocationRepository = new Mock<ICustomerLocationRepository>();
            mockRepository.Setup(x => x.GetCustomerByCustomerID(1))
                .Throws(new Exception("Error getting Customer record."));
            var controller = new CustomerController(mockMapper.Object, mockRepository.Object, mockCustomerLocationRepository.Object);

            // Act
            var actionResult = controller.Get(1);
            var contentResult = actionResult as NotFoundResult;// Ok as OkNegotiatedContentResult<List<Customer>>;

            // Assert
            Assert.NotNull(contentResult);
            Assert.IsInstanceOf<NotFoundResult>(contentResult);
            Assert.True(404 == contentResult.StatusCode);
        }
    }
}
