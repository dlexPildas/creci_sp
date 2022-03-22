using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.UserRepository;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.EquipmentRepository
{
    public class EquipmentRepository : Persist, IEquipmentRepository
    {
        private readonly DataContext _dataContext;
        private readonly IReadConnection _readConnection;

        public EquipmentRepository(DataContext dataContext, IReadConnection readConnection) : base(dataContext)
        {
            _dataContext = dataContext;
            _readConnection = readConnection;
        }

        public async Task<ICollection<Equipment>> GetEquipmentsByFilters(EquipmentFilter equipmentFilter)
        {
            var cmd = $@"SELECT SELECT [Id]
                                      ,[Number]
                                      ,[Type]
                                      ,[Description]
                                      ,[RoomId]
                                  FROM [dbo].[Equipment]
                           WHERE (@Number is null OR u.[Number] = @Number) AND
                           (u.[RoomId] = '@RoomId') AND
                           (@Description is null OR u.[Description] like '%@Description%') AND
                           (@Type is null OR u.[Type] = @Type)";
            var parameters = new
            {
                Number = equipmentFilter.Number,
                RoomId = equipmentFilter.RoomId,
                Description = equipmentFilter.Description,
                Type = equipmentFilter.Type
            };
            var result = await _readConnection.QueryAsync<Equipment>(cmd, parameters);
            return result;
        }

        public async Task<Equipment> GetEquipmentById(Guid id)
        {
            return await _dataContext.Equipment.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
