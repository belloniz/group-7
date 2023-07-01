using FluentValidation;

namespace FastFoodFIAP.Domain.CustomValidations
{
    public static class CustomValidation
    {
        public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CPFValidator<T, string>());
        }
    }
}

