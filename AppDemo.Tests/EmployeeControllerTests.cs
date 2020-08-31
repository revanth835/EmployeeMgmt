using AppDemo.Controllers;
using AppDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AppDemo.Tests
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _controller;
        private readonly Mock<IEmployeeRepository> _service;
        public EmployeeControllerTests()
        {
            _service = new Mock<IEmployeeRepository>();
            _controller = new EmployeeController(_service.Object);
        }

        [Fact]
        public async Task Get_Returns_200()
        {
            Employee model = new Employee()
            {
                Name = "TestDesc",
                Role = "TestTitle",
                Department = "TestDept"
            };
            _service.Setup(x => x.GetById(It.IsAny<string>())).Returns(Task.FromResult(model));
            var result = await _controller.Get("1234");
            var actionResult = result as ObjectResult;
            Assert.Equal(200, actionResult.StatusCode);
        }
    }
}
