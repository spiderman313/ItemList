using System;
using System.Threading.Tasks;
using AutoFixture;
using ItemList.DataAccess.Interfaces;
using ItemList.BLL.Interfaces;
using ItemList.BLL.Implementation;
using ItemList.Domain;
using ItemList.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ItemList.BLL.Tests.Unit {
    public class ItemCreateServiceTests {
        [Test]
        public async Task CreateAsync_CategoryValidationSucceed_CreatesItem() {
            // Arrange
            var item = new ItemUpdateModel();
            var expected = new Item();

            var categoryGetService = new Mock<ICategoryGetService>();
            categoryGetService.Setup(x => x.ValidateAsync(item));

            var itemDataAcces = new Mock<IItemDataAccess>();
            itemDataAcces.Setup(x => x.InsertAsync(item)).ReturnsAsync(expected);

            var itemGetService = new ItemCreateService(itemDataAcces.Object, categoryGetService.Object);

            // Act
            var result = await itemGetService.CreateAsync(item);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_CategoryValidationFailed_ThrowsError() {
            // Arrange
            var fixture = new Fixture();
            var item = new ItemUpdateModel();
            var expected = fixture.Create<string>();    

            var categoryGetService = new Mock<ICategoryGetService>();
            categoryGetService
                .Setup(x => x.ValidateAsync(item))
                .Throws(new InvalidOperationException(expected));

            var itemDataAccess = new Mock<IItemDataAccess>();

            var itemGetService = new ItemCreateService(itemDataAccess.Object, categoryGetService.Object);

            // Act
            var action = new Func<Task>(() => itemGetService.CreateAsync(item));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            itemDataAccess.Verify(x => x.InsertAsync(item), Times.Never);
        }
    }
}
