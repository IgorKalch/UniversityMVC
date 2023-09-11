using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityApplication.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace UniversityApplication.User.Tests
{
    [TestClass()]
    public class UserContextTests
    {
        [TestMethod()]
        public void GetCurrentUser_WithAutenticatedUser_ShouldReturnCurrent()
        {
            string userIdExpected = "1";
            string userMailExpected = "test@example.com";
            IEnumerable<string> userRolesExpected = new List<string>() { "Admin", "User" };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "test@example.com"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessorMock.Object);


            var currentUser = userContext.GetCurrentUser();

            Assert.IsNotNull(currentUser);
            Assert.AreEqual(userIdExpected, currentUser.Id);
            Assert.AreEqual(userMailExpected, currentUser.Email);
            CollectionAssert.AreEquivalent(userRolesExpected.ToList(), currentUser.Roles.ToList());

        }
    }
}