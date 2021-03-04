using System;
using Xunit;

using Project1.Library.Model;

namespace Project1.Test
{
    public class UserTest
    {
        [Fact]
        public void PasswordProp_Set_Valid()
        {
            // arrange
            User user = new User();

            // act
            user.Password = "loltesting";

            // assert
            Assert.Equal(user.Password, "loltesting");
        }
    }
}
