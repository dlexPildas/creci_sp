using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.EquipmentRepository
{
    public interface IEquipmentRepository : IPersist
    {
        Task<ICollection<Equipment>> GetEquipmentsByFilters(EquipmentFilter equipmentFilter);

        Task<Equipment> GetEquipmentById(Guid id);

    }
}
