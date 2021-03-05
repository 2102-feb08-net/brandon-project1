using System;
using Xunit;

using Project1.Library.Service;

namespace Project1.Test.Library.Service;
{
    public class LoginService_Tests
    {
        [Theory]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData(null, null)]
        public void TryLogin_AnyParamNull_ReturnFalse(string username, string password)
        {
            // arrange
            LoginService ls = new LoginService(new MockUserRepository());

            // act
            var result = ls.TryLogin(username, password);

            // assert
            Assert.False(result);
        }
    }
}
