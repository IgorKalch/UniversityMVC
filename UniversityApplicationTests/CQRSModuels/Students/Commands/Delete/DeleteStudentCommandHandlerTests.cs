using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityApplication.CQRSModuels.Students.Commands.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using UniversityApplication.CQRSModuels.Students.Commands.Create;
using UniversityApplication.DTOs;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.Repositories;
using UniversityDataLayer.UnitOfWorks;
using UniversityDataLayer;
using UniversityApplication.CQRSModuels.Students.Commands.Edit;

namespace UniversityApplication.CQRSModuels.Students.Commands.Delete.Tests
{
    [TestClass()]
    public class DeleteStudentCommandHandlerTests
    {
        [TestMethod()]
        public async Task Handle_DeleteStudent_WhenUserIsAutorisedLikeAdmin()
        {
            Student? student = new Student()
            {
                GroupId = 61,
                FirstName = "Test",
                LastName = "Test"
            };

            var command = new DeleteStudentCommand()
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
            repo.Setup(x => x.GetById(command.Id)).Returns(student);
            repo.Setup(x => x.Remove(student));

            student.FirstName = command.FirstName;
            student.LastName = command.LastName;

            Mock<IUnitOfWork> unitMock = new Mock<IUnitOfWork>();
            unitMock.Setup(x => x.StudentRepository).Returns(repo.Object);
            unitMock.Setup(x => x.Commit());

            var handler = new DeleteStudentCommandHandler(unitMock.Object, userContextMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(Unit.Value, result);
            unitMock.Verify(x => x.StudentRepository.Remove(It.IsAny<Student>()), Times.Once);
        }

        [TestMethod()]
        public async Task Handle_DoesntDeleteStudent_WhenUserIsAutorisedNotLikeAdmin()
        {
            Student? student = new Student()
            {
                GroupId = 61,
                FirstName = "Test",
                LastName = "Test"
            };

            var command = new DeleteStudentCommand()
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
            repo.Setup(x => x.GetById(command.Id)).Returns(student);
            repo.Setup(x => x.Remove(student));

            student.FirstName = command.FirstName;
            student.LastName = command.LastName;

            Mock<IUnitOfWork> unitMock = new Mock<IUnitOfWork>();
            unitMock.Setup(x => x.StudentRepository).Returns(repo.Object);
            unitMock.Setup(x => x.Commit());

            var handler = new DeleteStudentCommandHandler(unitMock.Object, userContextMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(Unit.Value, result);
            unitMock.Verify(x => x.StudentRepository.Remove(It.IsAny<Student>()), Times.Never);
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

            var command = new DeleteStudentCommand()
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
            repo.Setup(x => x.GetById(command.Id)).Returns(student);
            repo.Setup(x => x.Remove(student));

            student.FirstName = command.FirstName;
            student.LastName = command.LastName;

            Mock<IUnitOfWork> unitMock = new Mock<IUnitOfWork>();
            unitMock.Setup(x => x.StudentRepository).Returns(repo.Object);
            unitMock.Setup(x => x.Commit());

            var handler = new DeleteStudentCommandHandler(unitMock.Object, userContextMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(Unit.Value, result);
            unitMock.Verify(x => x.StudentRepository.Remove(It.IsAny<Student>()), Times.Never);
        }
    }
}