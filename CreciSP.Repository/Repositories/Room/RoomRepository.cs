using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.Room
{
    public class RoomRepository : Persist, IRoomRepository 
    {
        private readonly DataContext _dataContext;

        public RoomRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
