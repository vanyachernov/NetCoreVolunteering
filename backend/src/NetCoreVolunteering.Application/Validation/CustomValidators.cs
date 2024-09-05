using CSharpFunctionalExtensions;
using FluentValidation;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Application.Validation;

public static class CustomValidators
{
    public static IRuleBuilderOptionsConditions<T, TElement> MustBeValueObject<T, TElement, TValueObject>(
        this IRuleBuilder<T, TElement> ruleBuilder,
        Func<TElement, Result<TValueObject, Error>> factoryMethod)
    {
        return ruleBuilder.Custom((valueObject, context) =>
        {
            Result<TValueObject, Error> result = factoryMethod(valueObject);

            if (result.IsSuccess)
            {
                return;
            }
            
            context.AddFailure(result.Error.Serialize());
        });
    }
}