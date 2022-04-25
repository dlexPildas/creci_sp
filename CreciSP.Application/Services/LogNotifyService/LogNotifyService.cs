using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.LogNotifyRepository;
using CreciSP.Repository.Repositories;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.LogNotifyService
{
    public class LogNotifyService : NotifierService, ILogNotifyService
    {
        private readonly ILogNotifyRepository _logNotifyRepository;

        public LogNotifyService(ILogNotifyRepository logNotifyRepository)
        {
            _logNotifyRepository = logNotifyRepository;
        }

        public override ValidationResult ValidationResult()
        {
            return GetValidationResult();
        }


        /// <summary>
        /// Buscar lista de Log Notify por Usuário
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Lsta de Log Notify</returns>
        public async Task<ICollection<LogNotify>> GetLogNotifyByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                AddValidationFailure("Informe o usuário corretamente!");
                return null;
            }
            return await _logNotifyRepository.GetLogNotifyByUserId(userId);
        }

        
    }
}
