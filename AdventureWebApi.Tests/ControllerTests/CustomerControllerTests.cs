using Adventure.API.Model;
using AdventureWebApi.Controllers;
using AdventureWebApi.Interfaces;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace AdventureWebApi.Tests.ControllerTests
{

    public class CustomerControllerTests : IDisposable
    {
        #region Members
        private Mock<ICustomerService> _customerService = null;
        private CustomersController _customersController;

        #endregion

        public CustomerControllerTests()
        {
            // Setup service.
            _customerService = new Mock<ICustomerService>();
            _customersController = new CustomersController(_customerService.Object);

            // Register AutoMapper mappings.
            MappingConfig.RegisterMaps();
        }
        public void Dispose()
        {
            Mapper.Reset();
        }

        [Fact]
        public void GetAll_Customers()
        {
            // Arrange
            int customerId = 12;

            _customerService
                .Setup(service => service.GetCustomers())
                .Returns(new List<CustomerModel>
                {
                    new CustomerModel { CustomerID = 12 }
                });

            // Act
            IHttpActionResult result = _customersController.Get();
            var okNegotiateResult = result as OkNegotiatedContentResult<IEnumerable<CustomerModel>>;

            //Assert
            _customerService.Verify(service => service.GetCustomers(), Times.Once);
            Assert.NotNull(okNegotiateResult.Content.Single(customer => customer.CustomerID == customerId));
        }

        [Theory]
        [InlineData(12)]
        public void Get_Customers(int number)
        {
            _customerService
                .Setup(service => service.GetCustomer(number))
                .Returns(new CustomerModel
                {
                    CustomerID = 12
                });
            IHttpActionResult result = _customersController.Get(number);
            var okNegotiateResult = result as OkNegotiatedContentResult<CustomerModel>;

            // Assert.Equal(1,okNegotiateResult.Content.Count());

            Assert.Equal(number, okNegotiateResult.Content.CustomerID);
        }
        
    }
}
