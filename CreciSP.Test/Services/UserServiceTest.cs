using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.UserRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _06.CreciSP.Test.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async void UserValid_SaveClient_MustBeSaved()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var userService = autoMockerFixture.mocker.CreateInstance<UserService>();
            var user = autoMockerFixture.user;

            // Act
            await userService.Create(user);

            // Assert
            autoMockerFixture.mocker.GetMock<IUserRepository>().Verify(x => x.Add(user), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IUserRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void UserValid_UpdateClient_MustBeUpdated()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var userService = autoMockerFixture.mocker.CreateInstance<UserService>();
            var user = autoMockerFixture.user;
            var newUser = new User(autoMockerFixture.idGuid, "NameAtualizado", "01234567890", "email@atualizado.com", UserTypeEnum.Common, true, "0123456789");

            // Act
            await userService.UpdateUser(newUser);

            // Assert
            Assert.Equal("NameAtualizado", user.Name);
            Assert.Equal("email@atualizado.com", user.Email);
            autoMockerFixture.mocker.GetMock<IUserRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void UserNotExist_UpdateClient_MustNotBeUpdated()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var userService = autoMockerFixture.mocker.CreateInstance<UserService>();
            var user = autoMockerFixture.user;
            var newUser = new User(Guid.NewGuid(), "NameAtualizado", "01234567890", "email@atualizado.com", UserTypeEnum.Common, true, "0123456789");

            // Act
            await userService.UpdateUser(newUser);

            // Assert
            Assert.NotEqual("NameAtualizado", user.Name);
            Assert.NotEqual("email@atualizado.com", user.Email);
            autoMockerFixture.mocker.GetMock<IUserRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(0));
        }
    }
}
