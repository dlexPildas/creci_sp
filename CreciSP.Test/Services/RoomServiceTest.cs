using CreciSP.Application.Services.RoomService;
using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.RoomRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _06.CreciSP.Test.Services
{
    public class RoomServiceTest
    {
        [Fact]
        public async void RoomValid_SaveClient_MustBeSaved()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var roomService = autoMockerFixture.mocker.CreateInstance<RoomService>();
            var room = autoMockerFixture.room;

            // Act
            await roomService.Create(room);

            // Assert
            autoMockerFixture.mocker.GetMock<IRoomRepository>().Verify(x => x.Add(room), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IRoomRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void RoomValid_DeleteClient_MustBeDelete()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var roomService = autoMockerFixture.mocker.CreateInstance<RoomService>();
            var room = autoMockerFixture.room;

            // Act
            await roomService.DeleteRoom(autoMockerFixture.idGuid);
            
            // Assert
            autoMockerFixture.mocker.GetMock<IRoomRepository>().Verify(x => x.Delete(room), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IRoomRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void InactiveRoom_UpdateClient_MustInactive()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var roomService = autoMockerFixture.mocker.CreateInstance<RoomService>();

            // Act
            await roomService.InactiveRoom(autoMockerFixture.idGuid);

            // Assert
            autoMockerFixture.mocker.GetMock<IRoomRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void ActiveRoom_UpdateClient_MustActive()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var roomService = autoMockerFixture.mocker.CreateInstance<RoomService>();

            // Act
            await roomService.ActiveRoom(autoMockerFixture.idGuid);

            // Assert
            autoMockerFixture.mocker.GetMock<IRoomRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void GetRoom_GetClient_MustFind()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var roomService = autoMockerFixture.mocker.CreateInstance<RoomService>();
            var room = autoMockerFixture.room;
            

            // Act
            var roomFind = await roomService.GetRoomsByFilter(autoMockerFixture.roomFilter);

            // Assert
            Assert.NotNull(roomFind);
            Assert.Equal(1, roomFind.Count);
            autoMockerFixture.mocker.GetMock<IRoomRepository>().Verify(x => x.GetRoomsByFilters(autoMockerFixture.roomFilter), Times.Exactly(1));
        }
    }
}
