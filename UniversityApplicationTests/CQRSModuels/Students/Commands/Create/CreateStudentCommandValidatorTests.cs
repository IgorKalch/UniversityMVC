using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityApplication.CQRSModuels.Students.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniversityApplication.CQRSModuels.Courses.Commands.Create;
using Moq;
using Microsoft.Extensions.Localization;
using FluentValidation.TestHelper;

namespace UniversityApplication.CQRSModuels.Students.Commands.Create.Tests
{
    [TestClass()]
    public class CreateStudentCommandValidatorTests
    {
        [TestMethod()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {         

            var localizer = new Mock<IStringLocalizer<CreateStudentCommand>>();

            localizer.Setup(l => l["MinimumLengthErrorMessage", 3]).Returns(new LocalizedString("MinimumLengthErrorMessage", "Your {0} minimum"));
            localizer.Setup(l => l["MaximumLengthErrorMessage", 20]).Returns(new LocalizedString("MaximumLengthErrorMessage", "Your {0} maximum"));

            var validator = new CreateStudentCommandValidator(localizer.Object);

            var command = new CreateStudentCommand()
            {
                FirstName = "FirstNameTest",
                LastName = "LastNameTest"
            };

            var result = validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [DataRow("1", "lastName")]
        [DataRow("", "lastName")]
        [DataRow("lastNemeTestMoreThan20Chapters", "lastName")]
        [DataRow("lastNeme", "1")]
        [DataRow("lastNeme", "")]
        [DataRow("lastNeme", "LastNameTestMoreThan20Chapters")]
        [DataRow("lastNemeTestMoreThan20Chapters", "LastNameTestMoreThan20Chapters")]
        [TestMethod()]
        public void Validate_WithInvalidCommand_ShouldHaveValidationError(string firstName, string lastName)
        {

            var localizer = new Mock<IStringLocalizer<CreateStudentCommand>>();

            localizer.Setup(l => l["MinimumLengthErrorMessage", 3]).Returns(new LocalizedString("MinimumLengthErrorMessage", "Your {0} minimum"));
            localizer.Setup(l => l["MaximumLengthErrorMessage", 20]).Returns(new LocalizedString("MaximumLengthErrorMessage", "Your {0} maximum"));

            var validator = new CreateStudentCommandValidator(localizer.Object);

            var command = new CreateStudentCommand()
            {
                FirstName = firstName,
                LastName = lastName
            };

            var result = validator.TestValidate(command);

            result.ShouldHaveAnyValidationError();
        }
    }
}