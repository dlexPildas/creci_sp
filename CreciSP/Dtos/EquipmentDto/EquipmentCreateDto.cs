using CreciSP.Domain.Enum;
using System;

namespace CreciSP.Mvc.Dtos.EquipmentDto
{
    public class EquipmentCreateDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public EquipmentType Type { get; set; }
        public string Description { get; set; }
    }
}
