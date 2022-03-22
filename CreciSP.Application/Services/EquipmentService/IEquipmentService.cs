using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.EquipmentService
{
    public interface IEquipmentService : INotifierService
    {
        Task<bool> Create(Equipment user);

        Task<ICollection<Equipment>> GetEquipmentsByFilters(EquipmentFilter equipmentFilter);

        Task<Equipment> GetEquipmentById(Guid id);

        Task<bool> UnlinkRoomEquipment(Guid id);

        Task<bool> LinkRoomEquipment(Guid id, Guid roomId);

        Task<bool> DeleteEquipment(Guid id);
    }
}
