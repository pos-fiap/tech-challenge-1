using FluentValidation;
using FluentValidation.Results;
using RCLocacoes.Application.BaseResponse;

namespace RCLocacoes.Application.Utils
{
    public static class ValidationUtil
    {
        public static void ValidateClass<TEntity, TResponse>(TEntity entity, IValidator<TEntity> _validator, BaseOutput<TResponse> response)
        {

            ValidationResult validationResult = _validator.Validate(entity);

            if (!validationResult.IsValid)
            {
                validationResult.Errors.ToList().ForEach(error => response.AddError(error.ErrorMessage));
                response.IsSuccessful = false;
            }
        }
    }
}
