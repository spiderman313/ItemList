using System;
using System.Threading.Tasks;
using AutoFixture;
using ItemList.DataAccess.Interfaces;
using ItemList.BLL.Implementation;
using ItemList.Domain;
using ItemList.Domain.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ItemList.BLL.Tests.Unit {
    [TestFixture]
    class CategoryGetServiceTests {
        [Test]
        public async Task ValidateAsync_CategoryExists_DoesNothing() {
            // Arrange
            var categoryContainer = new Mock<ICategoryContainer>();

            var category = new Category();
            var categoryDataAccess = new Mock<ICategoryDataAccess>();
            categoryDataAccess.Setup(x => x.GetByAsync(categoryContainer.Object)).ReturnsAsync(category);

            var categoryGetService = new CategoryGetService(categoryDataAccess.Object);

            // Act
            var action = new Func<Task>(() => categoryGetService.ValidateAsync(categoryContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_CategoryNotExists_ThrowsError() {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var categoryContainer = new Mock<ICategoryContainer>();
            categoryContainer.Setup(x => x.CategoryId).Returns(id);

            var Category = new Category();
            var categoryDataAccess = new Mock<ICategoryDataAccess>();
            categoryDataAccess.Setup(x => x.GetByAsync(categoryContainer.Object)).ReturnsAsync((Category)null);

            var categoryGetService = new CategoryGetService(categoryDataAccess.Object);

            // Act
            var action = new Func<Task>(() => categoryGetService.ValidateAsync(categoryContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Category not found by id {id}");
        }
    }
}
