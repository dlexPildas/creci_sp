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
    public class EquipmentTest
    {
        [Fact]
        public void EquipmentValid_InactiveRoom_MustBeInactived()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipment = autoMockerFixture.equipmentWithRoom;

            // Act
            equipment.UnlinkRoom();

            // Assert
            Assert.Null(equipment.RoomId);
        }

        [Fact]
        public void EquipmentValid_ActiveRoom_MustBeActived()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipment = autoMockerFixture.equipment;

            // Act
            equipment.LinkRoom(autoMockerFixture.idGuid);

            // Assert
            Assert.Equal(autoMockerFixture.idGuid, equipment.RoomId);
            Assert.NotNull(equipment.RoomId);

        }


    }
}
