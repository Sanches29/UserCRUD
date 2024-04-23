using FluentValidation.Results;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace UserCRUD.Configurations.FluentValidation
{
    public class CommandPipelineValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : ICommandResponse, new()
    {
        private readonly IEnumerable<IValidator> _validators;

        public CommandPipelineValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            ValidationContext<TRequest> validationContext = new ValidationContext<TRequest>(request);
            List<ValidationFailure> list = (from f in (await Task.WhenAll(_validators.Select((IValidator v) => v.ValidateAsync(validationContext, cancellationToken)))).SelectMany((ValidationResult r) => r.Errors)
                                            where f != null
                                            select f).ToList();
            if (!list.Any())
            {
                return await next();
            }

            TResponse result = new TResponse
            {
                ValidationResult = new ValidationResult()
            };
            result.ValidationResult.Errors.AddRange(list);
            return result;
        }
    }

    public interface ICommandResponse
    {
        ValidationResult ValidationResult { get; set; }
    }
}
