using CreciSP.Application.Services.EquipmentService;
using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.EquipmentRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _06.CreciSP.Test.Services
{
    public class EquipmentServiceTest
    {
        [Fact]
        public async void EquipmentValid_SaveClient_MustBeSaved()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipmentService = autoMockerFixture.mocker.CreateInstance<EquipmentService>();
            var equipment = autoMockerFixture.equipment;

            // Act
            await equipmentService.Create(equipment);

            // Assert
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.Add(equipment), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void EquipmentValid_DeleteClient_MustBeDelete()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipmentService = autoMockerFixture.mocker.CreateInstance<EquipmentService>();
            var equipment = autoMockerFixture.equipment;

            // Act
            await equipmentService.DeleteEquipment(autoMockerFixture.idGuid);
            
            // Assert
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.Delete(equipment), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void UnlinkRoomEquipment_UpdateClient_MustUnlinkRoom()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipmentService = autoMockerFixture.mocker.CreateInstance<EquipmentService>();

            // Act
            await equipmentService.UnlinkRoomEquipment(autoMockerFixture.idGuid);

            // Assert
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void LinkRoomEquipment_UpdateClient_MustLinkRoom()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipmentService = autoMockerFixture.mocker.CreateInstance<EquipmentService>();

            // Act
            await equipmentService.LinkRoomEquipment(autoMockerFixture.idGuid, autoMockerFixture.idGuid);

            // Assert
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void GetByFilterEquipment_GetClient_MustFind()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipmentService = autoMockerFixture.mocker.CreateInstance<EquipmentService>();
            var equipment = autoMockerFixture.equipment;
            

            // Act
            var equipmentFind = await equipmentService.GetEquipmentsByFilters(autoMockerFixture.equipmentFilter);

            // Assert
            Assert.NotNull(equipmentFind);
            Assert.Equal(1, equipmentFind.Count);
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.GetEquipmentsByFilters(autoMockerFixture.equipmentFilter), Times.Exactly(1));
        }

        [Fact]
        public async void GetByIdEquipment_GetClient_MustFind()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var equipmentService = autoMockerFixture.mocker.CreateInstance<EquipmentService>();
            var equipment = autoMockerFixture.equipment;


            // Act
            var equipmentFind = await equipmentService.GetEquipmentById(autoMockerFixture.idGuid);

            // Assert
            Assert.NotNull(equipmentFind);
            autoMockerFixture.mocker.GetMock<IEquipmentRepository>().Verify(x => x.GetEquipmentById(autoMockerFixture.idGuid), Times.Exactly(1));
        }
    }
}
