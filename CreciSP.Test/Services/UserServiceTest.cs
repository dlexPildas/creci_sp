using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
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
            var newUser = new User(autoMockerFixture.idGuid, "NameAtualizado", "01234567890", "email@atualizado.com", UserType.Common, true, "0123456789");

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
            var newUser = new User(Guid.NewGuid(), "NameAtualizado", "01234567890", "email@atualizado.com", UserType.Common, true, "0123456789");

            // Act
            await userService.UpdateUser(newUser);

            // Assert
            Assert.NotEqual("NameAtualizado", user.Name);
            Assert.NotEqual("email@atualizado.com", user.Email);
            autoMockerFixture.mocker.GetMock<IUserRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(0));
        }


        [Fact]
        public async void GetByFilterUser_GetClient_MustFind()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var userService = autoMockerFixture.mocker.CreateInstance<UserService>();
            var user = autoMockerFixture.user;


            // Act
            var userFind = await userService.GetUsersByFilters(autoMockerFixture.userFilter);

            // Assert
            Assert.NotNull(userFind);
            Assert.Equal(1, userFind.Count);
            autoMockerFixture.mocker.GetMock<IUserRepository>().Verify(x => x.GetUsersByFilters(autoMockerFixture.userFilter), Times.Exactly(1));
        }

        [Fact]
        public async void GetByIdUser_GetClient_MustFind()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var userService = autoMockerFixture.mocker.CreateInstance<UserService>();
            var user = autoMockerFixture.user;


            // Act
            var equipmentFind = await userService.GetUserById(autoMockerFixture.idGuid);

            // Assert
            Assert.NotNull(equipmentFind);
            autoMockerFixture.mocker.GetMock<IUserRepository>().Verify(x => x.GetUserById(autoMockerFixture.idGuid), Times.Exactly(1));
        }

    }
}
