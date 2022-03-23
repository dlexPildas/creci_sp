using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.EquipmentRepository;
using CreciSP.Repository.Repositories;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.EquipmentService
{
    public class EquipmentService : NotifierService, IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public override ValidationResult ValidationResult()
        {
            return GetValidationResult();
        }

        /// <summary>
        /// Cria um Equipamento
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> Create(Equipment equipment)
        {
            _equipmentRepository.Add(equipment);

            return await _equipmentRepository.SaveChangesAsync();
        }

        
        /// <summary>
        /// Buscar lista de equipamentos com base nos parâmetros
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<ICollection<Equipment>> GetEquipmentsByFilters(EquipmentFilter equipmentFilter)
        {
            return await _equipmentRepository.GetEquipmentsByFilters(equipmentFilter);
        }

        /// <summary>
        /// Buscar Equipamento pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuário</returns>
        public async Task<Equipment> GetEquipmentById(Guid id)
        {
            return await _equipmentRepository.GetEquipmentById(id);
        }

        /// <summary>
        /// Desvincular Equipamento a uma sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> UnlinkRoomEquipment(Guid id)
        {
            var equipment = await _equipmentRepository.GetEquipmentById(id);
            if (equipment == null)
            {
                AddValidationFailure("Equipamento não encontrado!");
                return false;
            }
            equipment.UnlinkRoom();
            return await _equipmentRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Vincular Equipamento a uma sala
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roomId"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> LinkRoomEquipment(Guid id, Guid roomId)
        {
            var equipment = await _equipmentRepository.GetEquipmentById(id);
            if (equipment == null)
            {
                AddValidationFailure("Equipamento não encontrado!");
                return false;
            }

            equipment.LinkRoom(roomId);
            return await _equipmentRepository.SaveChangesAsync();
        }


        /// <summary>
        /// Deletar Equipamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso se operação for realizada com Sucesso</returns>
        public async Task<bool> DeleteEquipment(Guid id)
        {
            var room = await _equipmentRepository.GetEquipmentById(id);
            if (room == null)
            {
                AddValidationFailure("Equipamento não encontrada!");
                return false;
            }
            _equipmentRepository.Delete(room);

            return await _equipmentRepository.SaveChangesAsync();
        }
    }
}
