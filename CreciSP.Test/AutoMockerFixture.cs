using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.BookingRepository;
using CreciSP.Domain.Services.EquipmentRepository;
using CreciSP.Domain.Services.LogNotifyRepository;
using CreciSP.Domain.Services.RoomRepository;
using CreciSP.Domain.Services.UserRepository;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CreciSP.Test
{
    public class AutoMockerFixture
    {
        public AutoMocker mocker;
        public User user;
        public UserFilter userFilter;
        public User userInactive;
        public Room room;
        public Room roomInactive;
        public RoomFilter roomFilter;

        public Booking booking;
        public BookingFilter bookingFilter;

        public LogNotify logNotify;

        public Equipment equipment;
        public Equipment equipmentWithRoom;
        public EquipmentFilter equipmentFilter;

        public Guid idGuid = Guid.NewGuid();

        public AutoMockerFixture()
        {
            InitializeObjects();
            SetMocks();
        }

        private void InitializeObjects()
        {
            mocker = new AutoMocker();

            user = new User(idGuid, "Teste", "01234567890", "teste@teste.com", UserType.Common, true, "0123456789");
            userInactive = new User(new Guid(), "Teste", "01234567890", "teste@teste.com", UserType.Common, false, "0123456789");
            userFilter = new UserFilter { Name = "Teste", Cpf = "01234567890", Email = "teste@teste.com", Type = UserType.Common, Status = true, Password = "0123456789" };

            room = new Room(idGuid, 1, 1, 5, RoomType.Common, true, null);
            roomInactive = new Room(idGuid, 1, 1, 5, RoomType.Common, false, null);
            roomFilter = new RoomFilter { Capacity = room.Capacity, Floor = room.Floor, Number = room.Number, Status = room.Status, Type = room.Type };

            booking = new Booking(idGuid, DateTime.Now, new TimeSpan(15, 00, 00), new TimeSpan(17, 00, 00), room, user.Id);
            bookingFilter = new BookingFilter { Date = DateTime.Now, StartTime = new TimeSpan(15, 00, 00), EndTime = new TimeSpan(17, 00, 00), RoomId = room.Id, UserId = user.Id };

            var Message = $"Reserva Sala {booking.Room.Number} no dia {booking.Date.ToString("dd/MM/yyyy")} das {booking.StartTime.ToString()} às {booking.EndTime.ToString()}";
            logNotify = new LogNotify(Message, LogType.RemoveBooking, DateTime.Now, false, booking.UserId);

            equipment = new Equipment(idGuid, 11, EquipmentType.Monitor, "Monitor 17 polegadas", null);
            equipmentWithRoom = new Equipment(idGuid, 11, EquipmentType.Phone, "Phone", room.Id);
            equipmentFilter = new EquipmentFilter { Number = 11, Type = EquipmentType.Phone, Description = "Phone", RoomId = room.Id };
        }

        private void SetMocks()
        {
            mocker.GetMock<IUserRepository>().Setup(x => x.GetUserById(idGuid).Result)
                  .Returns(user);

            mocker.GetMock<IUserRepository>().Setup(x => x.GetUsersByFilters(userFilter).Result)
                  .Returns(new Collection<User> { user });

            mocker.GetMock<IRoomRepository>().Setup(x => x.GetRoomById(idGuid).Result)
                  .Returns(room);

            mocker.GetMock<IRoomRepository>().Setup(x => x.GetRoomsByFilters(roomFilter).Result)
                  .Returns(new Collection<Room> { room });

            mocker.GetMock<IBookingRepository>().Setup(x => x.GetBookingById(idGuid).Result)
                  .Returns(booking);

            mocker.GetMock<IBookingRepository>().Setup(x => x.GetBookingsByFilter(bookingFilter).Result)
                .Returns(new Collection<Booking> { booking });

            mocker.GetMock<IEquipmentRepository>().Setup(x => x.GetEquipmentById(idGuid).Result)
                .Returns(equipment);

            mocker.GetMock<IEquipmentRepository>().Setup(x => x.GetEquipmentsByFilters(equipmentFilter).Result)
                .Returns(new Collection<Equipment> { equipmentWithRoom });

            mocker.GetMock<ILogNotifyRepository>().Setup(x => x.GetLogNotifyByUserId(idGuid).Result)
               .Returns(new Collection<LogNotify> { logNotify });
        }
    }
}
