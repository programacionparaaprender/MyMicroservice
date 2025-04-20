using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Data;
using MyMicroservice.Infrastructure.Repositories;
using Xunit;

namespace MyMicroservice.Tests.Infrastructure.Repositories
{
    public class TioRepositoryTests
    {
        private async Task<TioRepository> GetRepositoryAsync()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Aislar cada prueba
                .Options;

            var context = new AppDbContext(options);
            await context.Database.EnsureCreatedAsync();

            return new TioRepository(context);
        }

        [Fact]
        public async Task CreateAsync_Should_Add_Tio()
        {
            // Arrange
            var repository = await GetRepositoryAsync();
            var tio = new Tio { Nombre = "Carlos" };

            // Act
            await repository.CreateAsync(tio);
            var result = await repository.GetByIdAsync(tio.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Carlos", result.Nombre);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Tios()
        {
            // Arrange
            var repository = await GetRepositoryAsync();
            await repository.CreateAsync(new Tio { Nombre = "Carlos" });
            await repository.CreateAsync(new Tio { Nombre = "Luis" });

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, System.Linq.Enumerable.Count(result));
        }

        [Fact]
        public async Task UpdateAsync_Should_Modify_Tio()
        {
            // Arrange
            var repository = await GetRepositoryAsync();
            var tio = new Tio { Nombre = "Carlos" };
            await repository.CreateAsync(tio);

            // Act
            tio.Nombre = "Carlos Modificado";
            await repository.UpdateAsync(tio);
            var updated = await repository.GetByIdAsync(tio.Id);

            // Assert
            Assert.Equal("Carlos Modificado", updated.Nombre);
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Tio()
        {
            // Arrange
            var repository = await GetRepositoryAsync();
            var tio = new Tio { Nombre = "Carlos" };
            await repository.CreateAsync(tio);

            // Act
            await repository.DeleteAsync(tio.Id);
            var result = await repository.GetByIdAsync(tio.Id);

            // Assert
            Assert.Null(result);
        }
    }
}
