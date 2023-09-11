using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityDataLayer.Entities;
using Moq;
using UniversityApplication.User;
using UniversityDataLayer.UnitOfWorks;
using AutoMapper;
using UniversityApplication.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityDataLayer;
using System.Security.Cryptography.X509Certificates;
using UniversityDataLayer.Repositories;
using System.Collections.Generic;

namespace UniversityApplication.CQRSModuels.Students.Commands.Create.Tests
{
    [TestClass()]
    public class CreateStudentCommandHandlerTests
    {
        [TestMethod()]
        public async Task Handle_CreateStudent_WhenUserIsAutorisedLikeAdmin()
        {
            Student? student = new Student()
            {
                GroupId = 61,
                FirstName = "Test",
                LastName = "Test"
            };

            StudentDTO? studentDTO = new StudentDTO()
            {
                GroupId = 61,
                FirstName = "Test",
                IsEditable = false,
                LastName = "Test"
            };

            var command = new CreateStudentCommand()
            {
                GroupId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("1", "test@test.com", new[] { "Admin" }));

            var options = new DbContextOptionsBuilder<UniversityContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            var dbContext = new Mock<UniversityContext>(options);
            Mock<BaseRepository<Student>> repo = new Mock<BaseRepository<Student>>(dbContext.Object);
            repo.Setup(x => x.Add(student));

            Mock <IUnitOfWork> unitMock = new Mock<IUnitOfWork>();
            unitMock.Setup(x => x.StudentRepository).Returns(repo.Object);

            var mapperMock = new Mock<IMapper>();

            var dto = new StudentDTO()
            {
                GroupId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            mapperMock.Setup(x => x.Map<StudentDTO>(command)).Returns(studentDTO);

            mapperMock.Setup(x => x.Map<Student>(studentDTO)).Returns(student);


            var handler = new CreateStudentCommandHandler(unitMock.Object, mapperMock.Object, userContextMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(Unit.Value, result);
            unitMock.Verify(x => x.StudentRepository.Add(It.IsAny<Student>()), Times.Once);
        }

        [TestMethod()]
        public async Task Handle_DoesntCreateStudent_WhenUserIsAutorisedNotLikeAdmin()
        {
            Student? student = new Student()
            {
                GroupId = 61,
                FirstName = "Test",
                LastName = "Test"
            };

            StudentDTO? studentDTO = new StudentDTO()
            {
                GroupId = 61,
                FirstName = "Test",
                IsEditable = false,
                LastName = "Test"
            };

            var command = new CreateStudentCommand()
            {
                GroupId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("1", "test@test.com", new[] { "User" }));

            var options = new DbContextOptionsBuilder<UniversityContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            var dbContext = new Mock<UniversityContext>(options);
            Mock<BaseRepository<Student>> repo = new Mock<BaseRepository<Student>>(dbContext.Object);
            repo.Setup(x => x.Add(student));

            Mock<IUnitOfWork> unitMock = new Mock<IUnitOfWork>();
            unitMock.Setup(x => x.StudentRepository).Returns(repo.Object);

            var mapperMock = new Mock<IMapper>();

            var dto = new StudentDTO()
            {
                GroupId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            mapperMock.Setup(x => x.Map<StudentDTO>(command)).Returns(studentDTO);

            mapperMock.Setup(x => x.Map<Student>(studentDTO)).Returns(student);


            var handler = new CreateStudentCommandHandler(unitMock.Object, mapperMock.Object, userContextMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(Unit.Value, result);
            unitMock.Verify(x => x.StudentRepository.Add(It.IsAny<Student>()), Times.Never);
        }

        [TestMethod()]
        public async Task Handle_DoesntCreateStudent_WhenUserIsNotAutorised()
        {
            Student? student = new Student()
            {
                GroupId = 61,
                FirstName = "Test",
                LastName = "Test"
            };

            StudentDTO? studentDTO = new StudentDTO()
            {
                GroupId = 61,
                FirstName = "Test",
                IsEditable = false,
                LastName = "Test"
            };

            var command = new CreateStudentCommand()
            {
                GroupId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser()).Returns((CurrentUser?)null);

            var options = new DbContextOptionsBuilder<UniversityContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            var dbContext = new Mock<UniversityContext>(options);
            Mock<BaseRepository<Student>> repo = new Mock<BaseRepository<Student>>(dbContext.Object);
            repo.Setup(x => x.Add(student));

            Mock<IUnitOfWork> unitMock = new Mock<IUnitOfWork>();
            unitMock.Setup(x => x.StudentRepository).Returns(repo.Object);

            var mapperMock = new Mock<IMapper>();

            var dto = new StudentDTO()
            {
                GroupId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            mapperMock.Setup(x => x.Map<StudentDTO>(command)).Returns(studentDTO);

            mapperMock.Setup(x => x.Map<Student>(studentDTO)).Returns(student);


            var handler = new CreateStudentCommandHandler(unitMock.Object, mapperMock.Object, userContextMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(Unit.Value, result);
            unitMock.Verify(x => x.StudentRepository.Add(It.IsAny<Student>()), Times.Never);
        }
    }
}