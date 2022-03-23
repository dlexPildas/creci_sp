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
            var cmd = $@"SELECT  [Id]
                                ,[Number]
                                ,[Type]
                                ,[Description]
                                ,[RoomId]
                            FROM [dbo].[Equipment] e
                            WHERE 
                                1=1
                                {(equipmentFilter.Number != default ? $"AND (e.[Number] = {equipmentFilter.Number})" : "")}
                                {(equipmentFilter.RoomId != default ? $"AND ( e.[RoomId] = '{equipmentFilter.RoomId}')" : "AND ( e.[RoomId] IS NULL)")}
                                {(equipmentFilter.Description != default ? $"AND ( e.[Description] like '%{equipmentFilter.RoomId}%')" : "")}
                                {(equipmentFilter.Type != default ? $"AND ( e.[Type] = {equipmentFilter.Type})" : "")}";
            
            
            var result = await _readConnection.QueryAsync<Equipment>(cmd);
            return result;
        }

        public async Task<Equipment> GetEquipmentById(Guid id)
        {
            return await _dataContext.Equipment.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
