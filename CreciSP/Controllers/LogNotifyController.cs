using _01.CreciSP.Mvc.Extensions;
using AutoMapper;
using CreciSP.Application.Services.RoomService;
using CreciSP.Application.Services.LogNotifyService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreciSP.Mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogNotifyController : ControllerBase
    {
        private readonly ILogNotifyService _logNotifyService;
        private readonly IMapper _mapper;
        private readonly IValidatorFactory _validatorFactory;

        public LogNotifyController(ILogNotifyService logNotifyService, IMapper mapper, IValidatorFactory validatorFactory)
        {
            _logNotifyService = logNotifyService;
            _mapper = mapper;
            _validatorFactory = validatorFactory;
        }



        /// <summary>
        /// Buscar lista de Log Notify por Usuário
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Lsta de Log Notify</returns>
        [HttpGet]
        public async Task<IActionResult> GetLogNotifysByFilters(Guid userId)
        {
            var result = await _logNotifyService.GetLogNotifyByUserId(userId);

            ModelState.AddValidationResult(_logNotifyService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok(result);
        }

        


    }
}
