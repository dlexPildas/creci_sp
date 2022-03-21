


using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.RoomRepository;
using CreciSP.Repository.Repositories;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.RoomService
{
    public class RoomService : NotifierService, IRoomService
    {
        private readonly IReadConnection _readConnection;
        private readonly IRoomRepository _roomRepository;

        public RoomService(IReadConnection readConnection, IRoomRepository roomRepository)
        {
            _readConnection = readConnection;
            _roomRepository = roomRepository;
        }

        public override ValidationResult ValidationResult()
        {
            return GetValidationResult();
        }

        public async Task<bool> Create(Room room)
        {
            _roomRepository.Add(room);
            return await _roomRepository.SaveChangesAsync();
        }

        public async Task<ICollection<Room>> GetRooms()
        {
            var cmd = "SELECT * FROM Room";

            try
            {
                var result = await _readConnection.QueryAsync<Room>(cmd);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Buscar os dados");
            }            
        }
    }
}
