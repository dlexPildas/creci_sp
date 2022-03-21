using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Filters;
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

        /// <summary>
        /// Cria uma Sala
        /// </summary>
        /// <param name="room"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> Create(Room room)
        {
            _roomRepository.Add(room);
            return await _roomRepository.SaveChangesAsync();
        }

       
        /// <summary>
        /// Desativer Sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> InactiveRoom(Guid id)
        {
            var room = await _roomRepository.GetRoomById(id);
            if (room == null)
            {
                AddValidationFailure("Sala não encontrada!");
                return false;
            }

            room.InactiveRoom();
            return await _roomRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Active Sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> ActiveRoom(Guid id)
        {
            var room = await _roomRepository.GetRoomById(id);
            if (room == null)
            {
                AddValidationFailure("Sala não encontrada!");
                return false;
            }

            room.ActiveRoom();
            return await _roomRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Buscar Salas pelos filtros
        /// </summary>
        /// <param name="roomFilter"></param>
        /// <returns>Coleção de Salas</returns>
        public async Task<ICollection<Room>> GetRoomsByFilter(RoomFilter roomFilter)
        {
            return await _roomRepository.GetRoomsByFilters(roomFilter);
        }

        /// <summary>
        /// Deletar Sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso se operação for realizada com Sucesso</returns>
        public async Task<bool> DeleteRoom(Guid id)
        {
            var room = await _roomRepository.GetRoomById(id);
            if (room == null)
            {
                AddValidationFailure("Sala não encontrada!");
                return false;
            }
            _roomRepository.Delete(room);

            return await _roomRepository.SaveChangesAsync();
        }

    }
}
