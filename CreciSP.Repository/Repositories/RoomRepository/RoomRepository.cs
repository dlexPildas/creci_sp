using CreciSP.Domain.Models;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.RoomRepository
{
    public class RoomRepository : Persist, IRoomRepository 
    {
        private readonly DataContext _dataContext;

        public RoomRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Room> GetAllRooms()
        {
           var result =  _dataContext.Rooms.ToList();

            return result;
        }
    }
}
