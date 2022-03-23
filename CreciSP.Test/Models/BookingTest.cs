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
    public class BookingTest
    {
        [Fact]
        public void RoomValid_InactiveRoom_MustBeInactived()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var room = autoMockerFixture.room;

            // Act
            room.InactiveRoom();

            // Assert
            Assert.False(room.Status);
        }

        [Fact]
        public void RoomValid_ActiveRoom_MustBeActived()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var room = autoMockerFixture.roomInactive;

            // Act
            room.ActiveRoom();

            // Assert
            Assert.True(room.Status);
        }             

        
    }
}
