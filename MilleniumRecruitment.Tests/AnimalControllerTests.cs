using Microsoft.AspNetCore.Mvc;
using MilleniumRecruitment.Animals;
using MilleniumRecruitment.Controllers;
using MilleniumRecruitment.Repositories.Interfaces;
using Moq;

namespace MilleniumRecruitment.Tests
{
    public class AnimalControllerTests
    {

        [Test]
        public async Task PostAsync_ValidObject_CallsAddAsyncOnce()
        {
            var repoMock = new Mock<IAnimalRepository>();
            repoMock.Setup(r => r.AddAsync(It.IsAny<Animal>())).Returns(Task.FromResult(new Animal()));
            var controller = new AnimalController(repoMock.Object);

            var result = await controller.PostAsync(new Animal() { Name="SomeName"});

            repoMock.Verify(m => m.AddAsync(It.IsAny<Animal>()), Times.Once);
        }

        [Test]
        public async Task PostAsync_InvalidObject_ReturnsBadRequest()
        {
            var repoMock = new Mock<IAnimalRepository>();
            var controller = new AnimalController(repoMock.Object);
            controller.ModelState.AddModelError("Error", "Name is missing");
            Animal animalWithoutName = new Animal();

            var result = await controller.PostAsync(animalWithoutName);

            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            repoMock.Verify(m => m.AddAsync(It.IsAny<Animal>()), Times.Never);
        }

        [Test]
        public async Task GetAsync_NotExistingObject_ReturnsNotFound()
        {
            var repoMock = new Mock<IAnimalRepository>();
            repoMock.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(default(Animal)));
            var controller = new AnimalController(repoMock.Object);
            int notExistingId = -1;

            var result = await controller.GetAsync(notExistingId);

            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }
    }
}