using _01.CreciSP.Mvc.Extensions;
using AutoMapper;
using CreciSP.Application.Services.EquipmentService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.EquipmentDto;
using CreciSP.Mvc.Dtos.UserDto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreciSP.Mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IMapper _mapper;
        private readonly IValidatorFactory _validatorFactory;

        public EquipmentController(IEquipmentService equipmentService, IMapper mapper, IValidatorFactory validatorFactory)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
            _validatorFactory = validatorFactory;
        }

        /// <summary>
        /// Cria um Equipamento
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPost]
        public async Task<IActionResult> Create(EquipmentCreateDto userDto)
        {
            var equipment = _mapper.Map<Equipment>(userDto);

            ModelState.AddValidationResult(await _validatorFactory.GetValidator<Equipment>().ValidateAsync(equipment));
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            var result = await _equipmentService.Create(equipment);

            ModelState.AddValidationResult(_equipmentService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok(result);
        }

        /// <summary>
        /// Buscar lista de equipamentos com base nos parâmetros
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsersByFilters([FromQuery]EquipmentFilter equipmentFilter)
        {
            var result = await _equipmentService.GetEquipmentsByFilters(equipmentFilter);
            return Ok(result);
        }

        /// <summary>
        /// Buscar Equipamento pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Equipment</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Equipment> GetUserById(Guid id)
        {
            return await _equipmentService.GetEquipmentById(id);
        }

        /// <summary>
        /// Desvincular Equipamento a uma sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("{id}/unlinkroomequipment")]
        public async Task<IActionResult> UnlinkRoomEquipment(Guid id)
        {
             await _equipmentService.UnlinkRoomEquipment(id);

            ModelState.AddValidationResult(_equipmentService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }

        /// <summary>
        /// Vincular Equipamento a uma sala
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roomId"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("{id}/link-room-equipment")]
        public async Task<IActionResult> LinkRoomEquipment(Guid id, Guid roomId)
        {
            await _equipmentService.LinkRoomEquipment(id, roomId);

            ModelState.AddValidationResult(_equipmentService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }

        /// <summary>
        /// Deletar Equipamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso se operação for realizada com Sucesso</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEquipment(Guid id)
        {
            await _equipmentService.DeleteEquipment(id);

            ModelState.AddValidationResult(_equipmentService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }

    }
}
