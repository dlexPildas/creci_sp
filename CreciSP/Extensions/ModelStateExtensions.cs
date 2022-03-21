using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace _01.CreciSP.Mvc.Extensions
{
    public static class ModelStateExtensions
    {
        private const string KEY = "Domain";

        /// <summary>
        /// Add ValidationResult to ModelState
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="validationResult"></param>
        public static void AddValidationResult(this ModelStateDictionary modelState, ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
                validationResult.AddToModelState(modelState, KEY);
        }

        /// <summary>
        /// Add ErroMessage to ModelState
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="errorMessage"></param>
        public static void AddValidationError(this ModelStateDictionary modelState, string errorMessage)
        {
            modelState.AddModelError(KEY, errorMessage);
        }

        /// <summary>
        /// Get All Errors from ModelState
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static ValidationProblemDetails GetValidationProblemDetails(this ModelStateDictionary modelState)
        {
            return new ValidationProblemDetails(modelState);
        }
    }
}
