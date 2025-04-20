using Xunit;
using Moq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.API.Controllers;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Repositories;
using System.Collections.Generic;

namespace MyMicroservice.Tests;

public class TioControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkWithTios()
    {
        // Arrange
        var mockRepo = new Mock<ITioRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Tio> { new Tio { Nombre = "Carlos" } });

        var controller = new TioController(mockRepo.Object);

        // Act
        var result = await controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var tios = Assert.IsAssignableFrom<IEnumerable<Tio>>(okResult.Value);
        Assert.Single(tios);
    }
}
