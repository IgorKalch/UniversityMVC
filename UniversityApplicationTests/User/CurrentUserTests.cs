using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityApplication.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.User.Tests
{
    [TestClass()]
    public class CurrentUserTests
    {
        [TestMethod()]
        public void IsInRole_WithMatching_ShouldReturnTrue()
        {
            var currentUser = new CurrentUser("1","test@test.com", new List<string> { "Admin", "User"});

            var isInRole = currentUser.IsInRole("Admin");

            Assert.IsTrue(isInRole);
        }

        [TestMethod()]
        public void IsInRole_WithNonMatching_ShouldReturnFalse()
        {
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });

            var isInRole = currentUser.IsInRole("Manager");

            Assert.IsFalse(isInRole);
        }

        [TestMethod()]
        public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
        {
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });

            var isInRole = currentUser.IsInRole("admin");

            Assert.IsFalse(isInRole);
        }
    }
}