using System;
using MyMicroservice.Domain.Entities;
using Xunit;

namespace MyMicroservice.Tests.Domain.Entities
{
    public class TioTests
    {
        [Fact]
        public void Tio_Should_Initialize_Id_Automatically()
        {
            // Act
            var tio = new Tio();

            // Assert
            Assert.NotEqual(Guid.Empty, tio.Id);
        }

        [Fact]
        public void Tio_Should_Assign_Properties_Correctly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var nombre = "Carlos";

            // Act
            var tio = new Tio { Id = id, Nombre = nombre };

            // Assert
            Assert.Equal(id, tio.Id);
            Assert.Equal(nombre, tio.Nombre);
        }
    }
}
