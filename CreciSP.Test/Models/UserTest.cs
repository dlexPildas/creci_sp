using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _06.CreciSP.Test.Models
{
    public class UserTest
    {
        [Fact]
        public void UserValid_InactiveUser_MustBeInactived()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var user = autoMockerFixture.user;

            // Act
            user.InactiveUser();

            // Assert
            Assert.False(user.Status);
        }

        [Fact]
        public void UserValid_ActiveUser_MustBeActived()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var user = autoMockerFixture.userInactive;

            // Act
            user.ActiveUser();

            // Assert
            Assert.True(user.Status);
        }

        [Fact]
        public void UserValid_ChangePassword_MustChangePassword()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var user = autoMockerFixture.user;

            // Act
            user.ChangePassword("senha_atualizada");

            // Assert
            Assert.Equal("senha_atualizada", user.Password);
        }

        [Fact]
        public void UserValid_UpdateUser_MustUpdateUser()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var user = autoMockerFixture.user;
            var newUser = new User(new Guid(), "NameAtualizado", "01234567890", "email@atualizado.com", UserType.Common, true, "0123456789");

            // Act
            user.UpdateUser(newUser);

            // Assert
            Assert.Equal("NameAtualizado", user.Name);
            Assert.Equal("email@atualizado.com", user.Email);
        }
    }
}
