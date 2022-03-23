using CreciSP.Application.Services.BookingService;
using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.BookingRepository;
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
    public class BookingServiceTest
    {
        [Fact]
        public async void BookingValid_SaveClient_MustBeSaved()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var bookingService = autoMockerFixture.mocker.CreateInstance<BookingService>();
            var booking = autoMockerFixture.booking;

            // Act
            await bookingService.Create(booking);

            // Assert
            autoMockerFixture.mocker.GetMock<IBookingRepository>().Verify(x => x.Add(booking), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IBookingRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }

        [Fact]
        public async void BookingAdministrator_DeleteClient_MustBeDelete()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var bookingService = autoMockerFixture.mocker.CreateInstance<BookingService>();
            var booking = autoMockerFixture.booking;
            var logNotify = autoMockerFixture.logNotify ;

            // Act
            await bookingService.DeleteBooking(autoMockerFixture.idGuid, true);

            // Assert
            autoMockerFixture.mocker.GetMock<IBookingRepository>().Verify(x => x.Delete(booking), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IBookingRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<ILogNotifyRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<ILogNotifyRepository>().Verify(x => x.Add(logNotify), Times.Exactly(1)); 

        }

        [Fact]
        public async void BookingCommon_DeleteClient_MustBeDelete()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var bookingService = autoMockerFixture.mocker.CreateInstance<BookingService>();
            var booking = autoMockerFixture.booking;

            // Act
            await bookingService.DeleteBooking(autoMockerFixture.idGuid, true);

            // Assert
            autoMockerFixture.mocker.GetMock<IBookingRepository>().Verify(x => x.Delete(booking), Times.Exactly(1));
            autoMockerFixture.mocker.GetMock<IBookingRepository>().Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }
              

        [Fact]
        public async void GetBooking_GetClient_MustFind()
        {
            // Arrange
            AutoMockerFixture autoMockerFixture = new AutoMockerFixture();
            var bookingService = autoMockerFixture.mocker.CreateInstance<BookingService>();
            var booking = autoMockerFixture.booking;
            

            // Act
            var bookingFind = await bookingService.GetBookingsByFilter(autoMockerFixture.bookingFilter);

            // Assert
            Assert.NotNull(bookingFind);
            Assert.Equal(1, bookingFind.Count);
            autoMockerFixture.mocker.GetMock<IBookingRepository>().Verify(x => x.GetBookingsByFilter(autoMockerFixture.bookingFilter), Times.Exactly(1));
        }
    }
}
