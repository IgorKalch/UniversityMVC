using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityApplication.CQRSModuels.Students.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Microsoft.Extensions.Localization;
using Moq;
using UniversityApplication.CQRSModuels.Students.Commands.Edit;

namespace UniversityApplication.CQRSModuels.Students.Commands.Create.Tests
{
    [TestClass()]
    public class EditStudentCommandValidatorTests
    {
        [TestMethod()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {

            var localizer = new Mock<IStringLocalizer<EditStudentCommand>>();

            localizer.Setup(l => l["MinimumLengthErrorMessage", 3]).Returns(new LocalizedString("MinimumLengthErrorMessage", "Your {0} minimum"));
            localizer.Setup(l => l["MaximumLengthErrorMessage", 20]).Returns(new LocalizedString("MaximumLengthErrorMessage", "Your {0} maximum"));

            var validator = new EditStudentCommandValidator(localizer.Object);

            var command = new EditStudentCommand()
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

            var localizer = new Mock<IStringLocalizer<EditStudentCommand>>();

            localizer.Setup(l => l["MinimumLengthErrorMessage", 3]).Returns(new LocalizedString("MinimumLengthErrorMessage", "Your {0} minimum"));
            localizer.Setup(l => l["MaximumLengthErrorMessage", 20]).Returns(new LocalizedString("MaximumLengthErrorMessage", "Your {0} maximum"));

            var validator = new EditStudentCommandValidator(localizer.Object);

            var command = new EditStudentCommand()
            {
                FirstName = firstName,
                LastName = lastName
            };

            var result = validator.TestValidate(command);

            result.ShouldHaveAnyValidationError();
        }
    }
}