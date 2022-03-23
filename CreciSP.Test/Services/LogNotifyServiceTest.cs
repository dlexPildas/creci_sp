using CreciSP.Application.Services.EquipmentService;
using CreciSP.Application.Services.LogNotifyService;
using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.EquipmentRepository;
using CreciSP.Domain.Services.LogNotifyRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _06.CreciSP.Test.Services
{
    public class LogNotifyServiceTest
    {        

        [Fact]
        public async void GetLogNotifyByUser_GetClient_MustFind()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var logNotifyService = autoMockerFixture.mocker.CreateInstance<LogNotifyService>();
            var logNotify = autoMockerFixture.logNotify;
            

            // Act
            var equipmentFind = await logNotifyService.GetLogNotifyByUserId(autoMockerFixture.idGuid);

            // Assert
            Assert.NotNull(equipmentFind);
            Assert.Equal(1, equipmentFind.Count);
            autoMockerFixture.mocker.GetMock<ILogNotifyRepository>().Verify(x => x.GetLogNotifyByUserId(autoMockerFixture.idGuid), Times.Exactly(1));
        }

        
    }
}
