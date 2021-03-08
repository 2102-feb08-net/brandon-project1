using System;
using System.Diagnostics;
using Xunit;

using Project1.Library.Service;
using Project1.Test.Library.Service.Mock;

namespace Project1.Test.Library.Service
{
    public class UserService_Tests
    {
        [Theory]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData(null, null)]
        public void TryLogin_AnyParamNull_ReturnFalse(string username, string password)
        {
            // arrange
            UserService userService = new UserService(new MockUserRepository(), new MockCustomerRepository());

            // act
            var throwsException = false;
            try
            {
                userService.TryLogin(username, password);
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine(e);
                throwsException = true;
            }
            

            // assert
            Assert.True(throwsException);
        }



        [Fact]
        public void GetUserDetails_UsernameNull_ThrowException()
        {
            // arrange
            UserService userService = new UserService(new MockUserRepository(), new MockCustomerRepository());

            // act
            var throwsException = false;
            try
            {
                userService.GetUserDetails(null);
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine(e);
                throwsException = true;
            }

            // assert
            Assert.True(throwsException);
        }
    }
}
