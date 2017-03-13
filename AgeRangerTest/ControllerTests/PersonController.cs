using System.Web.Http.Results;
using AgeRanger.Controllers;
using AgeRanger.DTO;
using AgeRangerTest.Fakes;
using Infrastructure;
using Infrastructure.IRepository;
using Infrastructure.IService;
using Infrastructure.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgeRangerTest.ControllerTests
{
    [TestClass]
    public class PersonController
    {
        [TestMethod]
        public void GetReturnsFoundWithSameId()
        {
            var personRepository = new Mock<IPersonRepository>();
            var personService = new Mock<IPersonService>();

            personRepository
                .Setup(x => x.GetById(1))
                .Returns(PersonFake.Person);

            var controller = new AgeRanger.Controllers.PersonController(
                personRepository.Object,
                personService.Object);

            var actionResult = controller.Get(1);

            var contentResult = actionResult as OkNegotiatedContentResult<PersonViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetReturnsNotFound()
        {
            var personRepository = new Mock<IPersonRepository>();
            var personService = new Mock<IPersonService>();

            var controller = new AgeRanger.Controllers.PersonController(
                personRepository.Object,
                personService.Object);

            var actionResult = controller.Get(15);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddPerson()
        {
            var personRepository = new Mock<IPersonRepository>();
            var personService = new Mock<IPersonService>();

            personService
                .Setup(x => x.Add(PersonFake.PersonViewModel))
                .Returns(new RepositoryActionResult<Person>(PersonFake.CreatePerson, RepositoryActionStatus.Created));

            var controller = new AgeRanger.Controllers.PersonController(
                personRepository.Object,
                personService.Object);

            var actionResult = controller
                .Post(PersonFake.PersonViewModel);

            var createdResult = actionResult as CreatedNegotiatedContentResult<PersonViewModel>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(10, createdResult.Content.Id);
        }

        [TestMethod]
        public void UpdatePerson()
        {
            var personRepository = new Mock<IPersonRepository>();
            var personService = new Mock<IPersonService>();

            personService
                .Setup(x => x.Update(PersonFake.PersonViewModel))
                .Returns(new RepositoryActionResult<Person>(PersonFake.UpdatePerson, RepositoryActionStatus.Updated));

            var controller = new AgeRanger.Controllers.PersonController(
                personRepository.Object,
                personService.Object);

            var actionResult = controller
                .Put(PersonFake.PersonViewModel.Id, PersonFake.PersonViewModel);

            var updatedResult = actionResult as OkNegotiatedContentResult<PersonViewModel>;

            // Assert
            Assert.IsNotNull(updatedResult);
            Assert.AreEqual(PersonFake.UpdatePerson.FirstName, updatedResult.Content.FirstName);
            Assert.AreEqual(PersonFake.UpdatePerson.LastName, updatedResult.Content.LastName);
        }
    }
}
